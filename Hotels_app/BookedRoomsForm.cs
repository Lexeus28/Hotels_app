//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Windows.Forms;
//using Hotels_app.classes;

//namespace Hotels_app
//{
//    public partial class BookedRoomsForm : Form
//    {
//        private List<Room> bookedRooms;

//        public BookedRoomsForm()
//        {
//            InitializeComponent();
//            LoadBookedRooms();
//        }

//        // Метод загрузки забронированных номеров
//        private void loadbookedrooms()
//        {
//            // здесь можно добавить реальную логику для загрузки забронированных номеров,
//            // например, с базы данных или из памяти.
//            bookedrooms = new list<room>
//            {
//                new room { room_number = "1", capacity = 1, price_per_night = 5000, description = "уютный 1-комнатный номер", image = properties.resources.super_room },
//                new room { room_number = "2", capacity = 2, price_per_night = 8000, description = "просторный 2-комнатный номер", image = properties.resources.super_room },
//            };

//            // отображаем номера
//            int verticaloffset = 40; // сдвиг для размещения под заголовком

//            foreach (var room in bookedrooms)
//            {
//                var roompanel = createbookedroompanel(room);
//                roompanel.location = new point(4, verticaloffset);
//                roomslistingpanel.controls.add(roompanel); // bookedroomspanel — это панель, куда будут добавляться элементы

//                verticaloffset += roompanel.height + 15; // сдвиг для следующей панели
//            }
//        }

//        // Метод для создания панели с номером
//        private Panel CreateBookedRoomPanel(Room room)
//        {
//            var panel = new Panel
//            {
//                Size = new Size(572, 173),
//                BackColor = Color.FromArgb(113, 85, 123),
//                Margin = new Padding(0, 0, 0, 15)
//            };

//            // Кнопка выбора (аналогично оригиналу)
//            var selectButton = new RoundButton
//            {
//                Text = "ВЫБРАТЬ",
//                BackColor = Color.FromArgb(209, 131, 170),
//                BorderColor = Color.Transparent,
//                BorderRadius = 15,
//                Size = new Size(144, 53),
//                Location = new Point(12, 12),
//                HoverColor = Color.FromArgb(213, 140, 176),
//                PressColor = Color.FromArgb(132, 49, 90),
//                PressDepth = 0.15f,
//                FlatStyle = FlatStyle.Flat,
//                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
//                ForeColor = Color.FromArgb(243, 200, 220)
//            };
//            panel.Controls.Add(selectButton);

//            // Цена
//            var priceLabel = new Label
//            {
//                Text = $"{room.price_per_night} руб.",
//                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold),
//                ForeColor = Color.FromArgb(243, 200, 220),
//                Location = new Point(12, 130), // Опущена до 110 (было 80)
//                AutoSize = true
//            };
//            panel.Controls.Add(priceLabel);

//            // Панель с описанием
//            var descPanel = new Panel
//            {
//                Size = new Size(160, 70), // Уменьшена ширина до 280, высота 50
//                BackColor = Color.FromArgb(77, 67, 126),
//                Location = new Point(160, 90) // Сдвинута вправо и вниз
//            };

//            var descLabel = new Label
//            {
//                Text = room.description,
//                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic),
//                ForeColor = Color.FromArgb(230, 174, 207),
//                Dock = DockStyle.Fill,
//                TextAlign = ContentAlignment.MiddleRight,
//                Padding = new Padding(0, 0, 10, 0)
//            };
//            descPanel.Controls.Add(descLabel);
//            panel.Controls.Add(descPanel);

//            // Картинка
//            var pictureBox = new PictureBox
//            {
//                Image = room.image,
//                SizeMode = PictureBoxSizeMode.StretchImage,
//                Size = new Size(230, 150),
//                Location = new Point(330, 12),
//                Anchor = AnchorStyles.Top | AnchorStyles.Right,
//                BackColor = Color.Transparent
//            };
//            panel.Controls.Add(pictureBox);

//            return panel;
//        }

//        // Метод для обработки кнопки "Назад"
//        private void backToHotelsButton_Click(object sender, EventArgs e)
//        {
//            // Закрыть текущую форму и вернуться к списку отелей
//            this.Close();
//        }

//        // Метод для обработки кнопки "Отменить бронирование"
//        private void cancelBookingButton_Click(object sender, EventArgs e)
//        {
//            // Логика отмены бронирования
//            MessageBox.Show("Бронирование отменено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }
//    }
//}
