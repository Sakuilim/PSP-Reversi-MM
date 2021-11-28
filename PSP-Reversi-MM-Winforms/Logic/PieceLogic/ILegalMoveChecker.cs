using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public interface ILegalMoveChecker
    {
        bool IsLegalMove(bool turner,string color, int row, int col, ButtonTable buttonTable);
    }
}