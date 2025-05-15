using Hotels_app.Properties;
using System.Text.RegularExpressions;

namespace Hotels_app
{
    // <summary>
    ///  форма регистрации
    ///</summary>
    public partial class RegistrationForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthorizationForm _authorizationForm;

        public RegistrationForm(AuthorizationForm authorizationForm, ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _authorizationForm = authorizationForm;

            btnRegister.Click += btnRegister_Click;
            btnClose.Click += (s, e) => this.Close();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var firstName = txtFirstName.Text.Trim();
                var lastName = txtLastName.Text.Trim();
                var patronymic = txtPatronymic.Text.Trim();
                var login = txtLogin.Text.Trim();
                var password = txtPassword.Text.Trim();
                var phoneNumber = txtPhoneNumber.Text.Trim();

                // Проверка имени
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    MessageBox.Show(Resources.Error_EmptyName, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (firstName.Length > 50)
                {
                    MessageBox.Show(Resources.Error_LongName, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(firstName, @"^[А-ЯЁ][а-яё]*$"))
                {
                    MessageBox.Show(Resources.Error_WrongSimbolsName, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка фамилии
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show(Resources.Error_EmptyLastname, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lastName.Length > 50)
                {
                    MessageBox.Show(Resources.Error_LongLastName, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(lastName, @"^[А-ЯЁ][а-яё]*$"))
                {
                    MessageBox.Show(Resources.Error_WrongSymbolsLastname, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка отчества
                if (!string.IsNullOrWhiteSpace(patronymic))
                {
                    if (!Regex.IsMatch(patronymic, @"^[А-ЯЁ][а-яё]*$"))
                    {
                        MessageBox.Show(Resources.Error_WrongSymbolsPatronomyc, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (patronymic.Length > 50)
                    {
                        MessageBox.Show(Resources.Error_LongPatronomyc, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Проверка логина
                if (string.IsNullOrWhiteSpace(login))
                {
                    MessageBox.Show(Resources.Error_EmptyUserName, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (login.Length > 50)
                {
                    MessageBox.Show(Resources.Error_LongUserName, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                // Проверка уникальности логина
                var existingUser = _context.Users.FirstOrDefault(u => u.username == login);
                if (existingUser != null)
                {
                    MessageBox.Show(Resources.Error_ExistingUserName, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка пароля
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show(Resources.Error_EmptyPassword, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (password.Length < 6)
                {
                    MessageBox.Show(Resources.Error_ShortPassword, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка номера телефона
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    MessageBox.Show(Resources.Error_EmptyPhoneNumber, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(phoneNumber, @"^[0-9]{9,15}$"))
                {
                    MessageBox.Show(Resources.Error_WrongSymbolsPhoneNumber, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создание нового пользователя
                var newUser = new User
                {
                    first_name = firstName,
                    last_name = lastName,
                    patronymic = patronymic,
                    username = login,
                    password_hash = PasswordHasher.HashPassword(password),
                    phone_number = phoneNumber
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();

                MessageBox.Show(Resources.Success_Registration, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFormFields();

                this.Close();

                _authorizationForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.Error_Mistake} {ex.Message}", Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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