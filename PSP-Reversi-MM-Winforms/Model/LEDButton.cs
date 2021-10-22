using PSP_Reversi_MM_Winforms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Model
{
    public class LEDButton : Button
    {
        public const int LEDWidth = 110;
        public const int LEDHeight = 110;

        public LEDButton()
        {
            Image = Resources.green_color;
            ForeColor = Color.Black;
            FlatStyle = FlatStyle.Flat;
            Size = new Size(LEDWidth, LEDHeight);
            UseVisualStyleBackColor = false;
            Tag = "green";
        }
    }
}
