using Hotels_app.Properties;
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
            BtnOpenQuestionnaire = new RoundButton();
            btnEditAccount = new RoundButton();
            btnBooked = new RoundButton();
            txtPriceTo = new TextBox();
            lblTo = new Label();
            txtPriceFrom = new TextBox();
            lblFrom = new Label();
            lblPrice = new Label();
            cmbStars = new ComboBox();
            lblStars = new Label();
            cmbCity = new ComboBox();
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
            panelMain.BackColor = Color.FromArgb(196, 171, 195);
            panelMain.Controls.Add(panelHotels);
            panelMain.Controls.Add(panelProfile);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1050, 594);
            panelMain.TabIndex = 0;
            // 
            // panelHotels
            // 
            panelHotels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelHotels.AutoScroll = true;
            panelHotels.Location = new Point(14, 14);
            panelHotels.Name = "panelHotels";
            panelHotels.Size = new Size(779, 567);
            panelHotels.TabIndex = 0;
            // 
            // panelProfile
            // 
            panelProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelProfile.BackColor = Color.FromArgb(158, 157, 189);
            panelProfile.Controls.Add(BtnOpenQuestionnaire);
            panelProfile.Controls.Add(btnEditAccount);
            panelProfile.Controls.Add(btnBooked);
            panelProfile.Controls.Add(txtPriceTo);
            panelProfile.Controls.Add(lblTo);
            panelProfile.Controls.Add(txtPriceFrom);
            panelProfile.Controls.Add(lblFrom);
            panelProfile.Controls.Add(lblPrice);
            panelProfile.Controls.Add(cmbStars);
            panelProfile.Controls.Add(lblStars);
            panelProfile.Controls.Add(cmbCity);
            panelProfile.Controls.Add(lblCity);
            panelProfile.Controls.Add(txtName);
            panelProfile.Controls.Add(lblName);
            panelProfile.Controls.Add(txtSurname);
            panelProfile.Controls.Add(lblSurname);
            panelProfile.Controls.Add(lblProfile);
            panelProfile.Location = new Point(800, 14);
            panelProfile.Name = "panelProfile";
            panelProfile.Size = new Size(236, 567);
            panelProfile.TabIndex = 1;
            // 
            // BtnOpenQuestionnaire
            // 
            BtnOpenQuestionnaire.BackColor = Color.FromArgb(58, 51, 92);
            BtnOpenQuestionnaire.BorderColor = Color.Transparent;
            BtnOpenQuestionnaire.BorderRadius = 15;
            BtnOpenQuestionnaire.FlatAppearance.BorderSize = 0;
            BtnOpenQuestionnaire.FlatStyle = FlatStyle.Flat;
            BtnOpenQuestionnaire.Font = new Font("Segoe UI", 10F);
            BtnOpenQuestionnaire.ForeColor = Color.FromArgb(243, 200, 220);
            BtnOpenQuestionnaire.HoverColor = Color.FromArgb(213, 140, 176);
            BtnOpenQuestionnaire.Location = new Point(111, 25);
            BtnOpenQuestionnaire.MinimumSize = new Size(25, 20);
            BtnOpenQuestionnaire.Name = "BtnOpenQuestionnaire";
            BtnOpenQuestionnaire.PressColor = Color.FromArgb(132, 49, 90);
            BtnOpenQuestionnaire.PressDepth = 0.15F;
            BtnOpenQuestionnaire.Size = new Size(109, 32);
            BtnOpenQuestionnaire.TabIndex = 1;
            BtnOpenQuestionnaire.Text = Resources.TextOpenQuestionnaire;
            BtnOpenQuestionnaire.UseVisualStyleBackColor = false;
            BtnOpenQuestionnaire.Click += BtnOpenQuestionnaire_Click;
            // 
            // btnEditAccount
            // 
            btnEditAccount.BackColor = Color.FromArgb(75, 21, 53);
            btnEditAccount.BorderColor = Color.FromArgb(223, 150, 161);
            btnEditAccount.BorderRadius = 15;
            btnEditAccount.FlatAppearance.BorderSize = 0;
            btnEditAccount.FlatStyle = FlatStyle.Flat;
            btnEditAccount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEditAccount.ForeColor = Color.FromArgb(243, 200, 220);
            btnEditAccount.HoverColor = Color.FromArgb(100, 30, 70);
            btnEditAccount.Location = new Point(22, 442);
            btnEditAccount.MinimumSize = new Size(117, 53);
            btnEditAccount.Name = "btnEditAccount";
            btnEditAccount.PressColor = Color.FromArgb(60, 10, 40);
            btnEditAccount.PressDepth = 0.15F;
            btnEditAccount.Size = new Size(187, 53);
            btnEditAccount.TabIndex = 15;
            btnEditAccount.Text = Resources.TextEditAccount;
            btnEditAccount.UseVisualStyleBackColor = false;
            btnEditAccount.Click += btnEditAccount_Click;
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
            btnBooked.MinimumSize = new Size(117, 53);
            btnBooked.Name = "btnBooked";
            btnBooked.PressColor = Color.FromArgb(132, 49, 90);
            btnBooked.PressDepth = 0.15F;
            btnBooked.Size = new Size(187, 53);
            btnBooked.TabIndex = 14;
            btnBooked.Text = Resources.TextBooked;
            btnBooked.UseVisualStyleBackColor = false;
            btnBooked.Click += btnBooked_Click;
            // 
            // txtPriceTo
            // 
            txtPriceTo.BackColor = Color.FromArgb(243, 200, 220);
            txtPriceTo.ForeColor = Color.FromArgb(64, 0, 64);
            txtPriceTo.Location = new Point(139, 401);
            txtPriceTo.Name = "txtPriceTo";
            txtPriceTo.Size = new Size(81, 23);
            txtPriceTo.TabIndex = 13;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ForeColor = Color.FromArgb(64, 0, 64);
            lblTo.Location = new Point(111, 404);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(20, 15);
            lblTo.TabIndex = 12;
            lblTo.Text = "до";
            // 
            // txtPriceFrom
            // 
            txtPriceFrom.BackColor = Color.FromArgb(243, 200, 220);
            txtPriceFrom.ForeColor = Color.FromArgb(64, 0, 64);
            txtPriceFrom.Location = new Point(139, 360);
            txtPriceFrom.Name = "txtPriceFrom";
            txtPriceFrom.Size = new Size(81, 23);
            txtPriceFrom.TabIndex = 11;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ForeColor = Color.FromArgb(64, 0, 64);
            lblFrom.Location = new Point(112, 363);
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
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(43, 17);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Цена";
            // 
            // cmbStars
            // 
            cmbStars.BackColor = Color.FromArgb(243, 200, 220);
            cmbStars.DrawMode = DrawMode.OwnerDrawFixed;
            cmbStars.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStars.ForeColor = Color.FromArgb(64, 0, 64);
            cmbStars.FormattingEnabled = true;
            cmbStars.Location = new Point(23, 277);
            cmbStars.Name = "cmbStars";
            cmbStars.Size = new Size(186, 24);
            cmbStars.TabIndex = 8;
            cmbStars.DrawItem += CmbStars_DrawItem;
            // 
            // lblStars
            // 
            lblStars.AutoSize = true;
            lblStars.ForeColor = Color.FromArgb(64, 0, 64);
            lblStars.Location = new Point(20, 304);
            lblStars.Name = "lblStars";
            lblStars.Size = new Size(102, 15);
            lblStars.TabIndex = 7;
            lblStars.Text = "количество звезд";
            // 
            // cmbCity
            // 
            cmbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCity.BackColor = Color.FromArgb(243, 200, 220);
            cmbCity.ForeColor = Color.FromArgb(64, 0, 64);
            cmbCity.FormattingEnabled = true;
            cmbCity.Location = new Point(23, 219);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(186, 23);
            cmbCity.TabIndex = 6;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.ForeColor = Color.FromArgb(64, 0, 64);
            lblCity.Location = new Point(23, 245);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(39, 15);
            lblCity.TabIndex = 5;
            lblCity.Text = "город";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(243, 200, 220);
            txtName.ForeColor = Color.FromArgb(64, 0, 64);
            txtName.Location = new Point(23, 162);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(186, 23);
            txtName.TabIndex = 4;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.ForeColor = Color.FromArgb(64, 0, 64);
            lblName.Location = new Point(23, 188);
            lblName.Name = "lblName";
            lblName.Size = new Size(29, 15);
            lblName.TabIndex = 3;
            lblName.Text = "имя";
            // 
            // txtSurname
            // 
            txtSurname.BackColor = Color.FromArgb(243, 200, 220);
            txtSurname.ForeColor = Color.FromArgb(64, 0, 64);
            txtSurname.Location = new Point(23, 104);
            txtSurname.Name = "txtSurname";
            txtSurname.ReadOnly = true;
            txtSurname.Size = new Size(186, 23);
            txtSurname.TabIndex = 2;
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.ForeColor = Color.FromArgb(64, 0, 64);
            lblSurname.Location = new Point(20, 130);
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
            Name = "HotelListingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список отелей";
            panelMain.ResumeLayout(false);
            panelProfile.ResumeLayout(false);
            panelProfile.PerformLayout();
            ResumeLayout(false);
        }
        // Метод для пользовательской отрисовки
        private void CmbStars_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Получаем ComboBox
            var comboBox = sender as ComboBox;

            // Очищаем фон
            e.DrawBackground();

            // Задаем цвет фона и текста
            using (var brush = new SolidBrush(comboBox.BackColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var textBrush = new SolidBrush(comboBox.ForeColor))
            {
                // Рисуем текст
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds);
            }
        }
        #endregion

        private Panel panelMain;
        private Panel panelHotels;
        private Panel panelProfile;
        private RoundButton btnBooked;
        private RoundButton btnEditAccount;
        private TextBox txtPriceTo;
        private Label lblTo;
        private TextBox txtPriceFrom;
        private Label lblFrom;
        private Label lblPrice;
        private ComboBox cmbStars;
        private Label lblStars;
        private ComboBox cmbCity;
        private Label lblCity;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtSurname;
        private Label lblSurname;
        private Label lblProfile;
        private RoundButton BtnOpenQuestionnaire;
    }
}