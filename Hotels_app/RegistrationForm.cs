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
                    MessageBox.Show("Имя не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (firstName.Length > 50)
                {
                    MessageBox.Show("Имя не должно превышать 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(firstName, @"^[А-ЯЁ][а-яё]*$"))
                {
                    MessageBox.Show("Имя должно начинаться с заглавной буквы и содержать только буквы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка фамилии
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("Фамилия не может быть пустой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lastName.Length > 50)
                {
                    MessageBox.Show("Фамилия не должна превышать 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(lastName, @"^[А-ЯЁ][а-яё]*$"))
                {
                    MessageBox.Show("Фамилия должна начинаться с заглавной буквы и содержать только буквы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка отчества
                if (!string.IsNullOrWhiteSpace(patronymic))
                {
                    if (!Regex.IsMatch(patronymic, @"^[А-ЯЁ][а-яё]*$"))
                    {
                        MessageBox.Show("Отчество должно начинаться с заглавной буквы и содержать только буквы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (patronymic.Length > 50)
                    {
                        MessageBox.Show("Отчество не должно превышать 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Проверка логина
                if (string.IsNullOrWhiteSpace(login))
                {
                    MessageBox.Show("Логин не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (login.Length > 50)
                {
                    MessageBox.Show("Логин не должен превышать 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка уникальности логина
                var existingUser = _context.Users.FirstOrDefault(u => u.username == login);
                if (existingUser != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка пароля
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Пароль не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка номера телефона
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    MessageBox.Show("Номер телефона не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(phoneNumber, @"^[0-9]{9,15}$"))
                {
                    MessageBox.Show("Номер телефона должен содержать цифры (9-15).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Регистрация успешно завершена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFormFields();

                this.Close();

                _authorizationForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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