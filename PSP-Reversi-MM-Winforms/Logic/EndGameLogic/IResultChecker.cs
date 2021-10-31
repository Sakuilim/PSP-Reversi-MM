using PSP_Reversi_MM_Winforms.Model;

namespace PSP_Reversi_MM_Winforms.Logic.EndGameLogic
{
    public interface IResultChecker
    {
        bool check_Winner(string color,LEDButton[,] leds);
    }
}