using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotels_app.classes;
using Microsoft.EntityFrameworkCore;

namespace Hotels_app
{
    public partial class RegistrationForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthorizationForm _authorizationForm;

        public RegistrationForm(AuthorizationForm authorizationForm, ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            _authorizationForm = authorizationForm;

            // Привязка событий
            btnRegister.Click += btnRegister_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Зарегистрироваться"
        /// </summary>
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Сбор данных из текстовых полей
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string patronymic = txtPatronymic.Text.Trim();
                string login = txtLogin.Text.Trim();
                string password = txtPassword.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();

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
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.username == login);
                if (existingUser != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка пароля
                if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                {
                    MessageBox.Show("Пароль не может быть пустым и быть меньше 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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