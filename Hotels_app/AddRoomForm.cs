namespace Hotels_app
{
    // <summary>
    ///  форма для добавления комнат
    ///</summary>
    public partial class AddRoomForm : Form
    {
        private readonly ApplicationDbContext _context;
        // <summary>
        ///  австосвойство для временного хранения списка комнат
        ///</summary>
        public List<Room> TemporaryRooms { get; private set; } = new List<Room>();
        // <summary>
        ///  автосвойство для хранения созданной комнаты
        ///</summary>
        public Room CreatedRoom { get; private set; }
        private Hotel _hotel;

        public AddRoomForm(ApplicationDbContext context, Hotel hotel, List<Room> temporaryRooms)
        {
            _context = context;
            _hotel = hotel;
            TemporaryRooms = temporaryRooms;
            InitializeComponent();
            CreatedRoom = new Room();
        }
        private bool IsRoomNameUnique(string roomName)
        {
            return !TemporaryRooms.Any(room => room.name.Equals(roomName, StringComparison.OrdinalIgnoreCase));
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    numericCapacity.Value <= 0 ||
                    numericAmount.Value <= 0)
                {
                    MessageBox.Show(Properties.Resources.Error_RequiredFields,
                                  Properties.Resources.Error_mes,
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                string roomNumber = txtName.Text.Trim();
                if (!IsRoomNameUnique(roomNumber))
                {
                    MessageBox.Show(Properties.Resources.Error_RoomExists,
                                  Properties.Resources.Error_mes,
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                var room = new Room
                {
                    hotel = _hotel,
                    name = txtName.Text,
                    price_per_night = Convert.ToDecimal(txtPrice.Text),
                    capacity = (int)numericCapacity.Value,
                    amount = (int)numericAmount.Value,
                    room_description = txtDescription.Text.Trim()
                };

                if (pictureBox.Image != null)
                {
                    room.image = pictureBox.Image;
                }
                else
                {
                    room.image = null;
                }

                CreatedRoom = room;

                MessageBox.Show(Properties.Resources.Success_RoomAdded,
                             Properties.Resources.Success,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Properties.Resources.Error_AddRoomException, ex.Message),
                              Properties.Resources.Error_mes,
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = Properties.Resources.SelectImageTitle;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;

                    try
                    {
                        pictureBox.Image = Image.FromFile(filePath);
                        CreatedRoom.image = pictureBox.Image;
                    }
                    catch
                    {
                        MessageBox.Show(Properties.Resources.Error_ImageUploadFailed,
                                      Properties.Resources.Error_mes,
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            CreatedRoom.image = null;
        }
    }
}