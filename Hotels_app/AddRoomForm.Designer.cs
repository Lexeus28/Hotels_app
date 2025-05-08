using System.Windows.Forms;
using System.Xml.Linq;

namespace Hotels_app
{
    partial class AddRoomForm
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
            panelLeft = new Panel();
            txtPrice = new TextBox();
            pictureBox = new PictureBox();
            btnDeleteImage = new RoundButton();
            btnUploadImage = new RoundButton();
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblCapacity = new Label();
            numericCapacity = new NumericUpDown();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            panelRight = new Panel();
            btnAddRoom = new RoundButton();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCapacity).BeginInit();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(196, 171, 195);
            panelLeft.Controls.Add(txtPrice);
            panelLeft.Controls.Add(pictureBox);
            panelLeft.Controls.Add(btnDeleteImage);
            panelLeft.Controls.Add(btnUploadImage);
            panelLeft.Controls.Add(lblTitle);
            panelLeft.Controls.Add(lblName);
            panelLeft.Controls.Add(txtName);
            panelLeft.Controls.Add(lblCapacity);
            panelLeft.Controls.Add(numericCapacity);
            panelLeft.Controls.Add(lblDescription);
            panelLeft.Controls.Add(txtDescription);
            panelLeft.Controls.Add(lblPrice);
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(587, 548);
            panelLeft.TabIndex = 0;
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(243, 200, 220);
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Location = new Point(22, 186);
            txtPrice.Margin = new Padding(4, 3, 4, 3);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(77, 23);
            txtPrice.TabIndex = 10;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.FromArgb(243, 200, 220);
            pictureBox.Location = new Point(321, 74);
            pictureBox.Margin = new Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(214, 112);
            pictureBox.TabIndex = 5;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
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
            btnDeleteImage.Text = "удалить";
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
            btnUploadImage.Text = "загрузить\nкартинку";
            btnUploadImage.UseVisualStyleBackColor = false;
            btnUploadImage.Click += btnUploadImage_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F);
            lblTitle.ForeColor = Color.FromArgb(64, 0, 64);
            lblTitle.Location = new Point(22, 19);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(257, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Добавление номеров";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.ForeColor = Color.FromArgb(64, 0, 64);
            lblName.Location = new Point(22, 100);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(43, 15);
            lblName.TabIndex = 1;
            lblName.Text = "номер";
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
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.ForeColor = Color.FromArgb(64, 0, 64);
            lblCapacity.Location = new Point(22, 144);
            lblCapacity.Margin = new Padding(4, 0, 4, 0);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(79, 15);
            lblCapacity.TabIndex = 5;
            lblCapacity.Text = "вместимость";
            // 
            // numericCapacity
            // 
            numericCapacity.BackColor = Color.FromArgb(243, 200, 220);
            numericCapacity.BorderStyle = BorderStyle.FixedSingle;
            numericCapacity.Location = new Point(22, 118);
            numericCapacity.Margin = new Padding(4, 3, 4, 3);
            numericCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCapacity.Name = "numericCapacity";
            numericCapacity.Size = new Size(171, 23);
            numericCapacity.TabIndex = 6;
            numericCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.ForeColor = Color.FromArgb(64, 0, 64);
            lblDescription.Location = new Point(22, 484);
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
            txtDescription.Location = new Point(22, 269);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(513, 212);
            txtDescription.TabIndex = 8;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F);
            lblPrice.ForeColor = Color.FromArgb(64, 0, 64);
            lblPrice.Location = new Point(22, 213);
            lblPrice.Margin = new Padding(4, 0, 4, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "цена";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(158, 157, 189);
            panelRight.Controls.Add(btnAddRoom);
            panelRight.Location = new Point(587, 0);
            panelRight.Margin = new Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(250, 548);
            panelRight.TabIndex = 1;
            // 
            // btnAddRoom
            // 
            btnAddRoom.BackColor = Color.FromArgb(58, 51, 92);
            btnAddRoom.BorderColor = Color.Transparent;
            btnAddRoom.BorderRadius = 15;
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.Font = new Font("Microsoft Sans Serif", 14F);
            btnAddRoom.ForeColor = Color.FromArgb(243, 200, 220);
            btnAddRoom.HoverColor = Color.FromArgb(213, 140, 176);
            btnAddRoom.Location = new Point(35, 453);
            btnAddRoom.Margin = new Padding(4, 3, 4, 3);
            btnAddRoom.MinimumSize = new Size(100, 46);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.PressColor = Color.FromArgb(132, 49, 90);
            btnAddRoom.PressDepth = 0.15F;
            btnAddRoom.Size = new Size(175, 46);
            btnAddRoom.TabIndex = 3;
            btnAddRoom.Text = "сохранить";
            btnAddRoom.UseVisualStyleBackColor = false;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // AddRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 536);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddRoomForm";
            Text = "Добавление номеров";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCapacity).EndInit();
            panelRight.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private Label lblPrice;
        private TextBox txtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown numericCapacity;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Panel panelRight;
        private RoundButton btnAddRoom;
        private RoundButton btnUploadImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private RoundButton btnDeleteImage;
    }
}