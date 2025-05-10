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
            ApplicationDbContext context = new ApplicationDbContext();
            var admin = new User
            {
                user_id = Guid.NewGuid(),
                first_name = "Admin",
                last_name = "Adminov",
                username = "admin",
                password_hash = PasswordHasher.HashPasswordAsync("123").Result,
                phone_number = "1234567890",
                role = Role.Admin,
                isfirstlogin = false
            };
            context.Users.Add(admin);
            context.SaveChanges();
            //после первого запуска закомментируй всё что выше

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Запускаем форму
            Application.Run(new AuthorizationForm());
        }
    }
}