using Hotels_app.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hotels_app
{
    public partial class UserEditForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private bool isPasswordVisible = false;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private readonly User _user; // Текущий пользователь
        private readonly AuthorizationForm _authorization;
        private readonly ApplicationDbContext _context; // Контекст базы данных

        public UserEditForm(User user, ApplicationDbContext context, AuthorizationForm authorization)
        {
            InitializeComponent();
            _user = user;
            _context = context;
            _authorization = authorization;

            // Заполняем поля данными пользователя
            txtFirstName.Text = _user.first_name;
            txtLastName.Text = _user.last_name;
            txtPatronymic.Text = _user.patronymic;
            txtPhoneNumber.Text = _user.phone_number;
            
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Обновляем данные пользователя
                _user.first_name = txtFirstName.Text;
                _user.last_name = txtLastName.Text;
                _user.patronymic = txtPatronymic.Text;
                _user.phone_number = txtPhoneNumber.Text;

                // Пытаемся сохранить пароль
                try
                {
                    await SavePassword();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обработке пароля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Останавливаем выполнение, если возникла ошибка
                }

                // Сохраняем изменения в базе данных
                _context.SaveChanges();

                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Закрываем форму с результатом OK
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task SavePassword()
        {
            // Получаем значения из текстовых полей
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;

            // Если оба поля пустые, пользователь не хочет менять пароль
            if (string.IsNullOrEmpty(oldPassword) && string.IsNullOrEmpty(newPassword))
            {
                return; // Просто выходим из метода без изменений
            }

            // Если пользователь хочет изменить пароль, проверяем, что он ввел старый пароль
            if (string.IsNullOrEmpty(oldPassword))
            {
                throw new Exception("Пожалуйста, введите старый пароль.");
            }

            // Проверяем, что новый пароль не пустой
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new Exception("Пожалуйста, введите новый пароль.");
            }

            // Проверяем, что старый пароль верный
            bool isOldPasswordCorrect = await PasswordHasher.VerifyPasswordAsync(oldPassword, _user.password_hash);
            if (!isOldPasswordCorrect)
            {
                throw new Exception("Старый пароль неверен.");
            }

            // Хешируем новый пароль
            string hashedNewPassword = await PasswordHasher.HashPasswordAsync(newPassword);

            // Обновляем пароль пользователя
            _user.password_hash = hashedNewPassword;

            MessageBox.Show("Пароль успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            // Показываем диалоговое окно с предупреждением
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить свой аккаунт? Это действие нельзя отменить.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Удаляем аккаунт из базы данных
                _context.Users.Remove(_user);
                _context.SaveChanges();

                // Показываем сообщение об успешном удалении
                MessageBox.Show("Аккаунт успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Закрываем форму редактирования
                this.Close();

                // Скрываем форму HotelListing
                var hotelListingForm = Application.OpenForms.OfType<HotelListingForm>().FirstOrDefault();
                hotelListingForm?.Hide();

                // Перенаправляем пользователя на форму авторизации
                _authorization.Show();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Закрываем форму без сохранения изменений
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
