using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;

namespace PSP_Reversi_MM_Winforms.Logic.DirectionLogic
{
    public interface IDirectionChecker
    {
        int checkDirection(string color, int newRow, int newCol, string direction, ButtonTable buttonTable);
    }
}