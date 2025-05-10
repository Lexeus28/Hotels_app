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

            // Запускаем форму
            Application.Run(new AuthorizationForm());
        }
    }
}