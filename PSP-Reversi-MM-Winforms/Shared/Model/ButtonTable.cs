using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Shared.Model
{
    public class ButtonTable
    {
        private LEDButton[,] leds = new LEDButton[8, 8];

        public LEDButton[,] Leds
        {
            get { return leds; }
            set { leds = value; }
        }
    }
}
