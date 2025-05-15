using System.Runtime.InteropServices;
using Hotels_app.Properties;
namespace Hotels_app
{
    // <summary>
    ///  форма для редактирования аккаунта
    ///</summary>
    public partial class UserEditForm : Form
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
                var newPassword = txtNewPassword.Text;

                try
                {
                    if (newPassword.Length < 6 && newPassword.Length != 0)
                    {
                        MessageBox.Show(Resources.Error_ShortPassword, Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    SavePassword();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Resources.Error_PasswordValidation} {ex.Message}",Resources.Error_mes , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                _context.SaveChanges();

                MessageBox.Show(Resources.Success_SavingData, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.Error_Mistake} {ex.Message}", Resources.Error_mes, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                throw new Exception(Resources.Error_EmptyOldPassword);
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                throw new Exception(Resources.Error_EmptyNewPassword);
            }

            var isOldPasswordCorrect = PasswordHasher.VerifyPassword(oldPassword, _user.password_hash);
            if (!isOldPasswordCorrect)
            {
                throw new Exception(Resources.Error_WrongOldPassword);
            }
            var hashedNewPassword = PasswordHasher.HashPassword(newPassword);

            _user.password_hash = hashedNewPassword;

            MessageBox.Show(Resources.Success_PasswordChange, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                Resources.Confirm_DeleteAccount,
                Resources.Title_DeleteConfirmation,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();

                MessageBox.Show(Resources.Success_DeletingAccount, Resources.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
