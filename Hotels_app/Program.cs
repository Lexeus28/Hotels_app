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
            ApplicationDbContext context = new ApplicationDbContext();
            var admin = new User
            {
                user_id = Guid.NewGuid(),
                first_name = "Admin",
                last_name = "Adminov",
                username = "admin",
                password_hash = "hashed_password", // Замените на реальный хэш пароля
                phone_number = "1234567890",
                role = Role.Admin, // Устанавливаем роль администратора
                isfirstlogin = false // Первый вход выполнен
            };
            context.users.add(admin);
            context.savechanges();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new HotelListingForm(admin,context));
        }
    }
}