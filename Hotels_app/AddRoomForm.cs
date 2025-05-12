using System;
using System.Windows.Forms;
using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;

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
            // Если изображение отсутствует, рисуем сетку
            if (pictureBox.Image == null)
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    // Размер ячейки сетки
                    int gridSize = 10;

                    // Рисуем горизонтальные линии
                    for (int y = 0; y < pictureBox.Height; y += gridSize)
                    {
                        e.Graphics.DrawLine(pen, 0, y, pictureBox.Width, y);
                    }

                    // Рисуем вертикальные линии
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
                // Проверка обязательных полей
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    numericCapacity.Value <= 0 ||
                    numericAmount.Value <= 0)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Проверка уникальности номера комнаты
                string roomNumber = txtName.Text.Trim();
                if (!IsRoomNameUnique(roomNumber))
                {
                    MessageBox.Show("Комната с таким названием уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создаем объект Room
                var room = new Room
                {
                    hotel = _hotel,
                    name = txtName.Text,
                    price_per_night = Convert.ToDecimal(txtPrice.Text),
                    capacity = (int)numericCapacity.Value,
                    amount = (int)numericAmount.Value,
                    room_description = txtDescription.Text.Trim()
                };

                // Сохраняем изображение
                if (pictureBox.Image != null)
                {
                    room.image = pictureBox.Image; // Автоматически конвертируется в массив байтов
                }
                else
                {
                    room.image = null;
                }

                // Устанавливаем созданный объект Room
                CreatedRoom = room;

                MessageBox.Show("Номер успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Закрываем форму
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении номера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Загружаем изображение в PictureBox
                        pictureBox.Image = Image.FromFile(filePath);

                        // Преобразуем изображение в массив байтов через класс Room
                        CreatedRoom.image = pictureBox.Image;
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить изображение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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