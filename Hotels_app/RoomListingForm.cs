using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Hotels_app.classes;

namespace Hotels_app
{
    public partial class RoomListingForm : Form
    {
        private List<Room> rooms;
        private int currentTab = 1; // 1-комнатные активны по умолчанию
        private readonly Hotel _hotel;
        private readonly ApplicationDbContext _context;

        public RoomListingForm(Hotel hotel, ApplicationDbContext context)
        {
            InitializeComponent();
            InitializeRooms();
            UpdateTabHighlight();
            LoadRooms();
        }

        private void InitializeRooms()
        {
            rooms = new List<Room>
            {
                new Room { name = "1", capacity = 1, price_per_night = 5000, room_description = "Уютный 1-комнатный номер", image = null },
                new Room { name = "2", capacity = 1, price_per_night = 5200, room_description = "Уютный 1-комнатный номер", image = null },
                new Room { name = "3", capacity = 2, price_per_night = 8000, room_description = "Просторный 2-комнатный номер", image = null },
                new Room { name = "4", capacity = 2, price_per_night = 8500, room_description = "Просторный 2-комнатный номер", image = null },
                new Room { name = "5", capacity = 3, price_per_night = 12000, room_description = "Семейный номер", image = null },
            };
        }

        private void LoadRooms()
        {
            roomListingPanel.Controls.Clear();

            int verticalOffset = 13;

            foreach (var room in rooms)
            {
                if (currentTab == 1 && room.capacity != 1) continue;
                if (currentTab == 2 && room.capacity != 2) continue;
                if (currentTab == 4 && room.capacity < 3) continue; // семейные считаем 3+ мест

                var roomPanel = CreateRoomPanel(room);
                roomPanel.Location = new Point(4, verticalOffset);
                roomListingPanel.Controls.Add(roomPanel);

                verticalOffset += roomPanel.Height + 15;
            }
        }

        private Panel CreateRoomPanel(Room room)
        {
            var panel = new Panel
            {
                Size = new Size(572, 173),
                BackColor = Color.FromArgb(113, 85, 123),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Кнопка выбора
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

            // Цена (опущена ниже)
            var priceLabel = new Label
            {
                Text = $"{room.price_per_night} руб.",
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(12, 130), // Опущена до 110 (было 80)
                AutoSize = true
            };
            panel.Controls.Add(priceLabel);

            // Панель описания (уменьшена)
            var descPanel = new Panel
            {
                Size = new Size(160, 70), // Уменьшена ширина до 280, высота 50
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(160, 90) // Сдвинута вправо и вниз
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
            panel.Controls.Add(descPanel);

            // Картинка (сдвинута левее)
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

        private void oneRoomLabel_Click(object sender, EventArgs e)
        {
            currentTab = 1;
            UpdateTabHighlight();
            LoadRooms();
        }

        private void twoRoomLabel_Click(object sender, EventArgs e)
        {
            currentTab = 2;
            UpdateTabHighlight();
            LoadRooms();
        }

        private void familyRoomLabel_Click(object sender, EventArgs e)
        {
            currentTab = 4;
            UpdateTabHighlight();
            LoadRooms();
        }

        private void UpdateTabHighlight()
        {
            oneRoomLabel.Font = new Font("Segoe UI", 10F, currentTab == 1 ? FontStyle.Bold : FontStyle.Regular);
            twoRoomLabel.Font = new Font("Segoe UI", 10F, currentTab == 2 ? FontStyle.Bold : FontStyle.Regular);
            familyRoomLabel.Font = new Font("Segoe UI", 10F, currentTab == 4 ? FontStyle.Bold : FontStyle.Regular);

            Color activeColor = Color.FromArgb(64, 0, 128);
            Color inactiveColor = Color.FromArgb(64, 0, 64);

            oneRoomLabel.ForeColor = currentTab == 1 ? activeColor : inactiveColor;
            twoRoomLabel.ForeColor = currentTab == 2 ? activeColor : inactiveColor;
            familyRoomLabel.ForeColor = currentTab == 4 ? activeColor : inactiveColor;
        }
    }


}
