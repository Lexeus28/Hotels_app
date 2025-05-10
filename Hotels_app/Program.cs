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
            var user = new User
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new HotelListingForm(user,context));
        }
    }
}