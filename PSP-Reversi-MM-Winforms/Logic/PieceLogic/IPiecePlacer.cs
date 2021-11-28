using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public interface IPiecePlacer
    {
        string PlacePiece(string color, int row, int col, ButtonTable buttonTable);
    }
}