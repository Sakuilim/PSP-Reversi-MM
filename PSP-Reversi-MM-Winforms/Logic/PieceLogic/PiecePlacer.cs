using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public class PiecePlacer : IPiecePlacer
    {
        private readonly ILegalMoveChecker _legalMoveChecker;
        public PiecePlacer(ILegalMoveChecker legalMoveChecker)
        {
            _legalMoveChecker = legalMoveChecker;
        }
        public bool PlacePiece(string color, int row, int col, LEDButton[,] leds)
        {
            if (_legalMoveChecker.IsLegalMove(color, col, row, leds))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error: This is an illegal move.  Please pick a new location.");
                return false;
            }
        }
    }
}
