using PSP_Reversi_MM_Winforms.Model;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public interface IPiecePlacer
    {
        string PlacePiece(string color, int row, int col, LEDButton[,] leds);
    }
}