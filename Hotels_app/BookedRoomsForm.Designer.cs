//namespace Hotels_app
//{
//    partial class BookedRoomsForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        private System.Windows.Forms.Panel mainPanel;
//        private System.Windows.Forms.Panel leftPanel;
//        private System.Windows.Forms.Panel rightPanel;
//        private System.Windows.Forms.Label bookedRoomsLabel;
//        private System.Windows.Forms.Panel roomsListingPanel;
//        private RoundButton cancelBookingButton;
//        private RoundButton backToHotelsButton;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            mainPanel = new Panel();
//            rightPanel = new Panel();
//            cancelBookingButton = new RoundButton();
//            backToHotelsButton = new RoundButton();
//            leftPanel = new Panel();
//            roomsListingPanel = new Panel();
//            bookedRoomsLabel = new Label();
//            mainPanel.SuspendLayout();
//            rightPanel.SuspendLayout();
//            leftPanel.SuspendLayout();
//            SuspendLayout();
//            // 
//            // mainPanel
//            // 
//            mainPanel.Controls.Add(rightPanel);
//            mainPanel.Controls.Add(leftPanel);
//            mainPanel.Dock = DockStyle.Fill;
//            mainPanel.Location = new Point(0, 0);
//            mainPanel.Name = "mainPanel";
//            mainPanel.Size = new Size(875, 562);
//            mainPanel.TabIndex = 0;
//            // 
//            // rightPanel
//            // 
//            rightPanel.BackColor = Color.FromArgb(158, 157, 189);
//            rightPanel.Controls.Add(cancelBookingButton);
//            rightPanel.Controls.Add(backToHotelsButton);
//            rightPanel.Dock = DockStyle.Right;
//            rightPanel.Location = new Point(613, 0);
//            rightPanel.Name = "rightPanel";
//            rightPanel.Size = new Size(262, 562);
//            rightPanel.TabIndex = 1;
//            // 
//            // cancelBookingButton
//            // 
//            cancelBookingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
//            cancelBookingButton.BackColor = Color.FromArgb(58, 51, 92);
//            cancelBookingButton.BorderColor = Color.Transparent;
//            cancelBookingButton.BorderRadius = 15;
//            cancelBookingButton.FlatAppearance.BorderSize = 0;
//            cancelBookingButton.FlatStyle = FlatStyle.Flat;
//            cancelBookingButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
//            cancelBookingButton.ForeColor = Color.FromArgb(243, 200, 220);
//            cancelBookingButton.HoverColor = Color.FromArgb(213, 140, 176);
//            cancelBookingButton.Location = new Point(57, 475);
//            cancelBookingButton.MinimumSize = new Size(100, 46);
//            cancelBookingButton.Name = "cancelBookingButton";
//            cancelBookingButton.PressColor = Color.FromArgb(132, 49, 90);
//            cancelBookingButton.PressDepth = 0.15F;
//            cancelBookingButton.Size = new Size(158, 46);
//            cancelBookingButton.TabIndex = 4;
//            cancelBookingButton.Text = "отменить\nбронирование";
//            cancelBookingButton.UseVisualStyleBackColor = false;
//            cancelBookingButton.Click += cancelBookingButton_Click;
//            // 
//            // backToHotelsButton
//            // 
//            backToHotelsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
//            backToHotelsButton.BackColor = Color.FromArgb(58, 51, 92);
//            backToHotelsButton.BorderColor = Color.Transparent;
//            backToHotelsButton.BorderRadius = 15;
//            backToHotelsButton.FlatAppearance.BorderSize = 0;
//            backToHotelsButton.FlatStyle = FlatStyle.Flat;
//            backToHotelsButton.Font = new Font("Microsoft Sans Serif", 12F);
//            backToHotelsButton.ForeColor = Color.FromArgb(243, 200, 220);
//            backToHotelsButton.HoverColor = Color.FromArgb(213, 140, 176);
//            backToHotelsButton.Location = new Point(57, 423);
//            backToHotelsButton.MinimumSize = new Size(100, 46);
//            backToHotelsButton.Name = "backToHotelsButton";
//            backToHotelsButton.PressColor = Color.FromArgb(132, 49, 90);
//            backToHotelsButton.PressDepth = 0.15F;
//            backToHotelsButton.Size = new Size(158, 46);
//            backToHotelsButton.TabIndex = 3;
//            backToHotelsButton.Text = "вернуться к отелям";
//            backToHotelsButton.UseVisualStyleBackColor = false;
//            backToHotelsButton.Click += backToHotelsButton_Click;
//            // 
//            // leftPanel
//            // 
//            leftPanel.BackColor = Color.FromArgb(196, 181, 196);
//            leftPanel.Controls.Add(roomsListingPanel);
//            leftPanel.Controls.Add(bookedRoomsLabel);
//            leftPanel.Dock = DockStyle.Left;
//            leftPanel.Location = new Point(0, 0);
//            leftPanel.Name = "leftPanel";
//            leftPanel.Size = new Size(613, 562);
//            leftPanel.TabIndex = 0;
//            // 
//            // roomsListingPanel
//            // 
//            roomsListingPanel.AutoScroll = true;
//            roomsListingPanel.BackColor = Color.Transparent;
//            roomsListingPanel.Dock = DockStyle.Fill;
//            roomsListingPanel.Location = new Point(0, 60);
//            roomsListingPanel.Name = "roomsListingPanel";
//            roomsListingPanel.Padding = new Padding(18, 19, 18, 19);
//            roomsListingPanel.Size = new Size(613, 502);
//            roomsListingPanel.TabIndex = 1;
//            // 
//            // bookedRoomsLabel
//            // 
//            bookedRoomsLabel.Dock = DockStyle.Top;
//            bookedRoomsLabel.Font = new Font("Segoe UI", 18F);
//            bookedRoomsLabel.ForeColor = Color.FromArgb(64, 0, 64);
//            bookedRoomsLabel.Location = new Point(0, 0);
//            bookedRoomsLabel.Name = "bookedRoomsLabel";
//            bookedRoomsLabel.Size = new Size(613, 60);
//            bookedRoomsLabel.TabIndex = 0;
//            bookedRoomsLabel.Text = "Забронированные";
//            bookedRoomsLabel.TextAlign = ContentAlignment.BottomLeft;
//            // 
//            // BookedRoomsForm
//            // 
//            AutoScaleDimensions = new SizeF(7F, 15F);
//            AutoScaleMode = AutoScaleMode.Font;
//            ClientSize = new Size(875, 562);
//            Controls.Add(mainPanel);
//            Name = "BookedRoomsForm";
//            StartPosition = FormStartPosition.CenterScreen;
//            Text = "Booked Rooms";
//            mainPanel.ResumeLayout(false);
//            rightPanel.ResumeLayout(false);
//            leftPanel.ResumeLayout(false);
//            ResumeLayout(false);
//        }
//    }
//}