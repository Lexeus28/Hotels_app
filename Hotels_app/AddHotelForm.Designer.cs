using System.Windows.Forms;
using System.Xml.Linq;
using Hotels_app.classes;
using Hotels_app.Properties;

namespace Hotels_app
{
    partial class AddHotelForm
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
            radioSea = new RadioButton();
            radioMountains = new RadioButton();
            radioYes1 = new RadioButton();
            panelArea = new Panel();
            radioCity = new RadioButton();
            radioQuiet = new RadioButton();
            panelEuropean = new Panel();
            radioEuropean = new RadioButton();
            panelAsian = new Panel();
            radioAsian = new RadioButton();
            panelVisit = new Panel();
            radioNo1 = new RadioButton();
            panelActivity = new Panel();
            radioYes2 = new RadioButton();
            radioNo2 = new RadioButton();
            panelLeft = new Panel();
            panelSea = new Panel();
            panelMountains = new Panel();
            pictureBox = new PictureBox();
            btnDeleteImage = new RoundButton();
            btnUploadImage = new RoundButton();
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblCity = new Label();
            cmbCity = new ComboBox();
            lblStars = new Label();
            cmbStars = new ComboBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblLocation = new Label();
            lblArea = new Label();
            lblVisit = new Label();
            lblFood = new Label();
            lblActivity = new Label();
            panelRight = new Panel();
            btnDeleteHotel = new RoundButton();
            lblRoomsList = new Label();
            btnAddHotel = new RoundButton();
            listBoxRooms = new ListBox();
            btnAddRoom = new RoundButton();
            btnDeleteRoom = new RoundButton();
            panelArea.SuspendLayout();
            panelEuropean.SuspendLayout();
            panelAsian.SuspendLayout();
            panelVisit.SuspendLayout();
            panelActivity.SuspendLayout();
            panelLeft.SuspendLayout();
            panelSea.SuspendLayout();
            panelMountains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // radioSea
            // 
            radioSea.AutoCheck = false;
            radioSea.AutoSize = true;
            radioSea.ForeColor = Color.FromArgb(64, 0, 64);
            radioSea.Location = new Point(3, 5);
            radioSea.Name = "radioSea";
            radioSea.Size = new Size(54, 19);
            radioSea.TabIndex = 10;
            radioSea.Text = "море";
            radioSea.UseVisualStyleBackColor = true;
            radioSea.Click += RadioButton_Click;
            // 
            // radioMountains
            // 
            radioMountains.AutoCheck = false;
            radioMountains.AutoSize = true;
            radioMountains.ForeColor = Color.FromArgb(64, 0, 64);
            radioMountains.Location = new Point(9, 5);
            radioMountains.Name = "radioMountains";
            radioMountains.Size = new Size(53, 19);
            radioMountains.TabIndex = 11;
            radioMountains.Text = "горы";
            radioMountains.UseVisualStyleBackColor = true;
            radioMountains.Click += RadioButton_Click;
            // 
            // radioYes1
            // 
            radioYes1.AutoCheck = false;
            radioYes1.AutoSize = true;
            radioYes1.ForeColor = Color.FromArgb(64, 0, 64);
            radioYes1.Location = new Point(9, 3);
            radioYes1.Name = "radioYes1";
            radioYes1.Size = new Size(37, 19);
            radioYes1.TabIndex = 16;
            radioYes1.Text = "да";
            radioYes1.UseVisualStyleBackColor = true;
            radioYes1.Click += RadioButton_Click;
            // 
            // panelArea
            // 
            panelArea.BackColor = Color.Transparent;
            panelArea.Controls.Add(radioCity);
            panelArea.Controls.Add(radioQuiet);
            panelArea.Location = new Point(233, 453);
            panelArea.Name = "panelArea";
            panelArea.Size = new Size(271, 36);
            panelArea.TabIndex = 0;
            // 
            // radioCity
            // 
            radioCity.AutoCheck = false;
            radioCity.AutoSize = true;
            radioCity.ForeColor = Color.FromArgb(64, 0, 64);
            radioCity.Location = new Point(9, 3);
            radioCity.Name = "radioCity";
            radioCity.Size = new Size(57, 19);
            radioCity.TabIndex = 13;
            radioCity.Text = "город";
            radioCity.UseVisualStyleBackColor = true;
            radioCity.Click += RadioButton_Click;
            // 
            // radioQuiet
            // 
            radioQuiet.AutoCheck = false;
            radioQuiet.AutoSize = true;
            radioQuiet.ForeColor = Color.FromArgb(64, 0, 64);
            radioQuiet.Location = new Point(151, 6);
            radioQuiet.Name = "radioQuiet";
            radioQuiet.Size = new Size(114, 19);
            radioQuiet.TabIndex = 14;
            radioQuiet.Text = "тихая местность";
            radioQuiet.UseVisualStyleBackColor = true;
            radioQuiet.Click += RadioButton_Click;
            // 
            // panelEuropean
            // 
            panelEuropean.BackColor = Color.Transparent;
            panelEuropean.Controls.Add(radioEuropean);
            panelEuropean.Location = new Point(233, 519);
            panelEuropean.Name = "panelEuropean";
            panelEuropean.Size = new Size(110, 30);
            panelEuropean.TabIndex = 3;
            // 
            // radioEuropean
            // 
            radioEuropean.AutoCheck = false;
            radioEuropean.AutoSize = true;
            radioEuropean.ForeColor = Color.FromArgb(64, 0, 64);
            radioEuropean.Location = new Point(9, 0);
            radioEuropean.Name = "radioEuropean";
            radioEuropean.Size = new Size(95, 19);
            radioEuropean.TabIndex = 19;
            radioEuropean.Text = "европейская";
            radioEuropean.UseVisualStyleBackColor = true;
            radioEuropean.Click += RadioButton_Click;
            // 
            // panelAsian
            // 
            panelAsian.BackColor = Color.Transparent;
            panelAsian.Controls.Add(radioAsian);
            panelAsian.Location = new Point(367, 516);
            panelAsian.Name = "panelAsian";
            panelAsian.Size = new Size(114, 33);
            panelAsian.TabIndex = 4;
            // 
            // radioAsian
            // 
            radioAsian.AutoCheck = false;
            radioAsian.AutoSize = true;
            radioAsian.ForeColor = Color.FromArgb(64, 0, 64);
            radioAsian.Location = new Point(17, 3);
            radioAsian.Margin = new Padding(4, 3, 4, 3);
            radioAsian.Name = "radioAsian";
            radioAsian.Size = new Size(78, 19);
            radioAsian.TabIndex = 20;
            radioAsian.TabStop = true;
            radioAsian.Text = "азиатская";
            radioAsian.UseVisualStyleBackColor = true;
            radioAsian.Click += RadioButton_Click;
            // 
            // panelVisit
            // 
            panelVisit.BackColor = Color.Transparent;
            panelVisit.Controls.Add(radioYes1);
            panelVisit.Controls.Add(radioNo1);
            panelVisit.Location = new Point(233, 486);
            panelVisit.Name = "panelVisit";
            panelVisit.Size = new Size(248, 36);
            panelVisit.TabIndex = 0;
            // 
            // radioNo1
            // 
            radioNo1.AutoCheck = false;
            radioNo1.AutoSize = true;
            radioNo1.ForeColor = Color.FromArgb(64, 0, 64);
            radioNo1.Location = new Point(151, 4);
            radioNo1.Name = "radioNo1";
            radioNo1.Size = new Size(43, 19);
            radioNo1.TabIndex = 17;
            radioNo1.Text = "нет";
            radioNo1.UseVisualStyleBackColor = true;
            radioNo1.Click += RadioButton_Click;
            // 
            // panelActivity
            // 
            panelActivity.BackColor = Color.Transparent;
            panelActivity.Controls.Add(radioYes2);
            panelActivity.Controls.Add(radioNo2);
            panelActivity.Location = new Point(233, 548);
            panelActivity.Name = "panelActivity";
            panelActivity.Size = new Size(248, 36);
            panelActivity.TabIndex = 0;
            // 
            // radioYes2
            // 
            radioYes2.AutoCheck = false;
            radioYes2.AutoSize = true;
            radioYes2.ForeColor = Color.FromArgb(64, 0, 64);
            radioYes2.Location = new Point(9, 3);
            radioYes2.Name = "radioYes2";
            radioYes2.Size = new Size(37, 19);
            radioYes2.TabIndex = 22;
            radioYes2.Text = "да";
            radioYes2.UseVisualStyleBackColor = true;
            radioYes2.Click += RadioButton_Click;
            // 
            // radioNo2
            // 
            radioNo2.AutoCheck = false;
            radioNo2.AutoSize = true;
            radioNo2.ForeColor = Color.FromArgb(64, 0, 64);
            radioNo2.Location = new Point(151, 3);
            radioNo2.Name = "radioNo2";
            radioNo2.Size = new Size(43, 19);
            radioNo2.TabIndex = 23;
            radioNo2.Text = "нет";
            radioNo2.UseVisualStyleBackColor = true;
            radioNo2.Click += RadioButton_Click;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(196, 171, 195);
            panelLeft.Controls.Add(panelVisit);
            panelLeft.Controls.Add(panelArea);
            panelLeft.Controls.Add(panelSea);
            panelLeft.Controls.Add(panelMountains);
            panelLeft.Controls.Add(panelEuropean);
            panelLeft.Controls.Add(panelAsian);
            panelLeft.Controls.Add(panelActivity);
            panelLeft.Controls.Add(pictureBox);
            panelLeft.Controls.Add(btnDeleteImage);
            panelLeft.Controls.Add(btnUploadImage);
            panelLeft.Controls.Add(lblTitle);
            panelLeft.Controls.Add(lblName);
            panelLeft.Controls.Add(txtName);
            panelLeft.Controls.Add(lblCity);
            panelLeft.Controls.Add(cmbCity);
            panelLeft.Controls.Add(lblStars);
            panelLeft.Controls.Add(cmbStars);
            panelLeft.Controls.Add(lblAddress);
            panelLeft.Controls.Add(txtAddress);
            panelLeft.Controls.Add(lblDescription);
            panelLeft.Controls.Add(txtDescription);
            panelLeft.Controls.Add(lblLocation);
            panelLeft.Controls.Add(lblArea);
            panelLeft.Controls.Add(lblVisit);
            panelLeft.Controls.Add(lblFood);
            panelLeft.Controls.Add(lblActivity);
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(560, 618);
            panelLeft.TabIndex = 0;
            // 
            // panelSea
            // 
            panelSea.BackColor = Color.Transparent;
            panelSea.Controls.Add(radioSea);
            panelSea.Location = new Point(381, 423);
            panelSea.Name = "panelSea";
            panelSea.Size = new Size(100, 30);
            panelSea.TabIndex = 1;
            // 
            // panelMountains
            // 
            panelMountains.BackColor = Color.Transparent;
            panelMountains.Controls.Add(radioMountains);
            panelMountains.Location = new Point(233, 423);
            panelMountains.Name = "panelMountains";
            panelMountains.Size = new Size(114, 30);
            panelMountains.TabIndex = 2;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.FromArgb(243, 200, 220);
            pictureBox.Location = new Point(321, 74);
            pictureBox.Margin = new Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(214, 112);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 5;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            // 
            // btnDeleteImage
            // 
            btnDeleteImage.BackColor = Color.FromArgb(75, 21, 53);
            btnDeleteImage.BorderColor = Color.Transparent;
            btnDeleteImage.BorderRadius = 15;
            btnDeleteImage.FlatStyle = FlatStyle.Flat;
            btnDeleteImage.Font = new Font("Microsoft Sans Serif", 12F);
            btnDeleteImage.ForeColor = Color.FromArgb(243, 200, 220);
            btnDeleteImage.HoverColor = Color.FromArgb(213, 140, 176);
            btnDeleteImage.Location = new Point(433, 201);
            btnDeleteImage.Margin = new Padding(4, 3, 4, 3);
            btnDeleteImage.MinimumSize = new Size(100, 46);
            btnDeleteImage.Name = "btnDeleteImage";
            btnDeleteImage.PressColor = Color.FromArgb(132, 49, 90);
            btnDeleteImage.PressDepth = 0.15F;
            btnDeleteImage.Size = new Size(102, 46);
            btnDeleteImage.TabIndex = 24;
            btnDeleteImage.Text = Resources.TextDelete;
            btnDeleteImage.UseVisualStyleBackColor = false;
            btnDeleteImage.Click += btnDeleteImage_Click;
            // 
            // btnUploadImage
            // 
            btnUploadImage.BackColor = Color.FromArgb(58, 51, 92);
            btnUploadImage.BorderColor = Color.Transparent;
            btnUploadImage.BorderRadius = 15;
            btnUploadImage.FlatStyle = FlatStyle.Flat;
            btnUploadImage.Font = new Font("Microsoft Sans Serif", 10F);
            btnUploadImage.ForeColor = Color.FromArgb(243, 200, 220);
            btnUploadImage.HoverColor = Color.FromArgb(213, 140, 176);
            btnUploadImage.Location = new Point(321, 201);
            btnUploadImage.Margin = new Padding(4, 3, 4, 3);
            btnUploadImage.MinimumSize = new Size(100, 46);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.PressColor = Color.FromArgb(132, 49, 90);
            btnUploadImage.PressDepth = 0.15F;
            btnUploadImage.Size = new Size(102, 46);
            btnUploadImage.TabIndex = 4;
            btnUploadImage.Text = Resources.TextUploadImage ;
            btnUploadImage.UseVisualStyleBackColor = false;
            btnUploadImage.Click += btnUploadImage_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F);
            lblTitle.ForeColor = Color.FromArgb(64, 0, 64);
            lblTitle.Location = new Point(22, 12);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(235, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Добавление отелей";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.ForeColor = Color.FromArgb(64, 0, 64);
            lblName.Location = new Point(22, 100);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(57, 15);
            lblName.TabIndex = 1;
            lblName.Text = "название";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(243, 200, 220);
            txtName.Location = new Point(22, 74);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(291, 23);
            txtName.TabIndex = 2;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.ForeColor = Color.FromArgb(64, 0, 64);
            lblCity.Location = new Point(22, 144);
            lblCity.Margin = new Padding(4, 0, 4, 0);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(39, 15);
            lblCity.TabIndex = 3;
            lblCity.Text = "город";
            // 
            // cmbCity
            // 
            cmbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCity.BackColor = Color.FromArgb(243, 200, 220);
            cmbCity.FlatStyle = FlatStyle.Flat;
            cmbCity.FormattingEnabled = true;
            cmbCity.Location = new Point(22, 118);
            cmbCity.Margin = new Padding(4, 3, 4, 3);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(172, 23);
            cmbCity.TabIndex = 4;
            // 
            // lblStars
            // 
            lblStars.AutoSize = true;
            lblStars.ForeColor = Color.FromArgb(64, 0, 64);
            lblStars.Location = new Point(22, 190);
            lblStars.Margin = new Padding(4, 0, 4, 0);
            lblStars.Name = "lblStars";
            lblStars.Size = new Size(102, 15);
            lblStars.TabIndex = 5;
            lblStars.Text = "количество звезд";
            // 
            // cmbStars
            // 
            cmbStars.BackColor = Color.FromArgb(243, 200, 220);
            cmbStars.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStars.FlatStyle = FlatStyle.Flat;
            cmbStars.FormattingEnabled = true;
            cmbStars.Location = new Point(22, 163);
            cmbStars.Margin = new Padding(4, 3, 4, 3);
            cmbStars.Name = "cmbStars";
            cmbStars.Size = new Size(171, 23);
            cmbStars.TabIndex = 6;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.ForeColor = Color.FromArgb(64, 0, 64);
            lblAddress.Location = new Point(23, 232);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(38, 15);
            lblAddress.TabIndex = 10;
            lblAddress.Text = "адрес";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.FromArgb(243, 200, 220);
            txtAddress.Location = new Point(22, 206);
            txtAddress.Margin = new Padding(4, 3, 4, 3);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(291, 23);
            txtAddress.TabIndex = 11;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.ForeColor = Color.FromArgb(64, 0, 64);
            lblDescription.Location = new Point(23, 399);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(60, 15);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "описание";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(243, 200, 220);
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Location = new Point(22, 273);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(513, 123);
            txtDescription.TabIndex = 8;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.ForeColor = Color.FromArgb(64, 0, 64);
            lblLocation.Location = new Point(13, 423);
            lblLocation.Margin = new Padding(4, 0, 4, 0);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(186, 30);
            lblLocation.TabIndex = 9;
            lblLocation.Text = "Отель находится рядом с морем\nили горой";
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.ForeColor = Color.FromArgb(64, 0, 64);
            lblArea.Location = new Point(13, 463);
            lblArea.Margin = new Padding(4, 0, 4, 0);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(139, 15);
            lblArea.TabIndex = 12;
            lblArea.Text = "Местоположение отеля";
            // 
            // lblVisit
            // 
            lblVisit.AutoSize = true;
            lblVisit.ForeColor = Color.FromArgb(64, 0, 64);
            lblVisit.Location = new Point(13, 492);
            lblVisit.Margin = new Padding(4, 0, 4, 0);
            lblVisit.Name = "lblVisit";
            lblVisit.Size = new Size(134, 30);
            lblVisit.TabIndex = 15;
            lblVisit.Text = "Возможно ли посетить\nисторические места";
            // 
            // lblFood
            // 
            lblFood.AutoSize = true;
            lblFood.ForeColor = Color.FromArgb(64, 0, 64);
            lblFood.Location = new Point(13, 534);
            lblFood.Margin = new Padding(4, 0, 4, 0);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(84, 15);
            lblFood.TabIndex = 18;
            lblFood.Text = "Кухня в отеле:";
            // 
            // lblActivity
            // 
            lblActivity.AutoSize = true;
            lblActivity.ForeColor = Color.FromArgb(64, 0, 64);
            lblActivity.Location = new Point(13, 555);
            lblActivity.Margin = new Padding(4, 0, 4, 0);
            lblActivity.Name = "lblActivity";
            lblActivity.Size = new Size(172, 15);
            lblActivity.TabIndex = 21;
            lblActivity.Text = "Возможен ли активный отдых";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(158, 157, 189);
            panelRight.Controls.Add(btnDeleteHotel);
            panelRight.Controls.Add(lblRoomsList);
            panelRight.Controls.Add(btnAddHotel);
            panelRight.Controls.Add(listBoxRooms);
            panelRight.Controls.Add(btnAddRoom);
            panelRight.Controls.Add(btnDeleteRoom);
            panelRight.Location = new Point(558, 0);
            panelRight.Margin = new Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(279, 618);
            panelRight.TabIndex = 1;
            // 
            // btnDeleteHotel
            // 
            btnDeleteHotel.BackColor = Color.FromArgb(75, 21, 53);
            btnDeleteHotel.BorderColor = Color.Transparent;
            btnDeleteHotel.BorderRadius = 15;
            btnDeleteHotel.FlatStyle = FlatStyle.Flat;
            btnDeleteHotel.Font = new Font("Microsoft Sans Serif", 14F);
            btnDeleteHotel.ForeColor = Color.FromArgb(243, 200, 220);
            btnDeleteHotel.HoverColor = Color.FromArgb(213, 140, 176);
            btnDeleteHotel.Location = new Point(54, 473);
            btnDeleteHotel.Margin = new Padding(4, 3, 4, 3);
            btnDeleteHotel.MinimumSize = new Size(100, 46);
            btnDeleteHotel.Name = "btnDeleteHotel";
            btnDeleteHotel.PressColor = Color.FromArgb(132, 49, 90);
            btnDeleteHotel.PressDepth = 0.15F;
            btnDeleteHotel.Size = new Size(175, 46);
            btnDeleteHotel.TabIndex = 2;
            btnDeleteHotel.Text = Resources.TextDeleteHotel;
            btnDeleteHotel.UseVisualStyleBackColor = false;
            btnDeleteHotel.Click += btnDeleteHotel_Click;
            // 
            // lblRoomsList
            // 
            lblRoomsList.AutoSize = true;
            lblRoomsList.Font = new Font("Microsoft Sans Serif", 14F);
            lblRoomsList.ForeColor = Color.FromArgb(64, 0, 64);
            lblRoomsList.Location = new Point(54, 20);
            lblRoomsList.Margin = new Padding(4, 0, 4, 0);
            lblRoomsList.Name = "lblRoomsList";
            lblRoomsList.Size = new Size(156, 24);
            lblRoomsList.TabIndex = 0;
            lblRoomsList.Text = "список номеров";
            // 
            // btnAddHotel
            // 
            btnAddHotel.BackColor = Color.FromArgb(58, 51, 92);
            btnAddHotel.BorderColor = Color.Transparent;
            btnAddHotel.BorderRadius = 15;
            btnAddHotel.FlatStyle = FlatStyle.Flat;
            btnAddHotel.Font = new Font("Microsoft Sans Serif", 14F);
            btnAddHotel.ForeColor = Color.FromArgb(243, 200, 220);
            btnAddHotel.HoverColor = Color.FromArgb(213, 140, 176);
            btnAddHotel.Location = new Point(54, 538);
            btnAddHotel.Margin = new Padding(4, 3, 4, 3);
            btnAddHotel.MinimumSize = new Size(100, 46);
            btnAddHotel.Name = "btnAddHotel";
            btnAddHotel.PressColor = Color.FromArgb(132, 49, 90);
            btnAddHotel.PressDepth = 0.15F;
            btnAddHotel.Size = new Size(175, 46);
            btnAddHotel.TabIndex = 3;
            btnAddHotel.Text = Resources.TextSaveLower;
            btnAddHotel.UseVisualStyleBackColor = false;
            btnAddHotel.Click += btnAddHotel_Click;
            // 
            // listBoxRooms
            // 
            listBoxRooms.BackColor = Color.FromArgb(243, 200, 220);
            listBoxRooms.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxRooms.Font = new Font("Segoe UI", 12F);
            listBoxRooms.ForeColor = Color.FromArgb(64, 0, 64);
            listBoxRooms.FormattingEnabled = true;
            listBoxRooms.ItemHeight = 40;
            listBoxRooms.Items.AddRange(new object[] { "Menu Item", "Menu Item", "Menu Item", "Menu Item" });
            listBoxRooms.Location = new Point(12, 65);
            listBoxRooms.Margin = new Padding(4, 3, 4, 3);
            listBoxRooms.Name = "listBoxRooms";
            listBoxRooms.Size = new Size(250, 164);
            listBoxRooms.TabIndex = 1;
            listBoxRooms.DrawItem += ListBoxRooms_DrawItem;
            // 
            // btnAddRoom
            // 
            btnAddRoom.BackColor = Color.FromArgb(60, 60, 100);
            btnAddRoom.BorderColor = Color.Transparent;
            btnAddRoom.BorderRadius = 15;
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.Font = new Font("Microsoft Sans Serif", 12F);
            btnAddRoom.ForeColor = Color.FromArgb(243, 200, 220);
            btnAddRoom.HoverColor = Color.FromArgb(213, 140, 176);
            btnAddRoom.Location = new Point(12, 256);
            btnAddRoom.Margin = new Padding(4, 3, 4, 3);
            btnAddRoom.MinimumSize = new Size(100, 46);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.PressColor = Color.FromArgb(132, 49, 90);
            btnAddRoom.PressDepth = 0.15F;
            btnAddRoom.Size = new Size(117, 46);
            btnAddRoom.TabIndex = 7;
            btnAddRoom.Text = Resources.TextAdd;
            btnAddRoom.UseVisualStyleBackColor = false;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.BackColor = Color.FromArgb(75, 21, 53);
            btnDeleteRoom.BorderColor = Color.Transparent;
            btnDeleteRoom.BorderRadius = 15;
            btnDeleteRoom.FlatStyle = FlatStyle.Flat;
            btnDeleteRoom.Font = new Font("Microsoft Sans Serif", 12F);
            btnDeleteRoom.ForeColor = Color.FromArgb(243, 200, 220);
            btnDeleteRoom.HoverColor = Color.FromArgb(213, 140, 176);
            btnDeleteRoom.Location = new Point(149, 256);
            btnDeleteRoom.Margin = new Padding(4, 3, 4, 3);
            btnDeleteRoom.MinimumSize = new Size(100, 46);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.PressColor = Color.FromArgb(132, 49, 90);
            btnDeleteRoom.PressDepth = 0.15F;
            btnDeleteRoom.Size = new Size(117, 46);
            btnDeleteRoom.TabIndex = 8;
            btnDeleteRoom.Text = Resources.TextDelete;
            btnDeleteRoom.UseVisualStyleBackColor = false;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // AddHotelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 617);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddHotelForm";
            Text = "Добавление отелей";
            panelArea.ResumeLayout(false);
            panelArea.PerformLayout();
            panelEuropean.ResumeLayout(false);
            panelEuropean.PerformLayout();
            panelAsian.ResumeLayout(false);
            panelAsian.PerformLayout();
            panelVisit.ResumeLayout(false);
            panelVisit.PerformLayout();
            panelActivity.ResumeLayout(false);
            panelActivity.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelSea.ResumeLayout(false);
            panelSea.PerformLayout();
            panelMountains.ResumeLayout(false);
            panelMountains.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Label lblStars;
        private System.Windows.Forms.ComboBox cmbStars;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblLocation;
        private RadioButton radioMountains;
        private RadioButton radioSea;
        private System.Windows.Forms.Label lblArea;
        private RadioButton radioCity;
        private RadioButton radioQuiet;
        private System.Windows.Forms.Label lblVisit;
        private RadioButton radioYes1;
        private RadioButton radioNo1;
        private System.Windows.Forms.Label lblFood;
        private RadioButton radioEuropean;
        private RadioButton radioAsian;
        private System.Windows.Forms.Label lblActivity;
        private RadioButton radioYes2;
        private RadioButton radioNo2;

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblRoomsList;
        private System.Windows.Forms.ListBox listBoxRooms;
        private RoundButton btnAddRoom;
        private RoundButton btnDeleteRoom;

        private RoundButton btnDeleteHotel;
        private RoundButton btnAddHotel;
        private RoundButton btnUploadImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private RoundButton btnDeleteImage;
        private Panel panelArea;
        private Panel panelVisit;
        private Panel panelActivity;
        private Panel panelEuropean;
        private Panel panelAsian;
        private Panel panelSea;
        private Panel panelMountains;
    }
}