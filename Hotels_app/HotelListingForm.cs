using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotels_app
{
    public partial class HotelListingForm : Form
    {
        private List<Hotel> hotels;
        private readonly ApplicationDbContext _context;
        private readonly User _currentUser;
        private readonly AuthorizationForm _authorization;

        public HotelListingForm(User currentUser, ApplicationDbContext context, AuthorizationForm authorization)
        {
            InitializeComponent();
            _authorization = authorization;
            _context = context;
            _currentUser = currentUser;

            // Заполняем текстовые поля
            txtName.Text = _currentUser.first_name;
            txtSurname.Text = _currentUser.last_name;

            LoadHotelsData(); // Загружаем данные об отелях
            LoadHotels();     // Отображаем отели
            LoadCities();     // Загружаем города
            LoadStars();      // Загружаем количество звезд

            // Устанавливаем начальные значения
            cmbCity.SelectedIndex = 0; // Пустой вариант
            cmbStars.SelectedIndex = 0; // Пустой вариант

            // Подписываемся на события изменения значений в ComboBox
            cmbCity.SelectedIndexChanged += (sender, e) => FilterHotels();
            cmbStars.SelectedIndexChanged += (sender, e) => FilterHotels();

            txtPriceFrom.TextChanged += (sender, e) =>
            {
                FilterHotels();
            };

            txtPriceTo.TextChanged += (sender, e) =>
            {
                FilterHotels();
            };

            cmbCity.TextChanged += (sender, e) =>
            {
                FilterHotels();
            };
            if (!_currentUser.isfirstlogin)
            {
                FilterHotels(); // Применяем фильтры и рекомендации
            }

        }

        private void LoadHotelsData()
        {
            hotels = _context.Hotels
                .Include(h => h.city) // Загружаем связанные данные о городах
                .ToList();
        }
        public void ReloadHotels()
        {
            LoadHotelsData(); // Загружаем актуальные данные об отелях
            FilterHotels();   // Применяем фильтры и рекомендации
        }
        private void LoadHotels(List<Hotel> filteredHotels = null)
        {
            panelHotels.Controls.Clear();
            panelHotels.AutoScroll = true;

            var hotelsToDisplay = filteredHotels ?? hotels;

            // Сортировка отелей по оценке соответствия
            var sortedHotels = hotelsToDisplay
                .OrderByDescending(h => CalculateMatchScore(h, _currentUser))
                .ToList();

            int verticalOffset = 13;

            foreach (var hotel in sortedHotels)
            {
                var hotelPanel = CreateHotelPanel(hotel);

                hotelPanel.Location = new Point(4, verticalOffset);
                panelHotels.Controls.Add(hotelPanel);

                verticalOffset += hotelPanel.Height + 7;
            }
        }

        private Panel CreateHotelPanel(Hotel hotel)
        {
            var hotelPanel = new Panel
            {
                BackColor = Color.FromArgb(113, 85, 123),
                Size = new Size(772, 173),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            // Кнопка "НОМЕРА"
            var roomsButton = new RoundButton
            {
                BackColor = Color.FromArgb(209, 131, 170),
                BorderColor = Color.Transparent,
                BorderRadius = 15,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                HoverColor = Color.FromArgb(213, 140, 176),
                Location = new Point(12, 10),
                MinimumSize = new Size(117, 53),
                PressColor = Color.FromArgb(132, 49, 90),
                PressDepth = 0.15F,
                Size = new Size(144, 53),
                Text = "НОМЕРА",
                UseVisualStyleBackColor = false
            };
            roomsButton.Click += (sender, e) =>
            {
                var roomListingForm = new RoomListingForm(hotel, _context);
                roomListingForm.Show();
            };
            hotelPanel.Controls.Add(roomsButton);

            // Название отеля
            var nameLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(181, 32),
                Size = new Size(307, 40),
                Text = hotel.hotel_name,
                TextAlign = ContentAlignment.MiddleLeft
            };
            hotelPanel.Controls.Add(nameLabel);

            // Синяя панель информации
            var infoPanel = new Panel
            {
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(33, 84),
                Size = new Size(455, 78)
            };

            // Адрес
            var addressLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 10F),
                ForeColor = Color.FromArgb(230, 174, 207),
                Location = new Point(0, 5),
                Size = new Size(455, 20),
                Text = hotel.address,
                TextAlign = ContentAlignment.MiddleRight
            };
            infoPanel.Controls.Add(addressLabel);

            // Описание
            var descLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(230, 174, 207),
                Location = new Point(0, 25),
                Size = new Size(455, 20),
                Text = hotel.hotel_description,
                TextAlign = ContentAlignment.MiddleRight
            };
            infoPanel.Controls.Add(descLabel);

            hotelPanel.Controls.Add(infoPanel);

            // Изображение отеля
            var pictureBox = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Image = Properties.Resources.кама,
                Location = new Point(510, 12),
                Size = new Size(230, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            hotelPanel.Controls.Add(pictureBox);

            return hotelPanel;
        }

        private void LoadCities()
        {
            var cities = _context.Cities.Select(c => c.title).Distinct().ToList();
            cmbCity.Items.Clear();
            cmbCity.Items.Add("");
            cmbCity.Items.AddRange(cities.ToArray());
        }

        private void LoadStars()
        {
            cmbStars.Items.Clear();
            cmbStars.Items.Add("");
            for (int i = 1; i <= 5; i++)
            {
                cmbStars.Items.Add(i.ToString());
            }
        }

        private void BtnOpenQuestionnaire_Click(object sender, EventArgs e)
        {
            var questionnaireForm = new QuestionForm(_currentUser, _context)
            {
                Owner = this // Передаем ссылку на текущую форму
            };
            questionnaireForm.ShowDialog();
        }

        private void FilterHotels()
        {
            var filteredHotels = hotels.AsQueryable(); // Преобразуем в IQueryable

            // Фильтр по городу
            if (!string.IsNullOrWhiteSpace(cmbCity.Text))
            {
                string selectedCity = cmbCity.Text.Trim();
                filteredHotels = filteredHotels
                    .Where(h => h.city != null && h.city.title.Equals(selectedCity, StringComparison.OrdinalIgnoreCase));
            }

            // Фильтр по количеству звезд
            if (int.TryParse(cmbStars.SelectedItem?.ToString(), out int stars))
            {
                filteredHotels = filteredHotels.Where(h => h.stars == stars);
            }

            // Фильтр по цене "от"
            if (!string.IsNullOrWhiteSpace(txtPriceFrom.Text) && decimal.TryParse(txtPriceFrom.Text, out decimal priceFrom))
            {
                filteredHotels = filteredHotels.Where(h => h.mn_price >= priceFrom);
            }

            // Фильтр по цене "до"
            if (!string.IsNullOrWhiteSpace(txtPriceTo.Text) && decimal.TryParse(txtPriceTo.Text, out decimal priceTo))
            {
                filteredHotels = filteredHotels.Where(h => h.mx_price <= priceTo);
            }

            // Обновление отображения
            LoadHotels(filteredHotels.ToList());
        }

        private int CalculateMatchScore(Hotel hotel, User user)
        {
            int score = 0;

            // Проверка предпочтений пользователя
            if (user.prefers_sea.HasValue && user.prefers_sea.Value && hotel.has_sea_access) score++;
            if (user.prefers_sea.HasValue && !user.prefers_sea.Value && hotel.has_mountain_view) score++;

            if (user.prefers_historical_places.HasValue && user.prefers_historical_places.Value && hotel.has_historical_sites) score++;
            if (user.prefers_active_rest.HasValue && user.prefers_active_rest.Value && hotel.offers_active_recreation) score++;

            if (user.prefers_asian_cuisine.HasValue && user.prefers_asian_cuisine.Value && hotel.has_asian_cuisine) score++;
            if (user.prefers_asian_cuisine.HasValue && !user.prefers_asian_cuisine.Value && hotel.has_european_cuisine) score++;

            if (user.prefers_quiet_place.HasValue && user.prefers_quiet_place.Value && hotel.is_quiet_location) score++;
            if (user.prefers_quiet_place.HasValue && !user.prefers_quiet_place.Value && hotel.is_city_center) score++;

            return score;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            // Показываем диалоговое окно с предупреждением
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить свой аккаунт? Это действие нельзя отменить.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Удаляем аккаунт из базы данных
                _context.Users.Remove(_currentUser);
                _context.SaveChanges();

                MessageBox.Show("Аккаунт успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Перенаправляем пользователя на форму авторизации
                _authorization.Show();
                this.Hide(); // Скрываем текущую форму
            }

        }
        private void btnBooked_Click(object sender, EventArgs e)
        {

            // Создаем экземпляр формы BookedRoomsForm
            var bookedRoomsForm = new BookedRoomsForm(_currentUser, _context);

            // Показываем форму
            bookedRoomsForm.Show();
        }
    }
}