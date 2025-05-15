using Hotels_app.Properties;

namespace Hotels_app
{
    partial class RegistrationForm
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
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            btnRegister = new RoundButton();
            txtPatronymic = new TextBox();
            lblPatronymic = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtLogin = new TextBox();
            lblLogin = new Label();
            lblTitle = new Label();
            btnClose = new Button();
            btntogglePassword = new PasswordToggleButton(txtPassword);
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(158, 157, 189);
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(txtPhoneNumber);
            panelMain.Controls.Add(lblPhoneNumber);
            panelMain.Controls.Add(btnRegister);
            panelMain.Controls.Add(txtPatronymic);
            panelMain.Controls.Add(lblPatronymic);
            panelMain.Controls.Add(txtFirstName);
            panelMain.Controls.Add(lblFirstName);
            panelMain.Controls.Add(txtLastName);
            panelMain.Controls.Add(lblLastName);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(txtLogin);
            panelMain.Controls.Add(lblLogin);
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(btnClose);
            panelMain.Controls.Add(btntogglePassword);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(396, 368);
            panelMain.TabIndex = 0;
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
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(209, 131, 170);
            btnRegister.BorderColor = Color.Transparent;
            btnRegister.BorderRadius = 15;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRegister.ForeColor = Color.FromArgb(243, 200, 220);
            btnRegister.HoverColor = Color.FromArgb(225, 147, 186);
            btnRegister.Location = new Point(170, 310);
            btnRegister.Margin = new Padding(4, 3, 4, 3);
            btnRegister.MinimumSize = new Size(50, 23);
            btnRegister.Name = "btnRegister";
            btnRegister.Padding = new Padding(10);
            btnRegister.PressColor = Color.FromArgb(132, 49, 90);
            btnRegister.PressDepth = 0.15F;
            btnRegister.Size = new Size(182, 39);
            btnRegister.TabIndex = 5;
            btnRegister.Text = Resources.TextRegister;
            btnRegister.UseVisualStyleBackColor = false;
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
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(243, 200, 220);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(199, 114);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(153, 19);
            txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(64, 0, 64);
            lblPassword.Location = new Point(50, 103);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(136, 30);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "пароль\n(минимум 6 символов)";
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.FromArgb(243, 200, 220);
            txtLogin.BorderStyle = BorderStyle.None;
            txtLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogin.Location = new Point(199, 78);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(153, 19);
            txtLogin.TabIndex = 3;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.FromArgb(64, 0, 64);
            lblLogin.Location = new Point(50, 67);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(136, 30);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "логин\n(минимум 6 символов)";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(64, 0, 64);
            lblTitle.Location = new Point(133, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(116, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "✓ регистрация";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(64, 0, 64);
            btnClose.Location = new Point(365, -1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 32);
            btnClose.TabIndex = 0;
            btnClose.Text = Resources.TextX;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btntogglePassword
            // 
            btntogglePassword.BackColor = Color.FromArgb(158, 157, 189);
            btntogglePassword.FlatStyle = FlatStyle.Flat;
            btntogglePassword.Location = new Point(358, 109);
            btntogglePassword.Name = "btntogglePassword";
            btntogglePassword.Size = new Size(30, 30);
            btntogglePassword.TabIndex = 14;
            btntogglePassword.UseVisualStyleBackColor = false;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 368);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistrationForm";
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
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.Label lblPatronymic;
        private Hotels_app.RoundButton btnRegister;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private PasswordToggleButton btntogglePassword;
    }
}