using PSP_Reversi_MM_Winforms.Model;
using System.Collections.Generic;

namespace PSP_Reversi_MM_Winforms.Logic.ColorCheckingLogic
{
    public interface IColorLineChecker
    {
        int checkArrayForColorLine(string color, List<LEDButton> array);
    }
}