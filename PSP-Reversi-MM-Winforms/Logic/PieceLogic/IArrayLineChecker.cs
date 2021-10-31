using PSP_Reversi_MM_Winforms.Model;
using System.Collections.Generic;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public interface IArrayLineChecker
    {
        List<LEDButton> makeArrayOfLine(string color, int newRow, int newCol, int rowModifier, int colModifier, LEDButton[,] leds);
    }
}