using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Hotels_app.classes;

namespace Hotels_app
{
    public partial class BookedRoomsForm : Form
    {
        private List<Room> bookedRooms;
        private readonly User _currentUser;
        private readonly ApplicationDbContext _context;

        public BookedRoomsForm(User currentUser, ApplicationDbContext context)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _context = context;
            LoadBookedRooms();
        }

        // Метод загрузки забронированных номеров
        private void LoadBookedRooms()
        {
            // Здесь можно добавить реальную логику для загрузки забронированных номеров,
            // например, с базы данных или из памяти.
            bookedRooms = new List<Room>
            {
                new Room { room_number = "1", capacity = 1, price_per_night = 5000, room_description = "Уютный 1-комнатный номер", image = Properties.Resources.super_room },
                new Room { room_number = "2", capacity = 2, price_per_night = 8000, room_description = "Просторный 2-комнатный номер", image = Properties.Resources.super_room },
            };

            // Отображаем номера
            int verticalOffset = 40; // Сдвиг для размещения под заголовком

            foreach (var room in bookedRooms)
            {
                var roomPanel = CreateBookedRoomPanel(room);
                roomPanel.Location = new Point(4, verticalOffset);
                roomsListingPanel.Controls.Add(roomPanel); // bookedRoomsPanel — это панель, куда будут добавляться элементы

                verticalOffset += roomPanel.Height + 15; // Сдвиг для следующей панели
            }
        }

        // Метод для создания панели с номером
        private Panel CreateBookedRoomPanel(Room room)
        {
            var panel = new Panel
            {
                Size = new Size(572, 173),
                BackColor = Color.FromArgb(113, 85, 123),
                Margin = new Padding(0, 0, 0, 15)
            };

            // Кнопка выбора (аналогично оригиналу)
            var selectButton = new RoundButton
            {
                Text = "ВЫБРАТЬ",
                BackColor = Color.FromArgb(209, 131, 170),
                BorderColor = Color.Transparent,
                BorderRadius = 15,
                Size = new Size(144, 53),
                Location = new Point(12, 12),
                HoverColor = Color.FromArgb(213, 140, 176),
                PressColor = Color.FromArgb(132, 49, 90),
                PressDepth = 0.15f,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220)
            };
            panel.Controls.Add(selectButton);

            // Цена
            var priceLabel = new Label
            {
                Text = $"{room.price_per_night} руб.",
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(12, 130), // Опущена до 110 (было 80)
                AutoSize = true
            };
            panel.Controls.Add(priceLabel);

            // Панель с описанием
            var descPanel = new Panel
            {
                Size = new Size(160, 70), // Уменьшена ширина до 280, высота 50
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(160, 90) // Сдвинута вправо и вниз
            };

            var descLabel = new Label
            {
                Text = room.room_description,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(230, 174, 207),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 10, 0)
            };
            descPanel.Controls.Add(descLabel);
            panel.Controls.Add(descPanel);

            // Картинка
            var pictureBox = new PictureBox
            {
                Image = room.image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(230, 150),
                Location = new Point(330, 12),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(pictureBox);

            return panel;
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
            // Логика отмены бронирования
            MessageBox.Show("Бронирование отменено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
