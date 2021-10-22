using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic
{
    interface IInitiateGameSys
    {
        public LEDButton[,] print_Table(LEDButton[,] leds);


    }
}
