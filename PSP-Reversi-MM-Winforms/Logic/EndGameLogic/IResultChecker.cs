using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;

namespace PSP_Reversi_MM_Winforms.Logic.EndGameLogic
{
    public interface IResultChecker
    {
        bool check_Winner(string color, ButtonTable buttonTable);
    }
}