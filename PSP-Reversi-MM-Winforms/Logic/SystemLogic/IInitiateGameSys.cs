using PSP_Reversi_MM_Winforms.Model;
using System;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public interface IInitiateGameSys
    {
        LEDButton[,] print_Table(LEDButton[,] leds);
    }
}