using Hotels_app.Properties;
using Microsoft.EntityFrameworkCore;

namespace Hotels_app
{
    // <summary>
    ///  форма для просмотра комнат
    ///</summary>
    public partial class RoomListingForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly Hotel _hotel;
        private readonly User _currentUser;
        private List<Room> rooms;
        private int currentTab = 1; // 1-комнатные активны по умолчанию
        private Room selectedRoom = null; // Текущий выбранный номер

        public RoomListingForm(User user, Hotel hotel, ApplicationDbContext context)
        {
            InitializeComponent();
            _currentUser = user;
            _context = context;
            _hotel = hotel;

            InitializeRooms();
            UpdateTabHighlight();
            LoadRooms();
        }

        private void InitializeRooms()
        {
            rooms = _context.Rooms
                .Where(r => r.hotel.hotel_id == _hotel.hotel_id)
                .ToList();
        }

        private void LoadRooms()
        {
            leftPanel.Controls.Clear();
            leftPanel.Controls.Add(roomTypePanel);

            var verticalOffset = 47;

            foreach (var room in rooms)
            {
                if (currentTab == 1 && room.capacity != 1) continue;
                if (currentTab == 2 && room.capacity != 2) continue;
                if (currentTab == 4 && room.capacity < 3) continue;

                var roomPanel = CreateRoomPanel(room);
                roomPanel.Location = new Point(1, verticalOffset);
                leftPanel.Controls.Add(roomPanel);

                verticalOffset += roomPanel.Height + 15;
            }

            // После загрузки комнат проверяем, есть ли ранее выбранный номер
            if (selectedRoom != null)
            {
                var selectedPanel = GetRoomPanelByRoom(selectedRoom);
                if (selectedPanel != null)
                {
                    selectedPanel.BackColor = Color.FromArgb(140, 110, 160); // Выделяем панель
                }
            }
        }
        private Panel CreateRoomPanel(Room room)
        {
            var roomPanel = new Panel
            {
                Size = new Size(772, 173),
                BackColor = Color.FromArgb(113, 85, 123),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Margin = new Padding(0, 0, 0, 10),
                Tag = room
            };

            var namePanel = new Panel
            {
                Size = new Size(290, 70),
                BackColor = Color.Transparent,
                Location = new Point(200, 10)
            };
            roomPanel.Controls.Add(namePanel);

            var nameLabel = new Label
            {
                Text = room.name,
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular),
                ForeColor = Color.FromArgb(243, 200, 220),
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 0, 0, 5),
                UseCompatibleTextRendering = true
            };

            namePanel.Controls.Add(nameLabel);

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
                Tag = room // Привязываем объект Room к кнопке
            };

            selectButton.Click += (sender, e) => HandleRoomSelection(room, roomPanel);
            roomPanel.Controls.Add(selectButton);

            var priceLabel = new Label
            {
                Text = $"{room.price_per_night} руб.",
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(36, 130),
                AutoSize = true
            };
            roomPanel.Controls.Add(priceLabel);

            var descPanel = new Panel
            {
                Size = new Size(240, 77), 
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(230, 85)
            };

            var descLabel = new Label
            {
                Text = room.room_description,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(230, 174, 207),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 10, 0) 
            };
            descPanel.Controls.Add(descLabel);
            roomPanel.Controls.Add(descPanel);

            var pictureBox = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Image = room.image,
                Location = new Point(510, 12),
                Size = new Size(230, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            roomPanel.Controls.Add(pictureBox);

            return roomPanel;
        }
        private void HandleRoomSelection(Room room, Panel roomPanel)
        {
            // Если уже выбран этот номер, сбрасываем выбор
            if (selectedRoom == room)
            {
                selectedRoom = null;
                roomPanel.BackColor = Color.FromArgb(113, 85, 123);
                return;
            }

            // Обнуляем выделение предыдущего номера
            if (selectedRoom != null)
            {
                var previousPanel = GetRoomPanelByRoom(selectedRoom);
                if (previousPanel != null)
                {
                    previousPanel.BackColor = Color.FromArgb(113, 85, 123);
                }
            }
            selectedRoom = room;
            roomPanel.BackColor = Color.FromArgb(140, 110, 160);
        }

        private Panel GetRoomPanelByRoom(Room room)
        {
            foreach (Control control in leftPanel.Controls)
            {
                if (control is Panel panel && panel.Tag as Room == room)
                {
                    return panel;
                }
            }
            return null;
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
            oneRoomLabel.Font = new Font("Segoe UI", 17F, currentTab == 1 ? FontStyle.Bold : FontStyle.Regular);
            twoRoomLabel.Font = new Font("Segoe UI", 17F, currentTab == 2 ? FontStyle.Bold : FontStyle.Regular);
            familyRoomLabel.Font = new Font("Segoe UI", 17F, currentTab == 4 ? FontStyle.Bold : FontStyle.Regular);

            var activeColor = Color.FromArgb(64, 0, 128);
            var inactiveColor = Color.FromArgb(64, 0, 64);

            oneRoomLabel.ForeColor = currentTab == 1 ? activeColor : inactiveColor;
            twoRoomLabel.ForeColor = currentTab == 2 ? activeColor : inactiveColor;
            familyRoomLabel.ForeColor = currentTab == 4 ? activeColor : inactiveColor;

        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            if (selectedRoom == null)
            {
                MessageBox.Show("Пожалуйста, выберите номер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fromDatePicker.Value == null || toDatePicker.Value == null)
            {
                MessageBox.Show("Пожалуйста, выберите даты заезда и выезда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var checkInDate = fromDatePicker.Value.Date;
            var checkOutDate = toDatePicker.Value.Date;

            if (checkInDate < DateTime.Today)
            {
                MessageBox.Show("Нельзя выбрать дату заезда в прошлом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOutDate < checkInDate)
            {
                MessageBox.Show("Дата выезда должна быть больше или равна дате заезда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maxBookingDate = DateTime.Today.AddYears(2);
            if (checkOutDate > maxBookingDate)
            {
                MessageBox.Show("Бронирование доступно только на срок до 2 лет вперёд.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем даты в UTC для сохранения в базу данных
            var checkInDateUtc = checkInDate.ToUniversalTime();
            var checkOutDateUtc = checkOutDate.ToUniversalTime();

            // Проверяем количество бронирований для выбранной комнаты на указанные даты
            var overlappingBookings = _context.Bookings.Where(b => b.room_id == selectedRoom.room_id &&
                (
                    // Пересечение диапазонов дат
                    (b.check_in_date < checkOutDateUtc && b.check_out_date > checkInDateUtc) ||
                    // Полное включение одного диапазона в другой
                    (b.check_in_date >= checkInDateUtc && b.check_in_date < checkOutDateUtc) ||
                    (b.check_out_date > checkInDateUtc && b.check_out_date <= checkOutDateUtc) ||
                    // Заезд и выезд в один день
                    (checkInDateUtc.Date == checkOutDateUtc.Date && b.check_in_date.Date <= checkInDateUtc.Date && b.check_out_date.Date >= checkInDateUtc.Date)
                )).ToList();

            // Проверяем, не превышено ли количество бронирований
            if (overlappingBookings.Count >= selectedRoom.amount)
            {
                MessageBox.Show("Номер уже полностью забронирован на выбранные даты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var booking = new Booking
            {
                room_id = selectedRoom.room_id,
                user_id = _currentUser.user_id,
                check_in_date = checkInDateUtc,
                check_out_date = checkOutDateUtc
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            MessageBox.Show("Номер успешно забронирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}