using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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

            // Заполняем текстовые поля
            txtName.Text = _currentUser.first_name;
            txtSurname.Text = _currentUser.last_name;

            // Проверяем, является ли пользователь администратором
            if (IsAdmin())
            {
                // Блокируем кнопку редактирования аккаунта
                BtnOpenQuestionnaire.Visible = false;

                // Меняем текст и обработчик кнопки "Забронированные"
                btnBooked.Text = "добавить отель";
                btnBooked.Click -= btnBooked_Click; // Удаляем старый обработчик
                btnBooked.Click += AddHotelButton_Click; // Добавляем новый обработчик
                btnDeleteAccount.Enabled = false;
                btnDeleteAccount.BackColor = Color.FromArgb(196, 170,195);
            }
            else
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
                BtnOpenQuestionnaire.Visible = true;
                btnDeleteAccount.Enabled = true;
                btnDeleteAccount.BackColor = Color.FromArgb(75, 21, 53);
                btnDeleteAccount.BorderColor = Color.FromArgb(223, 150, 161);
            }

            // Загружаем данные об отелях
            LoadHotelsData();
            LoadHotels();
            LoadCities();
            LoadStars();

            // Устанавливаем начальные значения
            cmbCity.SelectedIndex = 0; // Пустой вариант
            cmbStars.SelectedIndex = 0; // Пустой вариант

            // Подписываемся на события изменения значений в ComboBox
            cmbCity.SelectedIndexChanged += (sender, e) => FilterHotels();
            cmbStars.SelectedIndexChanged += (sender, e) => FilterHotels();
            txtPriceFrom.TextChanged += (sender, e) => FilterHotels();
            txtPriceTo.TextChanged += (sender, e) => FilterHotels();
        }
        bool IsAdmin()
        {
            // Логика проверки роли пользователя 
            return _context.Users.Any(u => u.username == _currentUser.username && u.role == Role.Admin);
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
                FilterHotels();
            };

            cmbCity.TextChanged += (sender, e) =>
            {
                FilterHotels();
            };
            if (!_currentUser.isfirstlogin)
            {
                FilterHotels();
            }

        }

        private void LoadHotelsData()
        {
            hotels = _context.Hotels
                .Include(h => h.city)
                .ToList();
        }
        public void ReloadHotels()
        {
            LoadHotelsData();
            FilterHotels();
        }
        private void LoadHotels(List<Hotel> filteredHotels = null)
        {
            panelHotels.Controls.Clear();
            panelHotels.AutoScroll = true;

            var hotelsToDisplay = filteredHotels ?? hotels;

            // Получаем рекомендованные отели, но только из отфильтрованного списка
            var recommendedHotels = GetRecommendedHotels(_currentUser)
                .Where(h => hotelsToDisplay.Contains(h)) // Берем только те, которые прошли фильтры
                .ToList();

            // Добавляем случайность для рекомендованных отелей
            var random = new Random();
            var boostedRecommendedHotels = recommendedHotels
                .Where(h => random.Next(0, 4) == 0) // Поднимаем только 25% рекомендованных отелей (1 из 4)
                .ToList();

            // Объединяем отели: сначала случайные рекомендованные, затем остальные
            var sortedHotels = boostedRecommendedHotels
                .Concat(hotelsToDisplay.Where(h => !boostedRecommendedHotels.Contains(h))) // Остальные отели
                .OrderByDescending(h => CalculateMatchScore(h, _currentUser)) // Сортируем по соответствию
                .ToList();

            int verticalOffset = 13; // Вертикальный отступ

            foreach (var hotel in sortedHotels)
            {
                var isBoosted = boostedRecommendedHotels.Contains(hotel);

                // Если отель был поднят выше, добавляем метку "Нравится пользователям с похожими предпочтениями"
                if (isBoosted)
                {
                    var recommendationLabel = new Label
                    {
                        Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                        ForeColor = Color.FromArgb(64, 0, 64),
                        AutoSize = true,
                        Location = new Point(10, verticalOffset),
                        Text = "Нравится пользователям с похожими предпочтениями",
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    panelHotels.Controls.Add(recommendationLabel);
                    verticalOffset += recommendationLabel.Height + 5;
                }

                // Создаем панель отеля
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

            if (IsAdmin())
            {
                var editButton = new RoundButton
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
                    Text = "редактировать",
                    UseVisualStyleBackColor = false
                };

                editButton.Click += (sender, e) =>
                {
                    // Открываем форму AddHotelForm с данными отеля
                    var addHotelForm = new AddHotelForm(_context, hotel, this);
                    addHotelForm.Show();
                };

                hotelPanel.Controls.Add(editButton);
            }
            else
            {
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
            }
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
                Location = new Point(24, 20),
                MinimumSize = new Size(117, 20),
                PressColor = Color.FromArgb(132, 49, 90),
                PressDepth = 0.15F,
                Size = new Size(160, 40),
                Text = "НОМЕРА",
                UseVisualStyleBackColor = false
            };
            roomsButton.Click += (sender, e) =>
            {
                var roomListingForm = new RoomListingForm(hotel, _context);
                roomListingForm.Show();
            };
            hotelPanel.Controls.Add(roomsButton);
            // Лейбл минимальной цены
            var priceLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(roomsButton.Location.X + 10, roomsButton.Bottom + 15),
                Size = new Size(150, 25),
                Text = $"от {hotel.mn_price:C0}",
                TextAlign = ContentAlignment.MiddleLeft
            };
            hotelPanel.Controls.Add(priceLabel);
            // Кнопка "Лайк"
            var likeButton = new RoundButton
            {
                BackColor = Color.FromArgb(243, 200, 220),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Emoji", 16F, FontStyle.Bold),
                MinimumSize = new Size(10, 20),
                Size = new Size(40, 40),
                Location = new Point(priceLabel.Location.X + 15, priceLabel.Bottom + 20),
                Text = "👍",
                Tag = hotel
            };
            likeButton.Click += LikeButton_Click;
            hotelPanel.Controls.Add(likeButton);

            // Кнопка "Дизлайк"
            var dislikeButton = new RoundButton
            {
                BackColor = Color.FromArgb(243, 200, 220),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Emoji", 16F, FontStyle.Bold),
                MinimumSize = new Size(10, 20),
                Size = new Size(40, 40),
                Location = new Point(likeButton.Right + 10, priceLabel.Bottom + 20),
                // Позиция кнопки
                Text = "👎",
                Tag = hotel
            };
            dislikeButton.Click += DislikeButton_Click;
            hotelPanel.Controls.Add(dislikeButton);

            // Название отеля
            var nameLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 23F, FontStyle.Regular),
                ForeColor = Color.FromArgb(243, 200, 220),
                Location = new Point(200, 20),
                Size = new Size(293, 40),
                Text = $"{hotel.stars}* {hotel.hotel_name}",
                TextAlign = ContentAlignment.MiddleLeft
            };
            hotelPanel.Controls.Add(nameLabel);

            // Синяя панель информации
            var infoPanel = new Panel
            {
                BackColor = Color.FromArgb(77, 67, 126),
                Location = new Point(200, 72),
                Size = new Size(280, 90)
            };
            // Адрес (вверху слева)
            var addressLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 10F),
                ForeColor = Color.FromArgb(230, 174, 207),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(10, 5),
                Text = hotel.address,
                TextAlign = ContentAlignment.MiddleLeft
            };
            infoPanel.Controls.Add(addressLabel);

            // Описание (между адресом и городом)
            var descLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(230, 174, 207),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(10, addressLabel.Bottom + 5),
                Text = hotel.hotel_description,
                TextAlign = ContentAlignment.MiddleLeft
            };
            infoPanel.Controls.Add(descLabel);

            // Лейбл для города (внизу справа)
            var cityLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 14F),
                ForeColor = Color.FromArgb(230, 174, 207),
                AutoSize = true,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(infoPanel.Width - 200, infoPanel.Height - 30),
                Text = $"г. {hotel.city.title}",
                TextAlign = ContentAlignment.MiddleRight
            };
            infoPanel.Controls.Add(cityLabel);

            hotelPanel.Controls.Add(infoPanel);

            // Изображение отеля
            var pictureBox = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Image = hotel.image,
                Location = new Point(510, 12),
                Size = new Size(230, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            hotelPanel.Controls.Add(pictureBox);
            // Загружаем состояние лайков/дизлайков из базы данных
            LoadHotelLikes(hotelPanel, hotel);
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
        private void LoadHotelLikes(Control container, Hotel hotel)
        {
            var user = _currentUser;

            // Проверяем, существует ли запись в таблице UserHotelLikes
            var likeRecord = _context.Likes
                .FirstOrDefault(like => like.user_id == user.user_id && like.hotel_id == hotel.hotel_id);

            if (likeRecord != null)
            {
                // Обновляем стили кнопок на основе состояния из базы данных
                UpdateButtonStyles(container, hotel, likeRecord.liked);
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
            var filteredHotels = hotels.AsQueryable();

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

            if (user.prefers_quiet_place.HasValue && user.prefers_quiet_place.Value) score++;
            if (user.prefers_quiet_place.HasValue && !user.prefers_quiet_place.Value && hotel.is_city_center) score++;

            // Учет лайков и дизлайков
            var likeRecord = _context.Likes
                .FirstOrDefault(like => like.user_id == user.user_id && like.hotel_id == hotel.hotel_id);

            if (likeRecord != null)
            {
                if (likeRecord.liked)
                    score += 3; // Лайк добавляет +3 балла
                else
                    score -= 2; // Дизлайк вычитает -2 балла
            }

            return score;
        }
        private void LikeButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null || button.Tag == null) return;

            var hotel = button.Tag as Hotel; // Получаем объект Hotel из свойства Tag
            var container = button.Parent;  // Получаем родительский контейнер (например, панель)

            // Переключаем состояние лайка
            ToggleLike(container, hotel, true); // true = Лайк
        }
        private void DislikeButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null || button.Tag == null) return;

            var hotel = button.Tag as Hotel; // Получаем объект Hotel из свойства Tag
            var container = button.Parent;  // Получаем родительский контейнер (например, панель)

            // Переключаем состояние дизлайка
            ToggleLike(container, hotel, false); // false = Дизлайк
        }
        private void ToggleLike(Control container, Hotel hotel, bool? isLike)
        {
            var user = _currentUser;

            // Проверяем, существует ли запись в таблице UserHotelLikes
            var likeRecord = _context.Likes
                .FirstOrDefault(like => like.user_id == user.user_id && like.hotel_id == hotel.hotel_id);

            if (likeRecord != null)
            {
                // Если запись уже существует и её состояние совпадает с текущим действием,
                // удаляем запись (отменяем действие).
                if (likeRecord.liked == isLike)
                {
                    _context.Likes.Remove(likeRecord);
                    isLike = null; // Сбрасываем состояние
                }
                else
                {
                    // Если запись существует, но состояние отличается, обновляем его.
                    likeRecord.liked = (bool)isLike;
                }
            }
            else
            {
                // Если записи не существует, создаем новую.
                var newLike = new UserHotelLike
                {
                    user_id = user.user_id,
                    hotel_id = hotel.hotel_id,
                    liked = (bool)isLike
                };
                _context.Likes.Add(newLike);
            }

            _context.SaveChanges();

            // Обновляем стили кнопок
            UpdateButtonStyles(container, hotel, isLike);
        }
        private void UpdateButtonStyles(Control container, Hotel hotel, bool? isLike)
        {
            var likeButton = container.Controls.OfType<RoundButton>()
                .FirstOrDefault(btn => btn.Tag as Hotel == hotel && btn.Text == "👍");
            var dislikeButton = container.Controls.OfType<RoundButton>()
                .FirstOrDefault(btn => btn.Tag as Hotel == hotel && btn.Text == "👎");

            if (likeButton != null)
            {
                likeButton.BackColor = isLike == true ? Color.FromArgb(209, 131, 170) : Color.FromArgb(243, 200, 220);
            }

            if (dislikeButton != null)
            {
                dislikeButton.BackColor = isLike == false ? Color.FromArgb(209, 131, 170) : Color.FromArgb(243, 200, 220);
            }
        }
        private void btnBooked_Click(object sender, EventArgs e)
        {

            // Создаем экземпляр формы BookedRoomsForm
            var bookedRoomsForm = new BookedRoomsForm(_currentUser, _context);

            // Показываем форму
            bookedRoomsForm.Show();
        }
        private List<User> FindSimilarUsers(User currentUser)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users
                    .Where(user => user.user_id != currentUser.user_id &&
                           ((user.prefers_sea.HasValue && currentUser.prefers_sea.HasValue && user.prefers_sea == currentUser.prefers_sea) ? 1 : 0) +
                           ((user.prefers_historical_places.HasValue && currentUser.prefers_historical_places.HasValue && user.prefers_historical_places == currentUser.prefers_historical_places) ? 1 : 0) +
                           ((user.prefers_active_rest.HasValue && currentUser.prefers_active_rest.HasValue && user.prefers_active_rest == currentUser.prefers_active_rest) ? 1 : 0) +
                           ((user.prefers_asian_cuisine.HasValue && currentUser.prefers_asian_cuisine.HasValue && user.prefers_asian_cuisine == currentUser.prefers_asian_cuisine) ? 1 : 0) +
                           ((user.prefers_quiet_place.HasValue && currentUser.prefers_quiet_place.HasValue && user.prefers_quiet_place == currentUser.prefers_quiet_place) ? 1 : 0) >= 3)
                    .ToList();
            }
        }
        private List<Hotel> GetRecommendedHotels(User currentUser)
        {
            var similarUsers = FindSimilarUsers(currentUser);

            if (similarUsers.Count == 0)
            {
                return new List<Hotel>(); // Если нет похожих пользователей, возвращаем пустой список
            }

            var recommendedHotelIds = _context.Likes
                .Where(like => like.liked == true && similarUsers.Select(u => u.user_id).Contains(like.user_id))
                .Select(like => like.hotel_id)
                .Distinct()
                .ToList();

            return _context.Hotels
                .Where(hotel => recommendedHotelIds.Contains(hotel.hotel_id))
                .ToList();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            var editForm = new UserEditForm(_currentUser, _context, _authorization)
            {
                Owner = this
            };
            editForm.ShowDialog();
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

            if (user.prefers_quiet_place.HasValue && !user.prefers_quiet_place.Value && hotel.is_city_center) score++;

            return score;
        }
        private void btnBooked_Click(object sender, EventArgs e)
        {

            // Создаем экземпляр формы BookedRoomsForm
            var bookedRoomsForm = new BookedRoomsForm();

            // Показываем форму
            bookedRoomsForm.Show();
        }
        private void AddHotelButton_Click(object sender, EventArgs e)
        {

            // Создаем пустой объект Hotel
            var emptyHotel = new Hotel();

            // Открываем форму AddHotelForm с пустым отелем
            var addHotelForm = new AddHotelForm(_context, null, this); ;
            addHotelForm.ShowDialog();
        }
    }
}