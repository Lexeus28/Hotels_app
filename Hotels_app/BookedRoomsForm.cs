using Hotels_app.Properties;
using Microsoft.EntityFrameworkCore;

namespace Hotels_app
{
    // <summary>
    ///  форма забронированных номеров
    ///</summary>
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
        private void LoadBookedRooms()
        {
            leftPanel.Controls.Clear();
            leftPanel.Controls.Add(headlinePanel);

            var verticalOffset = 47; 
            foreach (var booking in _userBookings)
            {
                var room = booking.room;
                var hotel = room.hotel;
                var bookingPanel = CreateBookedRoomPanel(booking, room, hotel);

                bookingPanel.Location = new Point(4, verticalOffset);
                leftPanel.Controls.Add(bookingPanel);

                verticalOffset += bookingPanel.Height + 15;
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
                Tag = booking
            };
            selectButton.Click += (sender, e) => HandleBookingSelection(booking, bookingPanel);

            bookingPanel.Controls.Add(selectButton);

            var priceLabel = new Label
            {
                Text = $"{room.price_per_night} руб.",
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(36, 130),
                AutoSize = true
            };
            bookingPanel.Controls.Add(priceLabel);

            var infoPanel = new Panel
            {
                Size = new Size(240, 90),
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(230, 73)
            };
            bookingPanel.Controls.Add(infoPanel);

            var roomPanel = new Panel
            {
                Size = new Size(240, 40),
                BackColor = Color.Transparent,
                Dock = DockStyle.Top
            };
            infoPanel.Controls.Add(roomPanel);

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

            var descLabel = new Label
            {
                Text = room.room_description,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(230, 174, 207),
                Location = new Point(5, 5),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 10, 0)
            };
            descPanel.Controls.Add(descLabel);
           
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
            if (selectedBooking == booking)
            {
                selectedBooking = null;
                bookingPanel.BackColor = Color.FromArgb(113, 85, 123);
                txtDateFrom.Text = string.Empty;
                txtDateTo.Text = string.Empty;
                return;
            }
            if (selectedBooking != null)
            {
                var previousPanel = GetBookingPanelByBooking(selectedBooking);
                if (previousPanel != null)
                {
                    previousPanel.BackColor = Color.FromArgb(113, 85, 123);
                }
            }
            selectedBooking = booking;
            bookingPanel.BackColor = Color.FromArgb(140, 110, 160);

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
        private void backToHotelsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cancelBookingButton_Click(object sender, EventArgs e)
        {
            if (selectedBooking == null)
            {
                MessageBox.Show(Resources.Error_DeletingBooking, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var booking = _userBookings.FirstOrDefault(b => b.room_id == selectedBooking.room_id);

                if (booking == null)
                {
                    MessageBox.Show(Resources.Error_BookingNotFound, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                _userBookings = _context.Bookings
                    .Include(b => b.room) 
                    .Where(b => b.user_id == _currentUser.user_id)
                    .ToList();
                LoadBookedRooms();
                txtDateFrom.Text = string.Empty;
                txtDateTo.Text = string.Empty;
                selectedBooking = null;

                MessageBox.Show(Resources.Success_DeletingBooking, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.Error_CancelingBooking} {ex.Message}", Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
