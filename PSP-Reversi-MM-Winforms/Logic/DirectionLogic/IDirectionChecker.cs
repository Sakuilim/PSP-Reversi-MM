using PSP_Reversi_MM_Winforms.Model;

namespace PSP_Reversi_MM_Winforms.Logic.DirectionLogic
{
    public interface IDirectionChecker
    {
        int checkDirection(string color, int newRow, int newCol, string direction, LEDButton[,] leds);
    }
}