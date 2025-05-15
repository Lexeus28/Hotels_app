using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;

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
            // Инициализация контекста базы данных
            using (var context = new ApplicationDbContext())
            {
                // Проверяем, существует ли уже администратор
                var adminExists = context.Users.Any(u => u.role == Role.Admin);

                if (!adminExists)
                {
                    // Создаем администратора, если его нет
                    var admin = new User
                    {
                        user_id = Guid.NewGuid(),
                        first_name = "Админ",
                        last_name = "Админов",
                        username = "Admin",
                        password_hash = PasswordHasher.HashPassword("123"),
                        phone_number = "1234567890",
                        role = Role.Admin,
                        isfirstlogin = false
                    };

                    context.Users.Add(admin);
                    context.SaveChanges();
                }
            }

            // Инициализация конфигурации приложения
            ApplicationConfiguration.Initialize();

            // Запуск основной формы авторизации
            Application.Run(new AuthorizationForm());
        }
    }
}