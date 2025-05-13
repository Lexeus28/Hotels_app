using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;

namespace Hotels_app
{
    public partial class BookedRoomsForm : Form
    {
        private List<Room> bookedRooms;
        private  List<Booking> _userBookings;
        private readonly User _currentUser;
        private readonly ApplicationDbContext _context;
        private Booking selectedBooking = null; // Текущий выбранный номер

        public BookedRoomsForm(List<Booking> userBookings, User user, ApplicationDbContext context)
        {
            InitializeComponent();
            _currentUser = user;
            _context = context;
            _userBookings = userBookings;
            LoadBookedRooms();
        }

        // Метод загрузки забронированных номеров
        private void LoadBookedRooms()
        {
            // Очищаем панель перед загрузкой новых данных
            leftPanel.Controls.Clear();
            leftPanel.Controls.Add(headlinePanel);

            int verticalOffset = 47; // Сдвиг для размещения под заголовком

            // Группируем бронирования по отелям
            var groupedBookings = _userBookings
                .GroupBy(b => b.room.hotel) // Группируем по объекту Hotel
                .OrderBy(g => g.Key.hotel_name) // Сортируем по названию отеля
                .ToList();

            foreach (var group in groupedBookings)
            {
                var hotel = group.Key; // Текущий отель
                // Создаем панель для названия отеля 
                var hotelPanel = new Panel
                {
                    Size = new Size(leftPanel.Width - 20, 50), // Ширина как у родительской панели, высота 50
                    BackColor = Color.FromArgb(77, 67, 126), // Цвет фона для панели отеля
                    Location = new Point(4, verticalOffset), // Отступ слева и сверху
                    Padding = new Padding(10, 5, 10, 5) // Отступы внутри панели
                };

                // Добавляем лейбл для отеля
                var hotelLabel = new Label
                {
                    Text = hotel.hotel_name, // Название отеля
                    Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(243, 200, 220),
                    AutoSize = false, // Занимает всю ширину панели
                    Dock = DockStyle.Fill, // Занимает всю панель
                    TextAlign = ContentAlignment.MiddleLeft // Выравнивание текста слева
                };
                // Добавляем лейбл в панель
                hotelPanel.Controls.Add(hotelLabel);
                // Добавляем панель на главную панель
                leftPanel.Controls.Add(hotelPanel);

                verticalOffset += hotelLabel.Height + 18; // Сдвиг для следующего элемента

                // Добавляем карточки бронирований для текущего отеля
                foreach (var booking in group)
                {
                    var room = booking.room;

                    // Создаем панель для отображения информации о бронировании
                    var bookingPanel = CreateBookedRoomPanel(booking, room);

                    // Устанавливаем позицию панели
                    bookingPanel.Location = new Point(4, verticalOffset);
                    leftPanel.Controls.Add(bookingPanel);

                    verticalOffset += bookingPanel.Height + 15; // Сдвиг для следующей панели
                }
            }
        }


        private Panel CreateBookedRoomPanel(Booking booking, Room room)
        {
            var bookingPanel = new Panel
            {
                Size = new Size(772, 173),
                BackColor = Color.FromArgb(113, 85, 123),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Margin = new Padding(0, 0, 0, 10),
                Tag = booking // Привязываем объект Room к панели
            };
            // Лейбл с названием комнаты
            var nameLabel = new Label
            {
                Text = room.name,
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular),
                ForeColor = Color.FromArgb(243, 200, 220),
                AutoSize = false,
                Size = new Size(290, 70),
                Location = new Point(200, 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 0, 0, 5),
                UseCompatibleTextRendering = true
            };

            // Обрезаем текст до двух строк
            nameLabel.Text = TruncateText(nameLabel, room.name);

            bookingPanel.Controls.Add(nameLabel);

            // Кнопка выбора
            var selectButton = new RoundButton
            {
                Text = "ВЫБРАТЬ",
                BackColor = Color.FromArgb(209, 131, 170),
                BorderColor = Color.Transparent,
                BorderRadius = 15,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                HoverColor = Color.FromArgb(213, 140, 176),
                Location = new Point(24, 20),
                MinimumSize = new Size(117, 20),
                PressColor = Color.FromArgb(132, 49, 90),
                PressDepth = 0.15F,
                Size = new Size(160, 40),
                Tag = booking // Привязываем объект Room к кнопке
            };

            // Обработчик клика на кнопку "ВЫБРАТЬ"
            selectButton.Click += (sender, e) => HandleBookingSelection(booking, bookingPanel);

            bookingPanel.Controls.Add(selectButton);

            // Цена (опущена ниже)
            var priceLabel = new Label
            {
                Text = $"{room.price_per_night} руб.",
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(36, 130), // Опущена до 110 (было 80)
                AutoSize = true
            };
            bookingPanel.Controls.Add(priceLabel);

            // Панель описания (уменьшена)
            var descPanel = new Panel
            {
                Size = new Size(240, 77), // Уменьшена ширина до 280, высота 50
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(230, 85) // Сдвинута вправо и вниз
            };

            // Текст описания (выравнивание по правому краю)
            var descLabel = new Label
            {
                Text = room.room_description,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(230, 174, 207),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight, // Выравнивание по правому краю
                Padding = new Padding(0, 0, 10, 0) // Отступ справа 10px
            };
            descPanel.Controls.Add(descLabel);
            bookingPanel.Controls.Add(descPanel);

            // Картинка (сдвинута левее)
            var pictureBox = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Image = room.image,
                Location = new Point(510, 12),
                Size = new Size(230, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            bookingPanel.Controls.Add(pictureBox);

            return bookingPanel;
        }
        private void HandleBookingSelection(Booking booking, Panel bookingPanel)
        {
            // Если уже выбрано это бронирование, сбрасываем выбор
            if (selectedBooking == booking)
            {
                selectedBooking = null; // Сбрасываем выбранный объект бронирования
                bookingPanel.BackColor = Color.FromArgb(113, 85, 123); // Возвращаем цвет фона к исходному

                // Очищаем текстовые поля
                txtDateFrom.Text = string.Empty;
                txtDateTo.Text = string.Empty;

                return;
            }

            // Сбрасываем выделение предыдущего бронирования
            if (selectedBooking != null)
            {
                var previousPanel = GetBookingPanelByBooking(selectedBooking);
                if (previousPanel != null)
                {
                    previousPanel.BackColor = Color.FromArgb(113, 85, 123); // Возвращаем цвет фона
                }
            }

            // Выбираем новое бронирование
            selectedBooking = booking;
            bookingPanel.BackColor = Color.FromArgb(140, 110, 160); // Меняем цвет фона для выделения

            // Записываем даты заезда и выезда в текстовые поля
            txtDateFrom.Text = booking.check_in_date.ToLocalTime().ToShortDateString();
            txtDateTo.Text = booking.check_out_date.ToLocalTime().ToShortDateString();
        }
        private Panel GetBookingPanelByBooking(Booking booking)
        {
            foreach (Control control in leftPanel.Controls)
            {
                if (control is Panel panel && panel.Tag is Booking taggedBooking && taggedBooking.booking_id == booking.booking_id)
                {
                    return panel;
                }
            }
            return null;
        }
        private string TruncateText(Label label, string text)
        {
            using (var g = label.CreateGraphics())
            {
                var textSize = g.MeasureString(text, label.Font, label.Size.Width);

                if (textSize.Height > label.Size.Height)
                {
                    // Обрезаем текст до двух строк с многоточием
                    var words = text.Split(' ');
                    var result = string.Empty;

                    foreach (var word in words)
                    {
                        var testString = result.Length > 0 ? $"{result} {word}" : word;
                        var testSize = g.MeasureString(testString, label.Font, label.Size.Width);

                        if (testSize.Height > label.Size.Height)
                        {
                            return result.Length > 0 ? $"{result}..." : "...";
                        }

                        result = testString;
                    }

                    return result;
                }

                return text;
            }
        }

        // Метод для обработки кнопки "Назад"
        private void backToHotelsButton_Click(object sender, EventArgs e)
        {
            // Закрыть текущую форму и вернуться к списку отелей
            this.Close();
        }

        // Метод для обработки кнопки "Отменить бронирование"
        private void cancelBookingButton_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли номер
            if (selectedBooking == null)
            {
                MessageBox.Show("Пожалуйста, выберите номер для отмены бронирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Находим бронирование для выбранного номера и текущего пользователя
                var booking = _userBookings.FirstOrDefault(b => b.room_id == selectedBooking.room_id);

                if (booking == null)
                {
                    MessageBox.Show("Бронирование не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Удаляем бронирование из базы данных
                _context.Bookings.Remove(booking);
                _context.SaveChanges();

                // Обновляем список бронирований
                _userBookings = _context.Bookings
                    .Include(b => b.room) // Подгружаем связанные комнаты
                    .Where(b => b.user_id == _currentUser.user_id) // Фильтруем по текущему пользователю
                    .ToList();

                // Перезагружаем интерфейс
                LoadBookedRooms();

                // Очищаем текстовые поля с датами
                txtDateFrom.Text = string.Empty;
                txtDateTo.Text = string.Empty;

                // Сбрасываем выбор номера
                selectedBooking = null;

                MessageBox.Show("Бронирование успешно отменено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при отмене бронирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
