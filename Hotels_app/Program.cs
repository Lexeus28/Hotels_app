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
            // ������������� ��������� ���� ������
            ApplicationDbContext context = new ApplicationDbContext();

            // ����� ������������ �� username
            string usernameToFind = "Lexey"; // �������� username
            var user = context.Users
                .FirstOrDefault(u => u.username == usernameToFind);

            if (user == null)
            {
                // ���� ������������ �� ������, ������� ������ ������������
                user = new User
                {
                    user_id = Guid.NewGuid(),
                    first_name = "����",
                    last_name = "�����",
                    username = "Lexey",
                    password_hash = PasswordHasher.HashPasswordAsync("100606").Result,
                    phone_number = "89824399141",
                    isfirstlogin = false
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            // ������ ���������� � ��������� ��� ��������� �������������
            ApplicationConfiguration.Initialize();
            Application.Run(new HotelListingForm(user, context));
        }
    }
}