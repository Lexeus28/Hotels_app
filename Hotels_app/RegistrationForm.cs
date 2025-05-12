using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hotels_app
{
    public partial class RegistrationForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthorizationForm _authorizationForm;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public RegistrationForm(AuthorizationForm authorizationForm,ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _authorizationForm = authorizationForm;
            panelMain.MouseDown += Panel_MouseDown;
            lblTitle.MouseDown += Panel_MouseDown;
            btnClose.Click += (s, e) => this.Close();

            // Привязка события к кнопке "Зарегистрироваться"
            btnRegister.Click += btnRegister_Click;
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Зарегистрироваться"
        /// </summary>
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // Сбор данных из текстовых полей
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string patronymic = txtPatronymic.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();

            // Валидация: проверка, что все обязательные поля заполнены
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Все поля обязательны для заполнения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Проверка, что логин уникален
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.username == login);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Создание нового пользователя
            var newUser = new User
            {
                first_name = firstName,
                last_name = lastName,
                patronymic = patronymic,
                username = login,
                password_hash = await PasswordHasher.HashPasswordAsync(password),
                phone_number = phoneNumber
            };

            // Сохранение пользователя в базу данных

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            MessageBox.Show("Регистрация успешно завершена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Очистка полей после успешной регистрации
            ClearFormFields();

            // Закрыть текущую форму
            this.Close();

            // Открыть форму авторизации
            _authorizationForm.Show();
        }

        /// <summary>
        /// Очистка полей формы
        /// </summary>
        private void ClearFormFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPatronymic.Clear();
            txtLogin.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
        }
    }
}