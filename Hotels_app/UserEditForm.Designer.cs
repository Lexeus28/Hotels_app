namespace Hotels_app
{
    partial class UserEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMain = new Panel();
            btnDeleteAccount = new RoundButton();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            btnSave = new RoundButton();
            txtPatronymic = new TextBox();
            lblPatronymic = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtNewPassword = new TextBox();
            lblNewPassword = new Label();
            txtOldPassword = new TextBox();
            lblOldPassword = new Label();
            lblTitle = new Label();
            btnClose = new Button();
            btntoggleNewPassword = new PasswordToggleButton(txtNewPassword);
            btntoggleOldPassword = new PasswordToggleButton(txtOldPassword);
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(158, 157, 189);
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(btnDeleteAccount);
            panelMain.Controls.Add(txtPhoneNumber);
            panelMain.Controls.Add(lblPhoneNumber);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(txtPatronymic);
            panelMain.Controls.Add(lblPatronymic);
            panelMain.Controls.Add(txtFirstName);
            panelMain.Controls.Add(lblFirstName);
            panelMain.Controls.Add(txtLastName);
            panelMain.Controls.Add(lblLastName);
            panelMain.Controls.Add(txtNewPassword);
            panelMain.Controls.Add(lblNewPassword);
            panelMain.Controls.Add(txtOldPassword);
            panelMain.Controls.Add(lblOldPassword);
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(btnClose);
            panelMain.Controls.Add(btntoggleOldPassword);
            panelMain.Controls.Add(btntoggleNewPassword);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(414, 381);
            panelMain.TabIndex = 0;
            panelMain.MouseDown += Panel_MouseDown;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.BackColor = Color.FromArgb(75, 21, 53);
            btnDeleteAccount.BorderColor = Color.FromArgb(223, 150, 161);
            btnDeleteAccount.BorderRadius = 15;
            btnDeleteAccount.FlatAppearance.BorderSize = 0;
            btnDeleteAccount.FlatStyle = FlatStyle.Flat;
            btnDeleteAccount.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDeleteAccount.ForeColor = Color.FromArgb(243, 200, 220);
            btnDeleteAccount.HoverColor = Color.FromArgb(100, 30, 70);
            btnDeleteAccount.Location = new Point(50, 330);
            btnDeleteAccount.MinimumSize = new Size(50, 20);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.PressColor = Color.FromArgb(60, 10, 40);
            btnDeleteAccount.PressDepth = 0.15F;
            btnDeleteAccount.Size = new Size(153, 38);
            btnDeleteAccount.TabIndex = 16;
            btnDeleteAccount.Text = "УДАЛИТЬ АККАУНТ";
            btnDeleteAccount.UseVisualStyleBackColor = false;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BackColor = Color.FromArgb(243, 200, 220);
            txtPhoneNumber.BorderStyle = BorderStyle.None;
            txtPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(50, 270);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(302, 19);
            txtPhoneNumber.TabIndex = 13;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhoneNumber.ForeColor = Color.FromArgb(64, 0, 64);
            lblPhoneNumber.Location = new Point(50, 292);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(99, 15);
            lblPhoneNumber.TabIndex = 12;
            lblPhoneNumber.Text = "номер телефона";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(209, 131, 170);
            btnSave.BorderColor = Color.Transparent;
            btnSave.BorderRadius = 15;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.FromArgb(243, 200, 220);
            btnSave.HoverColor = Color.FromArgb(225, 147, 186);
            btnSave.Location = new Point(225, 330);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.MinimumSize = new Size(50, 20);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(10);
            btnSave.PressColor = Color.FromArgb(132, 49, 90);
            btnSave.PressDepth = 0.15F;
            btnSave.Size = new Size(127, 38);
            btnSave.TabIndex = 5;
            btnSave.Text = "СОХРАНИТЬ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtPatronymic
            // 
            txtPatronymic.BackColor = Color.FromArgb(243, 200, 220);
            txtPatronymic.BorderStyle = BorderStyle.None;
            txtPatronymic.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPatronymic.Location = new Point(50, 230);
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(302, 19);
            txtPatronymic.TabIndex = 11;
            // 
            // lblPatronymic
            // 
            lblPatronymic.AutoSize = true;
            lblPatronymic.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPatronymic.ForeColor = Color.FromArgb(64, 0, 64);
            lblPatronymic.Location = new Point(50, 252);
            lblPatronymic.Name = "lblPatronymic";
            lblPatronymic.Size = new Size(56, 15);
            lblPatronymic.TabIndex = 10;
            lblPatronymic.Text = "отчество";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(243, 200, 220);
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(50, 190);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(302, 19);
            txtFirstName.TabIndex = 9;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.ForeColor = Color.FromArgb(64, 0, 64);
            lblFirstName.Location = new Point(52, 212);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(29, 15);
            lblFirstName.TabIndex = 8;
            lblFirstName.Text = "имя";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(243, 200, 220);
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(50, 150);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(302, 19);
            txtLastName.TabIndex = 7;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.ForeColor = Color.FromArgb(64, 0, 64);
            lblLastName.Location = new Point(50, 172);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(58, 15);
            lblLastName.TabIndex = 6;
            lblLastName.Text = "фамилия";
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.FromArgb(243, 200, 220);
            txtNewPassword.BorderStyle = BorderStyle.None;
            txtNewPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(199, 114);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '•';
            txtNewPassword.Size = new Size(153, 19);
            txtNewPassword.TabIndex = 5;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPassword.ForeColor = Color.FromArgb(64, 0, 64);
            lblNewPassword.Location = new Point(50, 103);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(136, 30);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "новый пароль\n(минимум 6 символов)";
            // 
            // txtOldPassword
            // 
            txtOldPassword.BackColor = Color.FromArgb(243, 200, 220);
            txtOldPassword.BorderStyle = BorderStyle.None;
            txtOldPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOldPassword.Location = new Point(199, 78);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(153, 19);
            txtOldPassword.TabIndex = 3;
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOldPassword.ForeColor = Color.FromArgb(64, 0, 64);
            lblOldPassword.Location = new Point(50, 67);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(92, 30);
            lblOldPassword.TabIndex = 2;
            lblOldPassword.Text = "введите старый\nпароль";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(64, 0, 64);
            lblTitle.Location = new Point(133, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(144, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "✓ редактирование";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(64, 0, 64);
            btnClose.Location = new Point(383, -1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 32);
            btnClose.TabIndex = 0;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btntoggleOldPassword
            // 
            btntoggleOldPassword.Location = new Point(txtOldPassword.Right + 5, txtOldPassword.Top - 5);
            btntoggleOldPassword.Name = "btntoggleOldPassword";
            // 
            // btntoggleNewPassword
            // 
            btntoggleNewPassword.Location = new Point(txtNewPassword.Right + 5, txtNewPassword.Top - 5);
            btntoggleNewPassword.Name = "btntoggleNewPassword";
            // 
            // UserEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 381);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.Label lblPatronymic;
        private Hotels_app.RoundButton btnSave;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private RoundButton btnDeleteAccount;
        private PasswordToggleButton btntoggleNewPassword;
        private PasswordToggleButton btntoggleOldPassword;
    }
}