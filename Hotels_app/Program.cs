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
            // ������������� ����������
            ApplicationConfiguration.Initialize();

            // ������� �������� ���� ������
            ApplicationDbContext context = new ApplicationDbContext();

            // ��������� �����
            Application.Run(new AuthorizationForm());
        }
    }
}