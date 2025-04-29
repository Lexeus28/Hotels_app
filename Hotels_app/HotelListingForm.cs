using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Hotels_app
{
    public partial class HotelListingForm : Form
    {
        // Список отелей
        private List<Hotel> hotels;

        public HotelListingForm(ApplicationDbContext context)
        {
            InitializeComponent();
            LoadHotelsData(); // Загружаем данные об отелях
            LoadHotels();      // Отображаем отели
        }

        /// <summary>
        /// Загрузка данных об отелях
        /// </summary>
        private void LoadHotelsData()
        {
            hotels = new List<Hotel>
            {
                new Hotel
                {
                    hotel_name = "TETRIS RESORT",
                    address = "ул. Парижская Коммуна д.64",
                    hotel_description = "Прекрасное место для отдыха",
                    hasSeaAccess = true,
                    stars = 5
                },
                new Hotel
                {
                    hotel_name = "SUNSET INN",
                    address = "ул. Ленина д.12",
                    hotel_description = "Идеально для семейного отдыха",
                    hasMountainView = true,
                    stars = 4
                },
                new Hotel
                {
                    hotel_name = "MOUNTAIN VIEW",
                    address = "ул. Горная д.3",
                    hotel_description = "Незабываемые виды на горы",
                    offersActiveRecreation = true,
                    stars = 3
                },
               new Hotel
                {
                    hotel_name = "OVERDRIIIIIVE",
                    address = "ул. Комарова д.3",
                    hotel_description = "Вкусите хамона",
                    offersActiveRecreation = true,
                    stars = 5
                }
            };
        }

        /// <summary>
        /// Создание и отображение панелей для отелей
        /// </summary>
        private void LoadHotels()
        {
            panelHotels.Controls.Clear();
            panelHotels.AutoScroll = true;

            int verticalOffset = 13; // Начальный отступ

            foreach (var hotel in hotels)
            {
                var hotelPanel = CreateHotelPanel(hotel);

                hotelPanel.Location = new Point(4, verticalOffset); // Отступ слева
                panelHotels.Controls.Add(hotelPanel);

                verticalOffset += hotelPanel.Height + 7; // Межпанельный отступ
            }
        }

        /// <summary>
        /// Создание панели для одного отеля
        /// </summary>
        /// <param name="hotel">Объект класса Hotel</param>
        /// <returns>Панель с данными об отеле</returns>
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
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204),
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
            hotelPanel.Controls.Add(roomsButton);

            // Название отеля
            var nameLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 204),
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
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
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
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 204),
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
                Image = Properties.Resources.кама, // Используем ресурс по умолчанию
                Location = new Point(510, 12),
                Size = new Size(230, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            hotelPanel.Controls.Add(pictureBox);

            return hotelPanel;
        }
    }
}