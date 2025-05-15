using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels_app
{
    public partial class AuthorizationForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // Поле для хранения контекста базы данных
        private readonly ApplicationDbContext _context;

        public AuthorizationForm()
        {
            InitializeComponent();

            // Инициализация контекста базы данных
            _context = new ApplicationDbContext();

            // Подписываемся на события
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
            // Проверяем пользователя в БД
            var user = _context.Users.FirstOrDefault(u => u.username == login);

            if (user == null)
            {
                MessageBox.Show("Пользователь с таким логином не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (PasswordHasher.VerifyPassword(password, user.password_hash))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateUser(login, password))
            {
                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Находим пользователя по логину
                var user = _context.Users.FirstOrDefault(u => u.username == login);

                // Проверяем, является ли это первым входом
                if (user.isfirstlogin)
                {
                    // Открываем форму HotelListingForm
                    var hotelListingForm = new HotelListingForm(user, _context, this);

                    // Предлагаем пройти анкету
                    var result = MessageBox.Show(
                        "Вы впервые авторизуетесь. Хотите пройти анкету?",
                        "Анкета",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Открываем форму QuestionForm поверх HotelListingForm
                        var questionForm = new QuestionForm(user, _context);
                        questionForm.ShowDialog(); // ShowDialog делает форму модальной
                    }

                    // Обновляем флаг IsFirstLogin
                    user.isfirstlogin = false;
                    _context.SaveChanges();
                }

                // Открываем форму HotelListingForm
                var hotelListing = new HotelListingForm(user, _context, this);
                hotelListing.Show();

                this.Hide();
                ClearFormFields();
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Передаем контекст в форму регистрации
            RegistrationForm registrationForm = new RegistrationForm(this, _context);
            registrationForm.Show();
            this.Hide();
            this.ClearFormFields();
        }

        public void ClearFormFields()
        {
            txtLogin.Clear();
            txtPassword.Clear();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Освобождаем контекст при закрытии формы
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}