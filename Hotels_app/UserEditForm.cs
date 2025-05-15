using System.Runtime.InteropServices;
namespace Hotels_app
{
    // <summary>
    ///  форма для редактирования аккаунта
    ///</summary>
    public partial class UserEditForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private readonly User _user;
        private readonly AuthorizationForm _authorization;
        private readonly ApplicationDbContext _context;

        public UserEditForm(User user, ApplicationDbContext context, AuthorizationForm authorization)
        {
            InitializeComponent();
            _user = user;
            _context = context;
            _authorization = authorization;

            txtFirstName.Text = _user.first_name;
            txtLastName.Text = _user.last_name;
            txtPatronymic.Text = _user.patronymic;
            txtPhoneNumber.Text = _user.phone_number;
            
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _user.first_name = txtFirstName.Text;
                _user.last_name = txtLastName.Text;
                _user.patronymic = txtPatronymic.Text;
                _user.phone_number = txtPhoneNumber.Text;

                try
                {
                    SavePassword();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обработке пароля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                _context.SaveChanges();

                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SavePassword()
        {
            var oldPassword = txtOldPassword.Text;
            var newPassword = txtNewPassword.Text;

            if (string.IsNullOrEmpty(oldPassword) && string.IsNullOrEmpty(newPassword))
            {
                return; 
            }

            if (string.IsNullOrEmpty(oldPassword))
            {
                throw new Exception("Пожалуйста, введите старый пароль.");
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                throw new Exception("Пожалуйста, введите новый пароль.");
            }

            var isOldPasswordCorrect = PasswordHasher.VerifyPassword(oldPassword, _user.password_hash);
            if (!isOldPasswordCorrect)
            {
                throw new Exception("Старый пароль неверен.");
            }
            var hashedNewPassword = PasswordHasher.HashPassword(newPassword);

            _user.password_hash = hashedNewPassword;

            MessageBox.Show("Пароль успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить свой аккаунт? Это действие нельзя отменить.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();

                MessageBox.Show("Аккаунт успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

                var hotelListingForm = Application.OpenForms.OfType<HotelListingForm>().FirstOrDefault();
                hotelListingForm?.Hide();
                _authorization.Show();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
