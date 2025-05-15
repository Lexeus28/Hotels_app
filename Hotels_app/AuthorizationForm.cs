using Hotels_app.Properties;
using System.Runtime.InteropServices;
namespace Hotels_app
{
    // <summary>
    /// Форма авторизации
    ///</summary>
    public partial class AuthorizationForm : Form
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

        public AuthorizationForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            panelMain.MouseDown += Panel_MouseDown;
            lblHeader.MouseDown += Panel_MouseDown;
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

        private bool ValidateUser(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.username == login);

            if (user == null)
            {
                MessageBox.Show(Resources.Error_LoginNotFound, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (PasswordHasher.VerifyPassword(password, user.password_hash))
            {
                return true;
            }
            else
            {
                MessageBox.Show(Resources.Error_WrongPassword, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = txtLogin.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(Resources.Error_PasswordOrLoginIsEmpty, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateUser(login, password))
            {
                MessageBox.Show(Resources.Success_Authorization, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                var user = _context.Users.FirstOrDefault(u => u.username == login);
                if (user.isfirstlogin)
                {
                    var hotelListingForm = new HotelListingForm(user, _context, this);
                    var result = MessageBox.Show(
                        Resources.DoYouWantQuestionnaire,
                        Resources.Qustionnaire,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var questionForm = new QuestionForm(user, _context);
                        questionForm.ShowDialog();
                    }
                    user.isfirstlogin = false;
                    _context.SaveChanges();
                }
                var hotelListing = new HotelListingForm(user, _context, this);
                hotelListing.Show();

                this.Hide();
                ClearFormFields();
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(this, _context);
            registrationForm.Show();
            this.Hide();
            this.ClearFormFields();
        }
        private void ClearFormFields()
        {
            txtLogin.Clear();
            txtPassword.Clear();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}