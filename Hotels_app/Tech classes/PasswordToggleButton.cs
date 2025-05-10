using System.Drawing;
using System.Windows.Forms;

public class PasswordToggleButton : Button
{
    private readonly TextBox _passwordTextBox; // Привязанный текстовый поле

    public PasswordToggleButton(TextBox passwordTextBox)
    {
        _passwordTextBox = passwordTextBox;

        // Настройка внешнего вида кнопки
        BackColor = Color.FromArgb(158, 157, 189); // Цвет фона
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0; // Убираем границы
        Size = new Size(30, 30); // Размер кнопки

        // Подписываемся на события
        Paint += OnPaint;
        Click += OnClick;
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
        // Определяем, находится ли пароль в режиме видимости
        bool isPasswordVisible = _passwordTextBox.PasswordChar == '\0';

        // Рисуем иконку глаза
        using (var brush = new SolidBrush(Color.FromArgb(243, 200, 220))) // Розовый цвет
        {
            string eyeIcon = isPasswordVisible ? "👁️‍🗨️" : "👁️‍🗨️"; // Открытый или закрытый глаз

            // Вычисляем размер текста
            var textSize = TextRenderer.MeasureText(eyeIcon, new Font("Segoe UI Emoji", 16F, FontStyle.Regular));

            // Вычисляем позицию для центрирования
            int x = (Width - textSize.Width) / 2;
            int y = (Height - textSize.Height) / 2;

            // Рисуем текст
            e.Graphics.DrawString(
                eyeIcon,
                new Font("Segoe UI Emoji", 16F, FontStyle.Regular),
                brush,
                new PointF(x, y) // Центрируем иконку
            );

            // Если пароль скрыт, рисуем перечеркнутый глаз
            if (!isPasswordVisible)
            {
                using (var pen = new Pen(Color.FromArgb(243, 200, 220), 2)) // Розовый цвет
                {
                    // Линия слева сверху направо вниз
                    e.Graphics.DrawLine(pen, x + 5, y + 5, x + textSize.Width - 5, y + textSize.Height - 5);
                }
            }
        }
    }

    private void OnClick(object sender, EventArgs e)
    {
        // Переключаем состояние видимости пароля
        _passwordTextBox.PasswordChar = _passwordTextBox.PasswordChar == '\0' ? '•' : '\0';

        // Перерисовываем кнопку
        Invalidate();
    }
}