using System;
using System.Windows.Forms;
using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;
using Hotels_app.Properties;

namespace Hotels_app
{
    public partial class AddRoomForm : Form
    {
        private readonly ApplicationDbContext _context;
        public List<Room> TemporaryRooms { get; private set; } = new List<Room>();
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

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox.Image == null)
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    int gridSize = 10;
                    for (int y = 0; y < pictureBox.Height; y += gridSize)
                    {
                        e.Graphics.DrawLine(pen, 0, y, pictureBox.Width, y);
                    }
                    for (int x = 0; x < pictureBox.Width; x += gridSize)
                    {
                        e.Graphics.DrawLine(pen, x, 0, x, pictureBox.Height);
                    }
                }
            }
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
                    MessageBox.Show(Resources.Error_RequiredFields,
                                  Resources.Error_mes,
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                string roomNumber = txtName.Text.Trim();
                if (!IsRoomNameUnique(roomNumber))
                {
                    MessageBox.Show(Resources.Error_RoomExists,
                                  Resources.Error_mes,
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

                MessageBox.Show(Resources.Success_RoomAdded,
                             Resources.Success,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.Error_AddRoomException, ex.Message),
                              Resources.Error_mes,
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Resources.ImageFilesFilter;
                openFileDialog.Title = Resources.SelectImageTitle;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                        CreatedRoom.image = pictureBox.Image;
                    }
                    catch
                    {
                        MessageBox.Show(Resources.Error_ImageUploadFailed,
                                      Resources.Error_mes,
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
        }
    }
}