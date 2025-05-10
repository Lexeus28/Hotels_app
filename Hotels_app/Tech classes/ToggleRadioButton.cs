using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_app.classes
{
    public class ToggleRadioButton : RadioButton
    {
        private bool _isHandlingClick = false;

        public ToggleRadioButton()
        {
            this.CheckedChanged += ToggleRadioButton_CheckedChanged;
        }

        private void ToggleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_isHandlingClick) return;

            _isHandlingClick = true;

            // Если радиокнопка уже активна, отключаем её
            if (this.Checked)
            {
                BeginInvoke(new Action(() =>
                {
                    this.Checked = false;
                }));
            }
            else
            {
                // Если радиокнопка не активна, сбрасываем все остальные в группе
                foreach (Control control in this.Parent.Controls)
                {
                    if (control is RadioButton radioButton && radioButton != this)
                    {
                        radioButton.Checked = false;
                    }
                }
            }

            _isHandlingClick = false;
        }
    }
}
