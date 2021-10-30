using PSP_Reversi_MM_Winforms.Model;
using System;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public interface IInitiateGameSys
    {
        void BtnClick(object sender, EventArgs e, LEDButton[,] leds);
        LEDButton[,] print_Table(LEDButton[,] leds);
    }
}