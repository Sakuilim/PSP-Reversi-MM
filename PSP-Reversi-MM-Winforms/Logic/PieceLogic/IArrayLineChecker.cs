using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System.Collections.Generic;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public interface IArrayLineChecker
    {
        List<LEDButton> makeArrayOfLine(string color, int newRow, int newCol, int rowModifier, int colModifier, ButtonTable buttonTable);
    }
}