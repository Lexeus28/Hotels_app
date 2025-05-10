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
            ApplicationDbContext context = new ApplicationDbContext();

            // Поиск пользователя по username
            string usernameToFind = "Lexey"; // Заданный username
            var user = context.Users
                .FirstOrDefault(u => u.username == usernameToFind);

            if (user == null)
            {
                // Если пользователь не найден, создаем нового пользователя
                user = new User
                {
                    user_id = Guid.NewGuid(),
                    first_name = "Леша",
                    last_name = "Габов",
                    username = "Lexey",
                    password_hash = PasswordHasher.HashPasswordAsync("100606").Result,
                    phone_number = "89824399141",
                    isfirstlogin = false
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            // Запуск приложения с найденным или созданным пользователем
            ApplicationConfiguration.Initialize();
            Application.Run(new HotelListingForm(user, context));
        }
    }
}