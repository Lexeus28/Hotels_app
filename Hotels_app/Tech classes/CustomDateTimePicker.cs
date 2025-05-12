using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hotels_app
{
    public class CustomDateTimePicker : DateTimePicker
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int DTM_SHOWCALENDAR = 0x1000 + 4; // Команда для показа календаря
        private const int DTM_SETMCCOLOR = 0x1000 + 8;   // Команда для установки цвета фона календаря

        private Color _calendarBackColor = Color.FromArgb(243, 200, 220); // Цвет фона календаря
        private readonly Font _iconFont = new Font("Segoe UI Emoji", 12F, FontStyle.Regular); // Шрифт для значка

        public CustomDateTimePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = _calendarBackColor;
            this.CalendarMonthBackground = _calendarBackColor;

            // Устанавливаем цвет фона календаря через WinAPI
            SendMessage(this.Handle, DTM_SETMCCOLOR, (IntPtr)1, _calendarBackColor.ToArgb());

            // Перехватываем событие MouseDown
            this.MouseDown += (s, e) =>
            {
                // Программное раскрытие календаря
                SendMessage(this.Handle, DTM_SHOWCALENDAR, IntPtr.Zero, IntPtr.Zero);
            };
        }

        public Color CalendarBackColor
        {
            get => _calendarBackColor;
            set
            {
                _calendarBackColor = value;
                this.BackColor = value;
                this.Invalidate(); // Перерисовываем элемент
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            try
            {
                SetWindowTheme(this.Handle, "", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке стиля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F) // WM_PAINT
            {
                using (var g = Graphics.FromHwnd(this.Handle))
                {
                    using (var brush = new SolidBrush(_calendarBackColor))
                    {
                        g.FillRectangle(brush, this.ClientRectangle);
                    }

                    // Рисуем текст
                    using (var textBrush = new SolidBrush(Color.Black)) // Цвет текста
                    {
                        var text = this.Text;
                        var textSize = TextRenderer.MeasureText(text, this.Font);
                        var textLocation = new Point((this.ClientSize.Width - textSize.Width) / 2, (this.ClientSize.Height - textSize.Height) / 2);
                        g.DrawString(text, this.Font, textBrush, textLocation);
                    }

                    // Рисуем значок календаря
                    DrawCalendarIcon(g);
                }
            }
        }

        private void DrawCalendarIcon(Graphics g)
        {
            // Значок календаря (эмодзи 📅)
            string calendarIcon = "📅";

            // Позиция значка
            var iconLocation = new Point(
                this.ClientSize.Width - 30, // Отступ справа
                (this.ClientSize.Height - 16) / 2 - 4 // Отступ сверху (уменьшаем на 4 пикселя)
            );

            // Рисуем значок
            using (var iconBrush = new SolidBrush(Color.Black)) // Цвет значка
            {
                g.DrawString(calendarIcon, _iconFont, iconBrush, iconLocation);
            }
        }
    }
}