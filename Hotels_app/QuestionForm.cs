using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotels_app.classes;

namespace Hotels_app
{
    public partial class QuestionForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

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

            // Обновление данных в базе
            _context.Users.Update(_currentUser);
            _context.SaveChanges();

            MessageBox.Show("Анкета успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Owner is HotelListingForm hotelListingForm)
            {
                hotelListingForm.ReloadHotels();
            }

            // Закрытие формы после сохранения
            this.Close();
        }
    }
}

