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

            // ������� ����� �����
            //City city = new City
            //{
            //    city_id = Guid.NewGuid(),
            //    title = "qwdqwd"
            //};

            // ������� �����, ��������� ������ city
            //Hotel hotel = CreateHotel1(city);

            // ��������� ������ � ���� ������
            /*context.Cities.Add(city);*/ // ��������� �����
           /* context.Hotels.Add(hotel);*/ // ��������� �����
            //context.SaveChanges();

            // ��������� �����
            Application.Run(new AuthorizationForm());
        }

        private static Hotel CreateHotel1(City city)
        {
            return new Hotel
            {
                hotel_id = Guid.NewGuid(),
                hotel_name = "4* Tetris Resort",
                city = city, // ���������� ���������� ������ ������
                stars = 4,
                image = Properties.Resources.����,
                mn_price = 10000,
                mx_price = 500000,
                hotel_description = "��� ����",
                address = "��������",
                has_sea_access = false,
                has_mountain_view = false,
                has_historical_sites = false,
                offers_active_recreation = true,
                has_asian_cuisine = false,
                has_european_cuisine = true,   
                is_city_center = true
            };
        }
    }
}