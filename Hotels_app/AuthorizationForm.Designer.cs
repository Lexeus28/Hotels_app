namespace Hotels_app
{
    partial class AuthorizationForm
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
            btnRegister = new RoundButton();
            btnLogin = new RoundButton();
            txtPassword = new TextBox();
            txtLogin = new TextBox();
            lblHeader = new Label();
            btnClose = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(158, 157, 189);
            panelMain.Controls.Add(btnRegister);
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(txtLogin);
            panelMain.Controls.Add(lblHeader);
            panelMain.Controls.Add(btnClose);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(4, 3, 4, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(648, 346);
            panelMain.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(209, 131, 170);
            btnRegister.BorderColor = Color.Transparent;
            btnRegister.BorderRadius = 15;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRegister.ForeColor = Color.FromArgb(243, 200, 220);
            btnRegister.HoverColor = Color.FromArgb(225, 147, 186);
            btnRegister.Location = new Point(329, 223);
            btnRegister.Margin = new Padding(4, 3, 4, 3);
            btnRegister.MinimumSize = new Size(100, 46);
            btnRegister.Name = "btnRegister";
            btnRegister.Padding = new Padding(10);
            btnRegister.PressColor = Color.FromArgb(132, 49, 90);
            btnRegister.PressDepth = 0.15F;
            btnRegister.Size = new Size(224, 46);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "ЗАРЕГИСТРИРОВАТЬСЯ";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(58, 51, 92);
            btnLogin.BorderColor = Color.Transparent;
            btnLogin.BorderRadius = 15;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLogin.ForeColor = Color.FromArgb(243, 200, 220);
            btnLogin.HoverColor = Color.FromArgb(78, 71, 112);
            btnLogin.Location = new Point(93, 223);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.MinimumSize = new Size(100, 46);
            btnLogin.Name = "btnLogin";
            btnLogin.Padding = new Padding(10);
            btnLogin.PressColor = Color.FromArgb(132, 49, 90);
            btnLogin.PressDepth = 0.15F;
            btnLogin.Size = new Size(200, 46);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ВОЙТИ";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += this.btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = Color.FromArgb(243, 200, 220);
            txtPassword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPassword.ForeColor = Color.FromArgb(118, 118, 118);
            txtPassword.Location = new Point(93, 162);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.PlaceholderText = "пароль";
            txtPassword.Size = new Size(460, 26);
            txtPassword.TabIndex = 3;
            // 
            // txtLogin
            // 
            txtLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLogin.BackColor = Color.FromArgb(243, 200, 220);
            txtLogin.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLogin.ForeColor = Color.FromArgb(118, 118, 118);
            txtLogin.Location = new Point(93, 115);
            txtLogin.Margin = new Padding(4, 3, 4, 3);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "логин";
            txtLogin.Size = new Size(460, 26);
            txtLogin.TabIndex = 2;
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top;
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblHeader.ForeColor = Color.FromArgb(64, 0, 64);
            lblHeader.Location = new Point(243, 63);
            lblHeader.Margin = new Padding(4, 0, 4, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(169, 24);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "✓ АВТОРИЗАЦИЯ";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClose.Location = new Point(625, 0);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(23, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 346);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AuthorizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private Hotels_app.RoundButton btnLogin;
        private Hotels_app.RoundButton btnRegister;
    }
}