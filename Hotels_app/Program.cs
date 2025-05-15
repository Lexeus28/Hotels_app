namespace Hotels_app
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ������������� ��������� ���� ������
            using (var context = new ApplicationDbContext())
            {
                // ���������, ���������� �� ��� �������������
                var adminExists = context.Users.Any(u => u.role == Role.Admin);

                if (!adminExists)
                {
                    // ������� ��������������, ���� ��� ���
                    var admin = new User
                    {
                        user_id = Guid.NewGuid(),
                        first_name = "�����",
                        last_name = "�������",
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

            // ������������� ������������ ����������
            ApplicationConfiguration.Initialize();

            // ������ �������� ����� �����������
            Application.Run(new AuthorizationForm());
        }
    }
}