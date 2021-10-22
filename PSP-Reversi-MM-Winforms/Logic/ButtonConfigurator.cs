using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public static class ButtonConfigurator
    {
        public static LEDButton configureButtonChanges(string color, Bitmap bitmap, LEDButton led)
        {
            led.Image = bitmap;
            led.Tag = color;
            return led;
        }
    }
}
