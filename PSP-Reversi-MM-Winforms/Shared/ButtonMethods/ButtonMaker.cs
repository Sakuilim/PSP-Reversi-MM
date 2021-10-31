using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public static class ButtonMaker
    {
        public static LEDButton MakeLEDButton(LEDButton button, int x, int y)
        {
            button = new LEDButton()
            {
                Name = String.Format("{0}:{1}", y, x),
                TabIndex = 10 * x + y,
                Location = new Point(LEDButton.LEDWidth * x + 20,
                                                LEDButton.LEDHeight * y + 20),
            };
            return button;
        }
        public static LEDButton MakeBlackLEDButton(LEDButton button, int x, int y)
        {
            button = new LEDButton()
            {
                Image = Resources.black_piece,
                Name = String.Format("{0}:{1}", y, x),
                TabIndex = 10 * x + y,
                Location = new Point(LEDButton.LEDWidth * x + 20,
                                                LEDButton.LEDHeight * y + 20),
                Tag = "black"
            };
            return button;
        }
        public static LEDButton MakeWhiteLEDButton(LEDButton button, int x, int y)
        {
            button = new LEDButton()
            {
                Image = Resources.white_piece,
                Name = String.Format("{0}:{1}", y, x),
                TabIndex = 10 * x + y,
                Location = new Point(LEDButton.LEDWidth * x + 20,
                                                LEDButton.LEDHeight * y + 20),
                Tag = "white"
            };
            return button;
        }

    }
}
