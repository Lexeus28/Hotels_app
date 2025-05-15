using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Hotels_app.classes;
using Hotels_app.Properties;
using Microsoft.EntityFrameworkCore;

namespace Hotels_app
{
    public partial class BookedRoomsForm : Form
    {
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

            // Перебираем все бронирования пользователя
            foreach (var booking in _userBookings)
            {
                var room = booking.room;
                var hotel = room.hotel;

                // Создаем панель для отображения информации о бронировании
                var bookingPanel = CreateBookedRoomPanel(booking, room, hotel);

                // Устанавливаем позицию панели
                bookingPanel.Location = new Point(4, verticalOffset);
                leftPanel.Controls.Add(bookingPanel);

                verticalOffset += bookingPanel.Height + 15; // Сдвиг для следующей панели
            }
        }


        private Panel CreateBookedRoomPanel(Booking booking, Room room, Hotel hotel)
        {
            var bookingPanel = new Panel
            {
                Size = new Size(772, 173),
                BackColor = Color.FromArgb(113, 85, 123),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Margin = new Padding(0, 0, 0, 10),
                Tag = booking
            };

            var namePanel = new Panel
            {
                Size = new Size(290, 70),
                BackColor = Color.Transparent,
                Location = new Point(200, 5)
            };
            bookingPanel.Controls.Add(namePanel);
            // Лейбл с названием комнаты
            var nameLabel = new Label
            {
                Text = hotel.stars != null ? $"{hotel.stars}* {hotel.hotel_name}" : hotel.hotel_name,
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular),
                ForeColor = Color.FromArgb(243, 200, 220),
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 0, 0, 5),
                UseCompatibleTextRendering = true
            };
            namePanel.Controls.Add(nameLabel);

            // Кнопка выбора
            var selectButton = new RoundButton
            {
                Text = Resources.TextSelect,
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
                Location = new Point(36, 130),
                AutoSize = true
            };
            bookingPanel.Controls.Add(priceLabel);

            // Панель описания (уменьшена)
            var infoPanel = new Panel
            {
                Size = new Size(240, 90), // Уменьшена ширина до 280, высота 50
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(230, 73) // Сдвинута вправо и вниз
            };
            bookingPanel.Controls.Add(infoPanel);

            var roomPanel = new Panel
            {
                Size = new Size(240, 40),
                BackColor = Color.Transparent,
                Dock = DockStyle.Top
            };
            infoPanel.Controls.Add(roomPanel);

            // Лейбл с названием отеля
            var roomLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 12F),
                ForeColor = Color.FromArgb(230, 174, 207),
                Text = room.name,
                Dock = DockStyle.Fill,
                Location = new Point(5, 5),
                TextAlign = ContentAlignment.MiddleLeft,
            };
            roomPanel.Controls.Add(roomLabel);

            var descPanel = new Panel
            {
                Size = new Size(240, 50),
                BackColor = Color.Transparent,
                Location = new Point(0,40)
            };
            infoPanel.Controls.Add(descPanel);

            // Текст описания (выравнивание по правому краю)
            var descLabel = new Label
            {
                Text = room.room_description,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(230, 174, 207),
                Location = new Point(5, 5),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 10, 0) // Отступ справа 10px
            };
            descPanel.Controls.Add(descLabel);
           

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
