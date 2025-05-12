using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Hotels_app
{
    public partial class AddHotelForm : Form
    {
        private Hotel _hotel;
        private readonly ApplicationDbContext _context;
        private List<Room> _temporaryRooms = new List<Room>();
        private bool _isEditMode = false;
        HotelListingForm _hotelListingForm;
        public AddHotelForm(ApplicationDbContext context, Hotel hotel, HotelListingForm hotelListingForm)
        {
            _context = context;
            _hotel = hotel;
            _hotelListingForm = hotelListingForm;
            InitializeComponent();
            LoadCities();
            LoadStars();
            if (hotel != null)
            {
                _hotel = hotel;
                _isEditMode = true;

                // Заполняем поля формы данными из существующего объекта Hotel
                txtName.Text = _hotel.hotel_name;
                cmbCity.SelectedItem = _hotel.city?.title; // Используем название города
                cmbStars.SelectedItem = _hotel.stars?.ToString() ?? "Без звезд";
                txtAddress.Text = _hotel.address;
                txtDescription.Text = _hotel.hotel_description;
                UpdateRadioButtonsFromHotel(hotel);
                pictureBox.Image = _hotel.image;

                // Загружаем список комнат
                _temporaryRooms = _context.Rooms
                .Where(room => room.hotel.hotel_id == _hotel.hotel_id) // Фильтруем по hotel_id
                .ToList();
                UpdateRoomList();
                // Делаем кнопку удаления отеля видимой
                btnDeleteHotel.Visible = true;
            }
            else
            {
                _hotel = new Hotel();
                // Скрываем кнопку удаления отеля
                btnDeleteHotel.Visible = false;
            }

            _hotelListingForm = hotelListingForm;
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
        private void ListBoxRooms_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Очищаем фон
            e.DrawBackground();

            // Проверяем, что индекс элемента корректен
            if (e.Index >= 0)
            {
                // Получаем текст элемента
                string itemText = listBoxRooms.Items[e.Index]?.ToString() ?? string.Empty;

                // Определяем цвет текста и фона (используем цвета из вашего дизайна)
                Brush textColor = new SolidBrush(Color.FromArgb(64, 0, 64)); // Цвет текста (фиолетовый)
                Brush backColor = new SolidBrush(Color.FromArgb(243, 200, 220)); // Цвет фона (светло-розовый)

                // Если элемент выбран, меняем цвета
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    textColor = new SolidBrush(Color.FromArgb(243, 200, 220)); // Светло-розовый текст для выделенного элемента
                    backColor = new SolidBrush(Color.FromArgb(58, 51, 92)); // Темно-фиолетовый фон для выделенного элемента
                }

                // Заполняем фон элемента
                e.Graphics.FillRectangle(backColor, e.Bounds);

                // Рисуем текст элемента слева (без центрирования)
                e.Graphics.DrawString(itemText, e.Font, textColor, e.Bounds.Left + 5, e.Bounds.Top + 5); // Отступы: 5px слева и сверху

                // Рисуем горизонтальные линии (рамки) сверху и снизу
                using (Pen pen = new Pen(Color.FromArgb(64, 0, 64), 1)) // Цвет и толщина линии
                {
                    // Линия сверху
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

                    // Линия снизу
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            }

            // Рисуем фокус (если элемент выбран)
            e.DrawFocusRectangle();
        }
        private void UpdateRadioButtonsFromHotel(Hotel hotel)
        {
            // Обновляем состояние радиокнопок
            radioSea.Checked = hotel.has_sea_access;
            radioMountains.Checked = hotel.has_mountain_view;

            // Для группированных радиокнопок (например, "да" и "нет")
            radioYes1.Checked = hotel.has_historical_sites;
            radioNo1.Checked = !hotel.has_historical_sites;

            radioYes2.Checked = hotel.offers_active_recreation;
            radioNo2.Checked = !hotel.offers_active_recreation;

            radioAsian.Checked = hotel.has_asian_cuisine;
            radioEuropean.Checked = hotel.has_european_cuisine;

            radioCity.Checked = hotel.is_city_center;
        }
        private void LoadCities()
        {
            var cities = _context.Cities.ToList(); // Получаем список городов
            cmbCity.DataSource = cities;          // Устанавливаем источник данных
            cmbCity.DisplayMember = "title";      // Показываем название города
            cmbCity.ValueMember = "city_id";     // Используем ID города как значение
        }
        // Метод для нормализации названий городов
        private void LoadStars()
        {
            cmbStars.Items.Clear();
            cmbStars.Items.Add("Без звезд");
            for (int i = 1; i <= 5; i++)
            {
                cmbStars.Items.Add(i.ToString());
            }
        }
        private void btnAddHotel_Click(object sender, EventArgs e)
        {
            // Проверяем, заполнены ли обязательные поля
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(cmbCity.Text) || string.IsNullOrWhiteSpace(cmbStars.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, существует ли выбранный город в базе данных
            var selectedCityTitle = cmbCity.Text.Trim();
            var existingCity = _context.Cities.FirstOrDefault(c => c.title.ToLower() == selectedCityTitle.ToLower());

            if (existingCity == null)
            {
                MessageBox.Show($"Город \"{selectedCityTitle}\" не найден в базе данных. Выберите существующий город.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Проверяем, есть ли комнаты в списке
            if (_temporaryRooms == null || _temporaryRooms.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один номер для отеля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Находим минимальную и максимальную цены среди комнат
            decimal minPrice = _temporaryRooms.Min(room => room.price_per_night);
            decimal maxPrice = _temporaryRooms.Max(room => room.price_per_night);

            // Обновляем объект Hotel
            _hotel.hotel_name = txtName.Text.Trim();
            if (cmbStars.SelectedItem?.ToString() == "Без звезд")
            {
                _hotel.stars = null; // Беззвездочный отель
            }
            else
            {
                _hotel.stars = Convert.ToByte(cmbStars.SelectedItem?.ToString());
            }
            _hotel.city = existingCity; // Присваиваем существующий объект City
            _hotel.mn_price = minPrice;
            _hotel.mx_price = maxPrice;
            _hotel.hotel_description = txtDescription.Text.Trim();
            _hotel.address = txtAddress.Text.Trim();
            _hotel.has_sea_access = radioSea.Checked;
            _hotel.has_mountain_view = radioMountains.Checked;
            _hotel.has_historical_sites = radioYes1.Checked;
            _hotel.offers_active_recreation = radioYes2.Checked;
            _hotel.has_asian_cuisine = radioAsian.Checked;
            _hotel.has_european_cuisine = radioEuropean.Checked;
            _hotel.is_city_center = radioCity.Checked;

            // Добавляем или обновляем отель в базе данных
            if (_isEditMode)
            {
                // Обновляем существующий отель
                _context.Hotels.Update(_hotel);
            }
            else
            {
                // Добавляем новый отель
                _context.Hotels.Add(_hotel);
            }

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Добавляем или обновляем комнаты
            if (_isEditMode)
            {
                // Удаляем старые комнаты
                _context.Rooms.RemoveRange(_context.Rooms
                .Where(room => room.hotel.hotel_id == _hotel.hotel_id)
                .ToList());
                _context.SaveChanges();
            }

            foreach (var room in _temporaryRooms)
            {
                room.hotel = _hotel; // Привязываем комнату к отелю
                _context.Rooms.Add(room);
            }

            _context.SaveChanges();

            MessageBox.Show(_isEditMode ? "Отель успешно обновлен!" : "Отель и номера успешно добавлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Очищаем форму для нового ввода
            ClearForm();
            this.Close();
            _hotelListingForm.ReloadHotels();

        }

        private void ClearForm()
        {
            // Очищаем основные поля формы
            _hotel = new Hotel();
            txtName.Clear();
            cmbCity.SelectedIndex = -1;
            cmbStars.SelectedIndex = -1;
            txtDescription.Clear();
            txtAddress.Clear();

            // Сбрасываем состояния радиокнопок
            radioSea.Checked = false;
            radioMountains.Checked = false;
            radioQuiet.Checked = false;
            radioCity.Checked = false;
            radioYes1.Checked = false;
            radioNo1.Checked = false;
            radioYes2.Checked = false;
            radioNo2.Checked = false;
            radioAsian.Checked = false;
            radioEuropean.Checked = false;

            // Очищаем временный список комнат
            _temporaryRooms.Clear();

            // Очищаем ListBox и PictureBox
            listBoxRooms.Items.Clear();
            pictureBox.Image = null;
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

                        // Преобразуем изображение в массив байтов
                        byte[] imageBytes = Hotel.ImageToByteArray(pictureBox.Image);

                        // Сохраняем массив байтов в объект Hotel
                        _hotel.image_byte = imageBytes;
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

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var addRoomForm = new AddRoomForm(_context, _hotel, _temporaryRooms)
            {
                Owner = this,
            };

            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                // Добавляем созданный объект Room в коллекцию
                _temporaryRooms.Add(addRoomForm.CreatedRoom);

                // Обновляем список комнат на экране
                UpdateRoomList();
            }
        }

        private void UpdateRoomList()
        {
            listBoxRooms.Items.Clear();
            foreach (var room in _temporaryRooms)
            {
                listBoxRooms.Items.Add(room.name); // Отображаем номер комнаты
            }
        }
        private void RadioButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton clickedRadioButton = sender as System.Windows.Forms.RadioButton;

            if (clickedRadioButton != null)
            {
                if (clickedRadioButton.Checked)
                {
                    // Если радиокнопка уже активна, отключаем её
                    clickedRadioButton.Checked = false;
                }
                else
                {
                    // Если радиокнопка не активна, сбрасываем все остальные в группе
                    foreach (Control control in clickedRadioButton.Parent.Controls)
                    {
                        if (control is System.Windows.Forms.RadioButton radioButton && radioButton != clickedRadioButton)
                        {
                            radioButton.Checked = false;
                        }
                    }

                    // Активируем текущую радиокнопку
                    clickedRadioButton.Checked = true;
                }
            }
        }
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли элемент в ListBox
            if (listBoxRooms.SelectedItem == null)
            {
                MessageBox.Show("Выберите номер для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранный номер комнаты (строка из ListBox)
            string selectedRoomNumber = listBoxRooms.SelectedItem.ToString();

            // Находим объект Room в коллекции _temporaryRooms по номеру комнаты
            var roomToRemove = _temporaryRooms.FirstOrDefault(room => room.name == selectedRoomNumber);

            if (roomToRemove == null)
            {
                MessageBox.Show("Не удалось найти выбранный номер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Удаляем элемент из ListBox
            listBoxRooms.Items.Remove(selectedRoomNumber);

            // Удаляем объект из временного списка комнат (_temporaryRooms)
            _temporaryRooms.Remove(roomToRemove);

            MessageBox.Show("Номер успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDeleteHotel_Click(object sender, EventArgs e)
        {

            // Подтверждение удаления
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить этот отель и все связанные с ним номера? Это действие нельзя отменить.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return; // Если пользователь отменил удаление, выходим
            }

            // Находим все связанные комнаты
            List<Room> roomsToDelete = _context.Rooms
                .Where(room => room.hotel.hotel_id == _hotel.hotel_id)
                .ToList();

            // Удаляем комнаты из базы данных
            if (roomsToDelete.Any())
            {
                _context.Rooms.RemoveRange(roomsToDelete);
            }

            // Удаляем отель из базы данных
            _context.Hotels.Remove(_hotel);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            MessageBox.Show("Отель и все связанные номера успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Закрываем форму
            this.Close();
            _hotelListingForm.ReloadHotels();
        }

    }
}