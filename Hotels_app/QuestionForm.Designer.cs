namespace Hotels_app
{
    partial class QuestionForm
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
            btnClose = new Button();
            groupBoxCuisine = new GroupBox();
            rbAsianCuisine = new RadioButton();
            rbEuropeanCuisine = new RadioButton();
            groupBoxActiveRecreation = new GroupBox();
            rbActiveRecreationNo = new RadioButton();
            rbActiveRecreationYes = new RadioButton();
            groupBoxHistoricalPlaces = new GroupBox();
            rbHistoricalPlacesNo = new RadioButton();
            rbHistoricalPlacesYes = new RadioButton();
            groupBoxLocation = new GroupBox();
            rbQuietLocation = new RadioButton();
            rbCity = new RadioButton();
            groupBoxMountainsOrSea = new GroupBox();
            rbSea = new RadioButton();
            rbMountains = new RadioButton();
            lblTitle = new Label();
            btnSave = new RoundButton();
            panelMain.SuspendLayout();
            groupBoxCuisine.SuspendLayout();
            groupBoxActiveRecreation.SuspendLayout();
            groupBoxHistoricalPlaces.SuspendLayout();
            groupBoxLocation.SuspendLayout();
            groupBoxMountainsOrSea.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelMain.BackColor = Color.FromArgb(158, 157, 189);
            panelMain.Controls.Add(btnClose);
            panelMain.Controls.Add(groupBoxCuisine);
            panelMain.Controls.Add(groupBoxActiveRecreation);
            panelMain.Controls.Add(groupBoxHistoricalPlaces);
            panelMain.Controls.Add(groupBoxLocation);
            panelMain.Controls.Add(groupBoxMountainsOrSea);
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(btnSave);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(504, 353);
            panelMain.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(64, 0, 64);
            btnClose.Location = new Point(474, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 32);
            btnClose.TabIndex = 17;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // groupBoxCuisine
            // 
            groupBoxCuisine.Controls.Add(rbAsianCuisine);
            groupBoxCuisine.Controls.Add(rbEuropeanCuisine);
            groupBoxCuisine.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxCuisine.ForeColor = Color.FromArgb(64, 0, 64);
            groupBoxCuisine.Location = new Point(37, 200);
            groupBoxCuisine.Name = "groupBoxCuisine";
            groupBoxCuisine.Size = new Size(430, 50);
            groupBoxCuisine.TabIndex = 18;
            groupBoxCuisine.TabStop = false;
            groupBoxCuisine.Text = "✓ Какая кухня вам нравится больше:";
            // 
            // rbAsianCuisine
            // 
            rbAsianCuisine.AutoSize = true;
            rbAsianCuisine.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbAsianCuisine.ForeColor = Color.FromArgb(64, 0, 64);
            rbAsianCuisine.Location = new Point(221, 17);
            rbAsianCuisine.Name = "rbAsianCuisine";
            rbAsianCuisine.Padding = new Padding(10, 5, 0, 5);
            rbAsianCuisine.Size = new Size(92, 29);
            rbAsianCuisine.TabIndex = 15;
            rbAsianCuisine.TabStop = true;
            rbAsianCuisine.Text = "азиатская";
            rbAsianCuisine.UseVisualStyleBackColor = true;
            // 
            // rbEuropeanCuisine
            // 
            rbEuropeanCuisine.AutoSize = true;
            rbEuropeanCuisine.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbEuropeanCuisine.ForeColor = Color.FromArgb(64, 0, 64);
            rbEuropeanCuisine.Location = new Point(107, 17);
            rbEuropeanCuisine.Name = "rbEuropeanCuisine";
            rbEuropeanCuisine.Padding = new Padding(10, 5, 0, 5);
            rbEuropeanCuisine.Size = new Size(111, 29);
            rbEuropeanCuisine.TabIndex = 14;
            rbEuropeanCuisine.TabStop = true;
            rbEuropeanCuisine.Text = "европейская";
            rbEuropeanCuisine.UseVisualStyleBackColor = true;
            // 
            // groupBoxActiveRecreation
            // 
            groupBoxActiveRecreation.Controls.Add(rbActiveRecreationNo);
            groupBoxActiveRecreation.Controls.Add(rbActiveRecreationYes);
            groupBoxActiveRecreation.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxActiveRecreation.ForeColor = Color.FromArgb(64, 0, 64);
            groupBoxActiveRecreation.Location = new Point(37, 250);
            groupBoxActiveRecreation.Name = "groupBoxActiveRecreation";
            groupBoxActiveRecreation.Size = new Size(430, 50);
            groupBoxActiveRecreation.TabIndex = 19;
            groupBoxActiveRecreation.TabStop = false;
            groupBoxActiveRecreation.Text = "✓ Вам нравится активный отдых?";
            // 
            // rbActiveRecreationNo
            // 
            rbActiveRecreationNo.AutoSize = true;
            rbActiveRecreationNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbActiveRecreationNo.ForeColor = Color.FromArgb(64, 0, 64);
            rbActiveRecreationNo.Location = new Point(221, 17);
            rbActiveRecreationNo.Name = "rbActiveRecreationNo";
            rbActiveRecreationNo.Padding = new Padding(10, 5, 0, 5);
            rbActiveRecreationNo.Size = new Size(54, 29);
            rbActiveRecreationNo.TabIndex = 12;
            rbActiveRecreationNo.TabStop = true;
            rbActiveRecreationNo.Text = "нет";
            rbActiveRecreationNo.UseVisualStyleBackColor = true;
            // 
            // rbActiveRecreationYes
            // 
            rbActiveRecreationYes.AutoSize = true;
            rbActiveRecreationYes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbActiveRecreationYes.ForeColor = Color.FromArgb(64, 0, 64);
            rbActiveRecreationYes.Location = new Point(107, 17);
            rbActiveRecreationYes.Name = "rbActiveRecreationYes";
            rbActiveRecreationYes.Padding = new Padding(10, 5, 0, 5);
            rbActiveRecreationYes.Size = new Size(48, 29);
            rbActiveRecreationYes.TabIndex = 11;
            rbActiveRecreationYes.TabStop = true;
            rbActiveRecreationYes.Text = "да";
            rbActiveRecreationYes.UseVisualStyleBackColor = true;
            // 
            // groupBoxHistoricalPlaces
            // 
            groupBoxHistoricalPlaces.Controls.Add(rbHistoricalPlacesNo);
            groupBoxHistoricalPlaces.Controls.Add(rbHistoricalPlacesYes);
            groupBoxHistoricalPlaces.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxHistoricalPlaces.ForeColor = Color.FromArgb(64, 0, 64);
            groupBoxHistoricalPlaces.Location = new Point(37, 150);
            groupBoxHistoricalPlaces.Name = "groupBoxHistoricalPlaces";
            groupBoxHistoricalPlaces.Size = new Size(430, 50);
            groupBoxHistoricalPlaces.TabIndex = 20;
            groupBoxHistoricalPlaces.TabStop = false;
            groupBoxHistoricalPlaces.Text = "✓ Нравится ли вам посещать исторические места?";
            // 
            // rbHistoricalPlacesNo
            // 
            rbHistoricalPlacesNo.AutoSize = true;
            rbHistoricalPlacesNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbHistoricalPlacesNo.ForeColor = Color.FromArgb(64, 0, 64);
            rbHistoricalPlacesNo.Location = new Point(221, 17);
            rbHistoricalPlacesNo.Name = "rbHistoricalPlacesNo";
            rbHistoricalPlacesNo.Padding = new Padding(10, 5, 0, 5);
            rbHistoricalPlacesNo.Size = new Size(54, 29);
            rbHistoricalPlacesNo.TabIndex = 9;
            rbHistoricalPlacesNo.TabStop = true;
            rbHistoricalPlacesNo.Text = "нет";
            rbHistoricalPlacesNo.UseVisualStyleBackColor = true;
            // 
            // rbHistoricalPlacesYes
            // 
            rbHistoricalPlacesYes.AutoSize = true;
            rbHistoricalPlacesYes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbHistoricalPlacesYes.ForeColor = Color.FromArgb(64, 0, 64);
            rbHistoricalPlacesYes.Location = new Point(107, 17);
            rbHistoricalPlacesYes.Name = "rbHistoricalPlacesYes";
            rbHistoricalPlacesYes.Padding = new Padding(10, 5, 0, 5);
            rbHistoricalPlacesYes.Size = new Size(48, 29);
            rbHistoricalPlacesYes.TabIndex = 8;
            rbHistoricalPlacesYes.TabStop = true;
            rbHistoricalPlacesYes.Text = "да";
            rbHistoricalPlacesYes.UseVisualStyleBackColor = true;
            // 
            // groupBoxLocation
            // 
            groupBoxLocation.Controls.Add(rbQuietLocation);
            groupBoxLocation.Controls.Add(rbCity);
            groupBoxLocation.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxLocation.ForeColor = Color.FromArgb(64, 0, 64);
            groupBoxLocation.Location = new Point(37, 100);
            groupBoxLocation.Name = "groupBoxLocation";
            groupBoxLocation.Size = new Size(430, 50);
            groupBoxLocation.TabIndex = 21;
            groupBoxLocation.TabStop = false;
            groupBoxLocation.Text = "✓ Что выберите: шумный город или тихую местность?";
            // 
            // rbQuietLocation
            // 
            rbQuietLocation.AutoSize = true;
            rbQuietLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbQuietLocation.ForeColor = Color.FromArgb(64, 0, 64);
            rbQuietLocation.Location = new Point(221, 17);
            rbQuietLocation.Name = "rbQuietLocation";
            rbQuietLocation.Padding = new Padding(10, 5, 0, 5);
            rbQuietLocation.Size = new Size(130, 29);
            rbQuietLocation.TabIndex = 6;
            rbQuietLocation.TabStop = true;
            rbQuietLocation.Text = "тихая местность";
            rbQuietLocation.UseVisualStyleBackColor = true;
            // 
            // rbCity
            // 
            rbCity.AutoSize = true;
            rbCity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbCity.ForeColor = Color.FromArgb(64, 0, 64);
            rbCity.Location = new Point(107, 17);
            rbCity.Name = "rbCity";
            rbCity.Padding = new Padding(10, 5, 0, 5);
            rbCity.Size = new Size(68, 29);
            rbCity.TabIndex = 5;
            rbCity.TabStop = true;
            rbCity.Text = "город";
            rbCity.UseVisualStyleBackColor = true;
            // 
            // groupBoxMountainsOrSea
            // 
            groupBoxMountainsOrSea.Controls.Add(rbSea);
            groupBoxMountainsOrSea.Controls.Add(rbMountains);
            groupBoxMountainsOrSea.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxMountainsOrSea.ForeColor = Color.FromArgb(64, 0, 64);
            groupBoxMountainsOrSea.Location = new Point(37, 50);
            groupBoxMountainsOrSea.Name = "groupBoxMountainsOrSea";
            groupBoxMountainsOrSea.Size = new Size(430, 50);
            groupBoxMountainsOrSea.TabIndex = 22;
            groupBoxMountainsOrSea.TabStop = false;
            groupBoxMountainsOrSea.Text = "✓ Что вам больше нравится: море или горы?";
            // 
            // rbSea
            // 
            rbSea.AutoSize = true;
            rbSea.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbSea.ForeColor = Color.FromArgb(64, 0, 64);
            rbSea.Location = new Point(221, 17);
            rbSea.Name = "rbSea";
            rbSea.Padding = new Padding(10, 5, 0, 5);
            rbSea.Size = new Size(65, 29);
            rbSea.TabIndex = 3;
            rbSea.TabStop = true;
            rbSea.Text = "море";
            rbSea.UseVisualStyleBackColor = true;
            // 
            // rbMountains
            // 
            rbMountains.AutoSize = true;
            rbMountains.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbMountains.ForeColor = Color.FromArgb(64, 0, 64);
            rbMountains.Location = new Point(107, 17);
            rbMountains.Name = "rbMountains";
            rbMountains.Padding = new Padding(10, 5, 0, 5);
            rbMountains.Size = new Size(64, 29);
            rbMountains.TabIndex = 2;
            rbMountains.TabStop = true;
            rbMountains.Text = "горы";
            rbMountains.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(64, 0, 64);
            lblTitle.Location = new Point(15, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(138, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Заполните анкету";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.BackColor = Color.FromArgb(231, 143, 174);
            btnSave.BorderColor = Color.Transparent;
            btnSave.BorderRadius = 15;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.FromArgb(243, 200, 220);
            btnSave.HoverColor = Color.FromArgb(213, 140, 176);
            btnSave.Location = new Point(385, 304);
            btnSave.MinimumSize = new Size(100, 46);
            btnSave.Name = "btnSave";
            btnSave.PressColor = Color.FromArgb(132, 49, 90);
            btnSave.PressDepth = 0.15F;
            btnSave.Size = new Size(107, 46);
            btnSave.TabIndex = 16;
            btnSave.Text = "СОХРАНИТЬ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // QuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 353);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QuestionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Questionnaire";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            groupBoxCuisine.ResumeLayout(false);
            groupBoxCuisine.PerformLayout();
            groupBoxActiveRecreation.ResumeLayout(false);
            groupBoxActiveRecreation.PerformLayout();
            groupBoxHistoricalPlaces.ResumeLayout(false);
            groupBoxHistoricalPlaces.PerformLayout();
            groupBoxLocation.ResumeLayout(false);
            groupBoxLocation.PerformLayout();
            groupBoxMountainsOrSea.ResumeLayout(false);
            groupBoxMountainsOrSea.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbSea;
        private System.Windows.Forms.RadioButton rbMountains;
        private System.Windows.Forms.RadioButton rbQuietLocation;
        private System.Windows.Forms.RadioButton rbCity;
        private System.Windows.Forms.RadioButton rbHistoricalPlacesNo;
        private System.Windows.Forms.RadioButton rbHistoricalPlacesYes;
        private System.Windows.Forms.RadioButton rbActiveRecreationNo;
        private System.Windows.Forms.RadioButton rbActiveRecreationYes;
        private System.Windows.Forms.RadioButton rbAsianCuisine;
        private System.Windows.Forms.RadioButton rbEuropeanCuisine;
        private Hotels_app.RoundButton btnSave;
        private System.Windows.Forms.Button btnClose;
        private GroupBox groupBoxMountainsOrSea;
        private GroupBox groupBoxLocation;
        private GroupBox groupBoxHistoricalPlaces;
        private GroupBox groupBoxActiveRecreation;
        private GroupBox groupBoxCuisine;
    }
}