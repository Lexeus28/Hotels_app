using Hotels_app.classes;

namespace Hotels_app
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Инициализация приложения
            ApplicationConfiguration.Initialize();

            // Создаем контекст базы данных
            ApplicationDbContext context = new ApplicationDbContext();

            // Создаем новый город
            //City city = new City
            //{
            //    city_id = Guid.NewGuid(),
            //    title = "qwdqwd"
            //};

            // Создаем отель, передавая объект city
            //Hotel hotel = CreateHotel1(city);

            // Добавляем данные в базу данных
            /*context.Cities.Add(city);*/ // Добавляем город
           /* context.Hotels.Add(hotel);*/ // Добавляем отель
            //context.SaveChanges();

            // Запускаем форму
            Application.Run(new AuthorizationForm());
        }

        private static Hotel CreateHotel1(City city)
        {
            return new Hotel
            {
                hotel_id = Guid.NewGuid(),
                hotel_name = "4* Tetris Resort",
                city = city, // Используем переданный объект города
                stars = 4,
                image = Properties.Resources.кама,
                mn_price = 10000,
                mx_price = 500000,
                hotel_description = "Топ Перм",
                address = "Пермская",
                has_sea_access = false,
                has_mountain_view = false,
                has_historical_sites = false,
                offers_active_recreation = true,
                has_asian_cuisine = false,
                has_european_cuisine = true,   
                is_city_center = true
            };
        }
    }
}