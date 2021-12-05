using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Shared.Model
{
    public class ButtonTable
    {
        public LEDButton[,] Leds { get; set; } = new LEDButton[8, 8];
    }
}
