using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotels_app
{
    partial class HotelListingForm
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
            panelHotels = new Panel();
            panelProfile = new Panel();
            btnDeleteAccount = new RoundButton();
            btnBooked = new RoundButton();
            txtPriceTo = new TextBox();
            lblTo = new Label();
            txtPriceFrom = new TextBox();
            lblFrom = new Label();
            lblPrice = new Label();
            txtStars = new TextBox();
            lblStars = new Label();
            txtCity = new TextBox();
            lblCity = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtSurname = new TextBox();
            lblSurname = new Label();
            lblProfile = new Label();
            panelMain.SuspendLayout();
            panelProfile.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(196, 181, 196);
            panelMain.Controls.Add(panelHotels);
            panelMain.Controls.Add(panelProfile);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(4, 3, 4, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1050, 594);
            panelMain.TabIndex = 0;
            // 
            // panelHotels
            // 
            panelHotels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelHotels.AutoScroll = true;
            panelHotels.Location = new Point(14, 14);
            panelHotels.Margin = new Padding(4, 3, 4, 3);
            panelHotels.Name = "panelHotels";
            panelHotels.Size = new Size(779, 567);
            panelHotels.TabIndex = 0;
            // 
            // panelProfile
            // 
            panelProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelProfile.BackColor = Color.FromArgb(158, 157, 189);
            panelProfile.Controls.Add(btnDeleteAccount);
            panelProfile.Controls.Add(btnBooked);
            panelProfile.Controls.Add(txtPriceTo);
            panelProfile.Controls.Add(lblTo);
            panelProfile.Controls.Add(txtPriceFrom);
            panelProfile.Controls.Add(lblFrom);
            panelProfile.Controls.Add(lblPrice);
            panelProfile.Controls.Add(txtStars);
            panelProfile.Controls.Add(lblStars);
            panelProfile.Controls.Add(txtCity);
            panelProfile.Controls.Add(lblCity);
            panelProfile.Controls.Add(txtName);
            panelProfile.Controls.Add(lblName);
            panelProfile.Controls.Add(txtSurname);
            panelProfile.Controls.Add(lblSurname);
            panelProfile.Controls.Add(lblProfile);
            panelProfile.Location = new Point(800, 14);
            panelProfile.Margin = new Padding(4, 3, 4, 3);
            panelProfile.Name = "panelProfile";
            panelProfile.Size = new Size(236, 567);
            panelProfile.TabIndex = 1;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.BackColor = Color.FromArgb(75, 21, 53);
            btnDeleteAccount.BorderColor = Color.FromArgb(223, 150, 161);
            btnDeleteAccount.BorderRadius = 15;
            btnDeleteAccount.FlatAppearance.BorderSize = 0;
            btnDeleteAccount.FlatStyle = FlatStyle.Flat;
            btnDeleteAccount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDeleteAccount.ForeColor = Color.FromArgb(243, 200, 220);
            btnDeleteAccount.HoverColor = Color.FromArgb(100, 30, 70);
            btnDeleteAccount.Location = new Point(22, 442);
            btnDeleteAccount.Margin = new Padding(4, 3, 4, 3);
            btnDeleteAccount.MinimumSize = new Size(117, 53);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.PressColor = Color.FromArgb(60, 10, 40);
            btnDeleteAccount.PressDepth = 0.15F;
            btnDeleteAccount.Size = new Size(187, 53);
            btnDeleteAccount.TabIndex = 15;
            btnDeleteAccount.Text = "удалить аккаунт";
            btnDeleteAccount.UseVisualStyleBackColor = false;
            // 
            // btnBooked
            // 
            btnBooked.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBooked.BackColor = Color.FromArgb(58, 51, 92);
            btnBooked.BorderColor = Color.Transparent;
            btnBooked.BorderRadius = 15;
            btnBooked.FlatAppearance.BorderSize = 0;
            btnBooked.FlatStyle = FlatStyle.Flat;
            btnBooked.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBooked.ForeColor = Color.FromArgb(243, 200, 220);
            btnBooked.HoverColor = Color.FromArgb(213, 140, 176);
            btnBooked.Location = new Point(23, 501);
            btnBooked.Margin = new Padding(4, 3, 4, 3);
            btnBooked.MinimumSize = new Size(117, 53);
            btnBooked.Name = "btnBooked";
            btnBooked.PressColor = Color.FromArgb(132, 49, 90);
            btnBooked.PressDepth = 0.15F;
            btnBooked.Size = new Size(187, 53);
            btnBooked.TabIndex = 14;
            btnBooked.Text = "забронированные";
            btnBooked.UseVisualStyleBackColor = false;
            // 
            // txtPriceTo
            // 
            txtPriceTo.BackColor = Color.FromArgb(243, 200, 220);
            txtPriceTo.Location = new Point(139, 401);
            txtPriceTo.Margin = new Padding(4, 3, 4, 3);
            txtPriceTo.Name = "txtPriceTo";
            txtPriceTo.Size = new Size(81, 23);
            txtPriceTo.TabIndex = 13;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ForeColor = Color.FromArgb(64, 0, 64);
            lblTo.Location = new Point(111, 404);
            lblTo.Margin = new Padding(4, 0, 4, 0);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(20, 15);
            lblTo.TabIndex = 12;
            lblTo.Text = "до";
            // 
            // txtPriceFrom
            // 
            txtPriceFrom.BackColor = Color.FromArgb(243, 200, 220);
            txtPriceFrom.Location = new Point(139, 360);
            txtPriceFrom.Margin = new Padding(4, 3, 4, 3);
            txtPriceFrom.Name = "txtPriceFrom";
            txtPriceFrom.Size = new Size(81, 23);
            txtPriceFrom.TabIndex = 11;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ForeColor = Color.FromArgb(64, 0, 64);
            lblFrom.Location = new Point(112, 363);
            lblFrom.Margin = new Padding(4, 0, 4, 0);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(19, 15);
            lblFrom.TabIndex = 10;
            lblFrom.Text = "от";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPrice.ForeColor = Color.FromArgb(64, 0, 64);
            lblPrice.Location = new Point(166, 335);
            lblPrice.Margin = new Padding(4, 0, 4, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(43, 17);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Цена";
            // 
            // txtStars
            // 
            txtStars.BackColor = Color.FromArgb(243, 200, 220);
            txtStars.Location = new Point(23, 277);
            txtStars.Margin = new Padding(4, 3, 4, 3);
            txtStars.Name = "txtStars";
            txtStars.Size = new Size(186, 23);
            txtStars.TabIndex = 8;
            // 
            // lblStars
            // 
            lblStars.AutoSize = true;
            lblStars.ForeColor = Color.FromArgb(64, 0, 64);
            lblStars.Location = new Point(20, 304);
            lblStars.Margin = new Padding(4, 0, 4, 0);
            lblStars.Name = "lblStars";
            lblStars.Size = new Size(102, 15);
            lblStars.TabIndex = 7;
            lblStars.Text = "количество звезд";
            // 
            // txtCity
            // 
            txtCity.BackColor = Color.FromArgb(243, 200, 220);
            txtCity.Location = new Point(23, 219);
            txtCity.Margin = new Padding(4, 3, 4, 3);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(186, 23);
            txtCity.TabIndex = 6;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.ForeColor = Color.FromArgb(64, 0, 64);
            lblCity.Location = new Point(23, 245);
            lblCity.Margin = new Padding(4, 0, 4, 0);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(39, 15);
            lblCity.TabIndex = 5;
            lblCity.Text = "город";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(243, 200, 220);
            txtName.Location = new Point(23, 162);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(186, 23);
            txtName.TabIndex = 4;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.ForeColor = Color.FromArgb(64, 0, 64);
            lblName.Location = new Point(23, 188);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(29, 15);
            lblName.TabIndex = 3;
            lblName.Text = "имя";
            // 
            // txtSurname
            // 
            txtSurname.BackColor = Color.FromArgb(243, 200, 220);
            txtSurname.Location = new Point(23, 104);
            txtSurname.Margin = new Padding(4, 3, 4, 3);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(186, 23);
            txtSurname.TabIndex = 2;
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.ForeColor = Color.FromArgb(64, 0, 64);
            lblSurname.Location = new Point(20, 130);
            lblSurname.Margin = new Padding(4, 0, 4, 0);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(58, 15);
            lblSurname.TabIndex = 1;
            lblSurname.Text = "фамилия";
            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblProfile.ForeColor = Color.FromArgb(64, 0, 64);
            lblProfile.Location = new Point(64, 60);
            lblProfile.Margin = new Padding(4, 0, 4, 0);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(92, 20);
            lblProfile.TabIndex = 0;
            lblProfile.Text = "✓ профиль";
            // 
            // HotelListingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 594);
            Controls.Add(panelMain);
            Margin = new Padding(4, 3, 4, 3);
            Name = "HotelListingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список отелей";
            panelMain.ResumeLayout(false);
            panelProfile.ResumeLayout(false);
            panelProfile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelHotels;
        private Panel panelProfile;
        private RoundButton btnBooked;
        private RoundButton btnDeleteAccount;
        private TextBox txtPriceTo;
        private Label lblTo;
        private TextBox txtPriceFrom;
        private Label lblFrom;
        private Label lblPrice;
        private TextBox txtStars;
        private Label lblStars;
        private TextBox txtCity;
        private Label lblCity;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtSurname;
        private Label lblSurname;
        private Label lblProfile;
    }
}