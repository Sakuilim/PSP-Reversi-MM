using PSP_Reversi_MM_Winforms.Model;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public interface IPiecePlacer
    {
        bool PlacePiece(string color, int row, int col, LEDButton[,] leds);
    }
}