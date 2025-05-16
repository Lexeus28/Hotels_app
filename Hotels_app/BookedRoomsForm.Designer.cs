using Hotels_app.Properties;

namespace Hotels_app
{
    partial class BookedRoomsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel headlinePanel;
        private System.Windows.Forms.Label bookedRoomsLabel;
        private RoundButton cancelBookingButton;
        private RoundButton backToHotelsButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            rightPanel = new Panel();
            selectDateLabel = new Label();
            toDatePanel = new Panel();
            txtDateTo = new TextBox();
            toLabel = new Label();
            fromDatePanel = new Panel();
            txtDateFrom = new TextBox();
            fromLabel = new Label();
            cancelBookingButton = new RoundButton();
            backToHotelsButton = new RoundButton();
            leftPanel = new Panel();
            headlinePanel = new Panel();
            bookedRoomsLabel = new Label();
            mainPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            toDatePanel.SuspendLayout();
            fromDatePanel.SuspendLayout();
            leftPanel.SuspendLayout();
            headlinePanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(196, 171, 195);
            mainPanel.Controls.Add(rightPanel);
            mainPanel.Controls.Add(leftPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1202, 749);
            mainPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            rightPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            rightPanel.BackColor = Color.FromArgb(158, 157, 189);
            rightPanel.Controls.Add(selectDateLabel);
            rightPanel.Controls.Add(toDatePanel);
            rightPanel.Controls.Add(fromDatePanel);
            rightPanel.Controls.Add(cancelBookingButton);
            rightPanel.Controls.Add(backToHotelsButton);
            rightPanel.Location = new Point(917, 19);
            rightPanel.Margin = new Padding(3, 4, 3, 4);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(270, 713);
            rightPanel.TabIndex = 1;
            // 
            // selectDateLabel
            // 
            selectDateLabel.AutoSize = true;
            selectDateLabel.Font = new Font("Microsoft Sans Serif", 14F);
            selectDateLabel.ForeColor = Color.FromArgb(64, 0, 64);
            selectDateLabel.Location = new Point(41, 24);
            selectDateLabel.Name = "selectDateLabel";
            selectDateLabel.Size = new Size(196, 29);
            selectDateLabel.TabIndex = 5;
            selectDateLabel.Text = "Забронировано";
            // 
            // toDatePanel
            // 
            toDatePanel.Controls.Add(txtDateTo);
            toDatePanel.Controls.Add(toLabel);
            toDatePanel.Location = new Point(6, 188);
            toDatePanel.Margin = new Padding(3, 4, 3, 4);
            toDatePanel.Name = "toDatePanel";
            toDatePanel.Size = new Size(261, 51);
            toDatePanel.TabIndex = 2;
            // 
            // txtDateTo
            // 
            txtDateTo.BackColor = Color.FromArgb(243, 200, 220);
            txtDateTo.ForeColor = Color.FromArgb(64, 0, 64);
            txtDateTo.Location = new Point(110, 11);
            txtDateTo.Margin = new Padding(3, 4, 3, 4);
            txtDateTo.Name = "txtDateTo";
            txtDateTo.ReadOnly = true;
            txtDateTo.Size = new Size(147, 27);
            txtDateTo.TabIndex = 14;
            // 
            // toLabel
            // 
            toLabel.AutoSize = true;
            toLabel.Font = new Font("Segoe UI", 10F);
            toLabel.ForeColor = Color.FromArgb(64, 0, 64);
            toLabel.Location = new Point(74, 11);
            toLabel.Name = "toLabel";
            toLabel.Size = new Size(30, 23);
            toLabel.TabIndex = 0;
            toLabel.Text = "по";
            // 
            // fromDatePanel
            // 
            fromDatePanel.Controls.Add(txtDateFrom);
            fromDatePanel.Controls.Add(fromLabel);
            fromDatePanel.Location = new Point(6, 129);
            fromDatePanel.Margin = new Padding(3, 4, 3, 4);
            fromDatePanel.Name = "fromDatePanel";
            fromDatePanel.Size = new Size(261, 51);
            fromDatePanel.TabIndex = 1;
            // 
            // txtDateFrom
            // 
            txtDateFrom.BackColor = Color.FromArgb(243, 200, 220);
            txtDateFrom.ForeColor = Color.FromArgb(64, 0, 64);
            txtDateFrom.Location = new Point(109, 11);
            txtDateFrom.Margin = new Padding(3, 4, 3, 4);
            txtDateFrom.Name = "txtDateFrom";
            txtDateFrom.ReadOnly = true;
            txtDateFrom.Size = new Size(148, 27);
            txtDateFrom.TabIndex = 12;
            // 
            // fromLabel
            // 
            fromLabel.AutoSize = true;
            fromLabel.Font = new Font("Segoe UI", 10F);
            fromLabel.ForeColor = Color.FromArgb(64, 0, 64);
            fromLabel.Location = new Point(78, 11);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(18, 23);
            fromLabel.TabIndex = 0;
            fromLabel.Text = "с";
            // 
            // cancelBookingButton
            // 
            cancelBookingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBookingButton.BackColor = Color.FromArgb(75, 21, 53);
            cancelBookingButton.BorderColor = Color.Transparent;
            cancelBookingButton.BorderRadius = 15;
            cancelBookingButton.FlatAppearance.BorderSize = 0;
            cancelBookingButton.FlatStyle = FlatStyle.Flat;
            cancelBookingButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cancelBookingButton.ForeColor = Color.FromArgb(243, 200, 220);
            cancelBookingButton.HoverColor = Color.FromArgb(213, 140, 176);
            cancelBookingButton.Location = new Point(41, 633);
            cancelBookingButton.Margin = new Padding(3, 4, 3, 4);
            cancelBookingButton.MinimumSize = new Size(114, 61);
            cancelBookingButton.Name = "cancelBookingButton";
            cancelBookingButton.PressColor = Color.FromArgb(132, 49, 90);
            cancelBookingButton.PressDepth = 0.15F;
            cancelBookingButton.Size = new Size(181, 61);
            cancelBookingButton.TabIndex = 4;
            cancelBookingButton.Text = Resources.TextCancelBooking;
            cancelBookingButton.UseVisualStyleBackColor = false;
            cancelBookingButton.Click += cancelBookingButton_Click;
            // 
            // backToHotelsButton
            // 
            backToHotelsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            backToHotelsButton.BackColor = Color.FromArgb(58, 51, 92);
            backToHotelsButton.BorderColor = Color.Transparent;
            backToHotelsButton.BorderRadius = 15;
            backToHotelsButton.FlatAppearance.BorderSize = 0;
            backToHotelsButton.FlatStyle = FlatStyle.Flat;
            backToHotelsButton.Font = new Font("Microsoft Sans Serif", 12F);
            backToHotelsButton.ForeColor = Color.FromArgb(243, 200, 220);
            backToHotelsButton.HoverColor = Color.FromArgb(213, 140, 176);
            backToHotelsButton.Location = new Point(41, 564);
            backToHotelsButton.Margin = new Padding(3, 4, 3, 4);
            backToHotelsButton.MinimumSize = new Size(114, 61);
            backToHotelsButton.Name = "backToHotelsButton";
            backToHotelsButton.PressColor = Color.FromArgb(132, 49, 90);
            backToHotelsButton.PressDepth = 0.15F;
            backToHotelsButton.Size = new Size(181, 61);
            backToHotelsButton.TabIndex = 3;
            backToHotelsButton.Text = Resources.TextBackToHotels;
            backToHotelsButton.UseVisualStyleBackColor = false;
            backToHotelsButton.Click += backToHotelsButton_Click;
            // 
            // leftPanel
            // 
            leftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            leftPanel.AutoScroll = true;
            leftPanel.Controls.Add(headlinePanel);
            leftPanel.Location = new Point(16, 19);
            leftPanel.Margin = new Padding(3, 4, 3, 4);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(893, 713);
            leftPanel.TabIndex = 0;
            // 
            // headlinePanel
            // 
            headlinePanel.BackColor = Color.Transparent;
            headlinePanel.Controls.Add(bookedRoomsLabel);
            headlinePanel.Dock = DockStyle.Top;
            headlinePanel.Location = new Point(0, 0);
            headlinePanel.Margin = new Padding(3, 4, 3, 4);
            headlinePanel.Name = "headlinePanel";
            headlinePanel.Size = new Size(893, 63);
            headlinePanel.TabIndex = 0;
            // 
            // bookedRoomsLabel
            // 
            bookedRoomsLabel.AutoSize = true;
            bookedRoomsLabel.Dock = DockStyle.Top;
            bookedRoomsLabel.Font = new Font("Segoe UI", 18F);
            bookedRoomsLabel.ForeColor = Color.FromArgb(64, 0, 64);
            bookedRoomsLabel.Location = new Point(0, 0);
            bookedRoomsLabel.Name = "bookedRoomsLabel";
            bookedRoomsLabel.Size = new Size(274, 41);
            bookedRoomsLabel.TabIndex = 0;
            bookedRoomsLabel.Text = "Забронированные";
            bookedRoomsLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // BookedRoomsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 749);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "BookedRoomsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список забронированных номеров";
            mainPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            toDatePanel.ResumeLayout(false);
            toDatePanel.PerformLayout();
            fromDatePanel.ResumeLayout(false);
            fromDatePanel.PerformLayout();
            leftPanel.ResumeLayout(false);
            headlinePanel.ResumeLayout(false);
            headlinePanel.PerformLayout();
            ResumeLayout(false);
        }

        private TextBox txtDateFrom;
        private TextBox txtDateTo;
        private Label toLabel;
        private Panel fromDatePanel;
        private Label fromLabel;
        private Panel toDatePanel;
        private Label selectDateLabel;
    }
}