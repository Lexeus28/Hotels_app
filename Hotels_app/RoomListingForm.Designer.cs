using System.Windows.Forms;
using Hotels_app.Properties;
namespace Hotels_app
{
    partial class RoomListingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel roomTypePanel;
        private System.Windows.Forms.Label familyRoomLabel;
        private System.Windows.Forms.Label twoRoomLabel;
        private System.Windows.Forms.Label oneRoomLabel;
        private System.Windows.Forms.Label selectDateLabel;
        private System.Windows.Forms.Panel fromDatePanel;
        private System.Windows.Forms.Label fromLabel;
        private DateTimePicker fromDatePicker;
        private System.Windows.Forms.Panel toDatePanel;
        private DateTimePicker toDatePicker;
        private System.Windows.Forms.Label toLabel;
        private RoundButton bookButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            mainPanel = new Panel();
            rightPanel = new Panel();
            bookButton = new RoundButton();
            toDatePanel = new Panel();
            toDatePicker = new DateTimePicker();
            toLabel = new Label();
            fromDatePanel = new Panel();
            fromDatePicker = new DateTimePicker();
            fromLabel = new Label();
            selectDateLabel = new Label();
            leftPanel = new Panel();
            roomTypePanel = new Panel();
            oneRoomLabel = new Label();
            twoRoomLabel = new Label();
            familyRoomLabel = new Label();
            mainPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            toDatePanel.SuspendLayout();
            fromDatePanel.SuspendLayout();
            leftPanel.SuspendLayout();
            roomTypePanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(196, 171, 195);
            mainPanel.Controls.Add(rightPanel);
            mainPanel.Controls.Add(leftPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1052, 562);
            mainPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            rightPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            rightPanel.BackColor = Color.FromArgb(158, 157, 189);
            rightPanel.Controls.Add(bookButton);
            rightPanel.Controls.Add(toDatePanel);
            rightPanel.Controls.Add(fromDatePanel);
            rightPanel.Controls.Add(selectDateLabel);
            rightPanel.Location = new Point(802, 14);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(236, 535);
            rightPanel.TabIndex = 1;
            // 
            // bookButton
            // 
            bookButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bookButton.BackColor = Color.FromArgb(58, 51, 92);
            bookButton.BorderColor = Color.Transparent;
            bookButton.BorderRadius = 15;
            bookButton.FlatAppearance.BorderSize = 0;
            bookButton.FlatStyle = FlatStyle.Flat;
            bookButton.Font = new Font("Microsoft Sans Serif", 12F);
            bookButton.ForeColor = Color.FromArgb(243, 200, 220);
            bookButton.HoverColor = Color.FromArgb(213, 140, 176);
            bookButton.Location = new Point(58, 432);
            bookButton.MinimumSize = new Size(100, 46);
            bookButton.Name = "bookButton";
            bookButton.PressColor = Color.FromArgb(132, 49, 90);
            bookButton.PressDepth = 0.15F;
            bookButton.Size = new Size(131, 46);
            bookButton.TabIndex = 3;
            bookButton.Text = Resources.TextBook;
            bookButton.UseVisualStyleBackColor = false;
            bookButton.Click += BookButton_Click;
            // 
            // toDatePanel
            // 
            toDatePanel.Controls.Add(toDatePicker);
            toDatePanel.Controls.Add(toLabel);
            toDatePanel.Location = new Point(5, 141);
            toDatePanel.Name = "toDatePanel";
            toDatePanel.Size = new Size(228, 38);
            toDatePanel.TabIndex = 2;
            // 
            // toDatePicker
            // 
            toDatePicker.BackColor = Color.FromArgb(243, 200, 220);
            toDatePicker.CalendarMonthBackground = Color.FromArgb(243, 200, 220);
            toDatePicker.Format = DateTimePickerFormat.Short;
            toDatePicker.Location = new Point(96, 8);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Size = new Size(129, 23);
            toDatePicker.TabIndex = 1;
            // 
            // toLabel
            // 
            toLabel.AutoSize = true;
            toLabel.Font = new Font("Segoe UI", 10F);
            toLabel.ForeColor = Color.FromArgb(64, 0, 64);
            toLabel.Location = new Point(65, 8);
            toLabel.Name = "toLabel";
            toLabel.Size = new Size(25, 19);
            toLabel.TabIndex = 0;
            toLabel.Text = "по";
            // 
            // fromDatePanel
            // 
            fromDatePanel.Controls.Add(fromDatePicker);
            fromDatePanel.Controls.Add(fromLabel);
            fromDatePanel.Location = new Point(5, 97);
            fromDatePanel.Name = "fromDatePanel";
            fromDatePanel.Size = new Size(228, 38);
            fromDatePanel.TabIndex = 1;
            // 
            // fromDatePicker
            // 
            fromDatePicker.BackColor = Color.FromArgb(243, 200, 220);
            fromDatePicker.CalendarMonthBackground = Color.FromArgb(243, 200, 220);
            fromDatePicker.Format = DateTimePickerFormat.Short;
            fromDatePicker.Location = new Point(95, 8);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Size = new Size(130, 23);
            fromDatePicker.TabIndex = 1;
            // 
            // fromLabel
            // 
            fromLabel.AutoSize = true;
            fromLabel.Font = new Font("Segoe UI", 10F);
            fromLabel.ForeColor = Color.FromArgb(64, 0, 64);
            fromLabel.Location = new Point(68, 8);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(15, 19);
            fromLabel.TabIndex = 0;
            fromLabel.Text = "с";
            // 
            // selectDateLabel
            // 
            selectDateLabel.AutoSize = true;
            selectDateLabel.Font = new Font("Microsoft Sans Serif", 17F);
            selectDateLabel.ForeColor = Color.FromArgb(64, 0, 64);
            selectDateLabel.Location = new Point(31, 9);
            selectDateLabel.Name = "selectDateLabel";
            selectDateLabel.Size = new Size(180, 29);
            selectDateLabel.TabIndex = 0;
            selectDateLabel.Text = "выберите дату";
            // 
            // leftPanel
            // 
            leftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            leftPanel.AutoScroll = true;
            leftPanel.Controls.Add(roomTypePanel);
            leftPanel.Location = new Point(14, 14);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(781, 535);
            leftPanel.TabIndex = 0;
            // 
            // roomTypePanel
            // 
            roomTypePanel.BackColor = Color.Transparent;
            roomTypePanel.Controls.Add(oneRoomLabel);
            roomTypePanel.Controls.Add(twoRoomLabel);
            roomTypePanel.Controls.Add(familyRoomLabel);
            roomTypePanel.Dock = DockStyle.Top;
            roomTypePanel.Location = new Point(0, 0);
            roomTypePanel.Name = "roomTypePanel";
            roomTypePanel.Size = new Size(781, 47);
            roomTypePanel.TabIndex = 0;
            // 
            // oneRoomLabel
            // 
            oneRoomLabel.AutoSize = true;
            oneRoomLabel.Cursor = Cursors.Hand;
            oneRoomLabel.Font = new Font("Segoe UI", 17F);
            oneRoomLabel.ForeColor = Color.FromArgb(64, 0, 64);
            oneRoomLabel.Location = new Point(30, 7);
            oneRoomLabel.Name = "oneRoomLabel";
            oneRoomLabel.Size = new Size(155, 31);
            oneRoomLabel.TabIndex = 0;
            oneRoomLabel.Text = "одноместные";
            oneRoomLabel.Click += oneRoomLabel_Click;
            // 
            // twoRoomLabel
            // 
            twoRoomLabel.AutoSize = true;
            twoRoomLabel.Cursor = Cursors.Hand;
            twoRoomLabel.Font = new Font("Segoe UI", 17F);
            twoRoomLabel.ForeColor = Color.FromArgb(64, 0, 64);
            twoRoomLabel.Location = new Point(280, 7);
            twoRoomLabel.Name = "twoRoomLabel";
            twoRoomLabel.Size = new Size(139, 31);
            twoRoomLabel.TabIndex = 1;
            twoRoomLabel.Text = "двуместные";
            twoRoomLabel.Click += twoRoomLabel_Click;
            // 
            // familyRoomLabel
            // 
            familyRoomLabel.AutoSize = true;
            familyRoomLabel.Cursor = Cursors.Hand;
            familyRoomLabel.Font = new Font("Segoe UI", 17F);
            familyRoomLabel.ForeColor = Color.FromArgb(64, 0, 64);
            familyRoomLabel.Location = new Point(530, 7);
            familyRoomLabel.Name = "familyRoomLabel";
            familyRoomLabel.Size = new Size(119, 31);
            familyRoomLabel.TabIndex = 2;
            familyRoomLabel.Text = "семейные";
            familyRoomLabel.Click += familyRoomLabel_Click;
            // 
            // RoomListingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 562);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RoomListingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список номеров";
            mainPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            toDatePanel.ResumeLayout(false);
            toDatePanel.PerformLayout();
            fromDatePanel.ResumeLayout(false);
            fromDatePanel.PerformLayout();
            leftPanel.ResumeLayout(false);
            roomTypePanel.ResumeLayout(false);
            roomTypePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
