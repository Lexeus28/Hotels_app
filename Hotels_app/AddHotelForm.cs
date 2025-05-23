﻿using System.Data;
using Hotels_app.Properties;
namespace Hotels_app
{
    // <summary>
    ///  форма для добавления отелей
    ///</summary>
    public partial class AddHotelForm : Form
    {
        private Hotel _hotel;
        private readonly ApplicationDbContext _context;
        private List<Room> _temporaryRooms = new List<Room>();
        private bool _isEditMode = false;
        private HotelListingForm _hotelListingForm;
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

                txtName.Text = _hotel.hotel_name;
                cmbCity.SelectedItem = _hotel.city?.title; 
                cmbStars.SelectedItem = _hotel.stars?.ToString() ?? "Без звезд";
                txtAddress.Text = _hotel.address;
                txtDescription.Text = _hotel.hotel_description;
                UpdateRadioButtonsFromHotel(hotel);
                pictureBox.Image = _hotel.image;
                lblTitle.Text = Resources.EditHotels;
                

                // Загружаем список комнат
                _temporaryRooms = _context.Rooms
                .Where(room => room.hotel.hotel_id == _hotel.hotel_id)
                .ToList();
                UpdateRoomList();
                btnDeleteHotel.Visible = true;
            }
            else
            {
                _hotel = new Hotel();
                btnDeleteHotel.Visible = false;
            }

            _hotelListingForm = hotelListingForm;
        }
        private void ListBoxRooms_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var itemText = listBoxRooms.Items[e.Index]?.ToString() ?? string.Empty;

                var textColor = new SolidBrush(Color.FromArgb(64, 0, 64));
                var backColor = new SolidBrush(Color.FromArgb(243, 200, 220)); 

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    textColor = new SolidBrush(Color.FromArgb(243, 200, 220));
                    backColor = new SolidBrush(Color.FromArgb(58, 51, 92));
                }

                e.Graphics.FillRectangle(backColor, e.Bounds);
                e.Graphics.DrawString(itemText, e.Font, textColor, e.Bounds.Left + 5, e.Bounds.Top + 5);
                using (Pen pen = new Pen(Color.FromArgb(64, 0, 64), 1))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

                    e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            }
            e.DrawFocusRectangle();
        }
        private void UpdateRadioButtonsFromHotel(Hotel hotel)
        {
            radioSea.Checked = hotel.has_sea_access;
            radioMountains.Checked = hotel.has_mountain_view;

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
            cmbCity.DataSource = _context.Cities.ToList();
            cmbCity.DisplayMember = "title";
            cmbCity.ValueMember = "city_id";
        }
        private void LoadStars()
        {
            cmbStars.Items.Clear();
            cmbStars.Items.Add("Без звезд");
            for (var index = 1; index <= 5; index++)
            {
                cmbStars.Items.Add(index.ToString());
            }
        }
        private void btnAddHotel_Click(object sender, EventArgs e)
        {
                // Проверяем, заполнены ли обязательные поля
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(cmbCity.Text) || string.IsNullOrWhiteSpace(cmbStars.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show(Resources.Error_RequiredFields, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверяем, существует ли выбранный город в базе данных
                var selectedCityTitle = cmbCity.Text.Trim();
                var existingCity = _context.Cities.FirstOrDefault(c => c.title.ToLower() == selectedCityTitle.ToLower());

                if (existingCity == null)
                {   
                    MessageBox.Show(string.Format(Resources.FalseCity, selectedCityTitle), Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Проверяем, есть ли комнаты в списке
                if (_temporaryRooms == null || _temporaryRooms.Count == 0)
                {
                    MessageBox.Show(Resources.Error_AddAtLeastOneRoom, Resources.Error_mes,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Находим минимальную и максимальную цены среди комнат
                var minPrice = _temporaryRooms.Min(room => room.price_per_night);
                var maxPrice = _temporaryRooms.Max(room => room.price_per_night);

                _hotel.hotel_name = txtName.Text.Trim();

                if (cmbStars.SelectedItem?.ToString() == "Без звезд")
                {
                    _hotel.stars = null; // Беззвездочный отель
                }

                else
                {
                    _hotel.stars = Convert.ToByte(cmbStars.SelectedItem?.ToString());
                }

                _hotel.city = existingCity;
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

                if (_isEditMode)
                {
                    _context.Hotels.Update(_hotel);
                }

                else
                {
                    _context.Hotels.Add(_hotel);
                }

                _context.SaveChanges();

                if (_isEditMode)
                {
                    _context.Rooms.RemoveRange(_context.Rooms
                    .Where(room => room.hotel.hotel_id == _hotel.hotel_id)
                    .ToList());
                    _context.SaveChanges();
                }

                foreach (var room in _temporaryRooms)
                {
                    room.hotel = _hotel;
                    _context.Rooms.Add(room);
                }

                _context.SaveChanges();

            MessageBox.Show(_isEditMode ? Resources.Success_HotelUpdated : Resources.Success_HotelAdded,
            Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Очищаем форму для нового ввода
            ClearForm();
                this.Close();
                _hotelListingForm.ReloadHotels();
        }
        

        private void ClearForm()
        {
            _hotel = new Hotel();
            txtName.Clear();
            cmbCity.SelectedIndex = -1;
            cmbStars.SelectedIndex = -1;
            txtDescription.Clear();
            txtAddress.Clear();

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

            _temporaryRooms.Clear();

            listBoxRooms.Items.Clear();
            pictureBox.Image = null;
        }
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = Resources.SelectImageTitle;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;

                    try
                    {
                        pictureBox.Image = Image.FromFile(filePath);
                        var imageBytes = Hotel.ImageToByteArray(pictureBox.Image);
                        _hotel.image_byte = imageBytes;
                    }
                    catch
                    {
                        MessageBox.Show(Resources.Error_ImageUploadFailed, Resources.Error_mes,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            _hotel.image_byte = null;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var addRoomForm = new AddRoomForm(_context, _hotel, _temporaryRooms)
            {
                Owner = this,
            };

            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                _temporaryRooms.Add(addRoomForm.CreatedRoom);
                UpdateRoomList();
            }
        }

        private void UpdateRoomList()
        {
            listBoxRooms.Items.Clear();
            foreach (var room in _temporaryRooms)
            {
                listBoxRooms.Items.Add(room.name);
            }
        }
        private void RadioButton_Click(object sender, EventArgs e)
        {
            var clickedRadioButton = sender as RadioButton;

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
                        if (control is RadioButton radioButton && radioButton != clickedRadioButton)
                        {
                            radioButton.Checked = false;
                        }
                    }
                    clickedRadioButton.Checked = true;
                }
            }
        }
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли элемент в ListBox
            if (listBoxRooms.SelectedItem == null)
            {
                MessageBox.Show(Resources.Error_SelectRoomToDelete, Resources.Error_mes,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранный номер комнаты (строка из ListBox)
            var selectedRoomNumber = listBoxRooms.SelectedItem.ToString();

            // Находим объект Room в коллекции _temporaryRooms по номеру комнаты
            var roomToRemove = _temporaryRooms.FirstOrDefault(room => room.name == selectedRoomNumber);

            if (roomToRemove == null)
            {
                MessageBox.Show(Resources.Error_RoomNotFound, Resources.Error_mes, 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Удаляем элемент из ListBox
            listBoxRooms.Items.Remove(selectedRoomNumber);

            // Удаляем объект из временного списка комнат (_temporaryRooms)
            _temporaryRooms.Remove(roomToRemove);

            MessageBox.Show(Resources.Success_RoomDeleted, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDeleteHotel_Click(object sender, EventArgs e)
        {

            // Подтверждение удаления
            var result = MessageBox.Show(Resources.Confirm_DeleteHotel,
                  Resources.Title_DeleteConfirmation,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return; // Если пользователь отменил удаление, выходим
            }

            // Находим все связанные комнаты
            var roomsToDelete = _context.Rooms
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

            MessageBox.Show(Resources.Success_HotelDeleted, Resources.Success,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Закрываем форму
            this.Close();
            _hotelListingForm.ReloadHotels();
        }

    }
}