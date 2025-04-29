using Hotels_app.classes;

namespace Hotels_app
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ApplicationDbContext context = new ApplicationDbContext();
            // Создаем нового пользователя
            User user = new User
            {
                user_id = Guid.NewGuid(), // Генерируем уникальный идентификатор
                first_name = "Иван",
                last_name = "Иванов",
                patronymic = "Иванович",
                username = "ivan212fкаeаrуk34f4",
                password_hash = "hashed_password_1", // Хэшированный пароль
                phone_number = "+79001234567"
            };


            // Сохраняем нового пользователя в базу данных
            context.Hotels.Add(CreateHotel1());
            context.Users.Add(user);
            context.SaveChanges();
            Application.Run(new HotelListingForm(user, context));
        }
        private static Hotel CreateHotel1()
        {
            return new Hotel
            {
                hotel_id = Guid.NewGuid(),
                hotel_name = "Халупа",
                country = "Россия",
                city = "Краснодар",
                stars = 4,
                image = Properties.Resources.кама,
                mn_price = 10000,
                mx_price = 500000,
                hotel_description = "Для самых искушенных",
                address = "Тверкская",
                has_sea_access = true,
                has_mountain_view = true,
                has_historical_sites = true,
                offers_active_recreation = true,
                has_asian_cuisine = true,
                has_european_cuisine = false,
                is_quiet_location = true,
                is_city_center = false
            };
        }
    }
}