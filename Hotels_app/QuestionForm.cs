using Hotels_app.Properties;
using System.Runtime.InteropServices;
namespace Hotels_app
{
    // <summary>
    ///  форма анкеты
    ///</summary>
    public partial class QuestionForm : Form
    {
        /// <summary>
        /// Импортирует функцию SendMessage из user32.dll.
        /// Используется для отправки сообщений оконной системе Windows.
        /// </summary>
        /// <param name="hWnd">Дескриптор окна, которому отправляется сообщение.</param>
        /// <param name="Msg">Тип сообщения.</param>
        /// <param name="wParam">Дополнительный параметр сообщения.</param>
        /// <param name="lParam">Дополнительный параметр сообщения.</param>
        /// <returns>Результат выполнения сообщения.</returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Импортирует функцию ReleaseCapture из user32.dll.
        /// Используется для освобождения захвата мыши на элементе управления или окне.
        /// </summary>
        /// <returns>Возвращает true, если операция успешна; иначе false.</returns>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private readonly ApplicationDbContext _context;
        private readonly User _currentUser;
        public QuestionForm(User user, ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _currentUser = user;
            panelMain.MouseDown += Panel_MouseDown;
            lblTitle.MouseDown += Panel_MouseDown;
            btnClose.Click += (s, e) => this.Close();

        }
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Сбор данных из формы
            _currentUser.prefers_sea = rbSea.Checked; // Море (true) или Горы (false)
            _currentUser.prefers_historical_places = rbHistoricalPlacesYes.Checked; // Исторические места (да/нет)
            _currentUser.prefers_active_rest = rbActiveRecreationYes.Checked; // Активный отдых (да/нет)
            _currentUser.prefers_asian_cuisine = rbAsianCuisine.Checked; // Азиатская кухня (true) или Европейская (false)
            _currentUser.prefers_quiet_place = rbQuietLocation.Checked; // Тихая местность (true) или Шумный город (false)

            _context.Users.Update(_currentUser);
            _context.SaveChanges();

            MessageBox.Show(Resources.Success_SaveQuestionnaire, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Owner is HotelListingForm hotelListingForm)
            {
                hotelListingForm.ReloadHotels();
            }
            this.Close();
        }
    }
}

