using PSP_Reversi_MM_Winforms.Logic.EndGameLogic;
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
        private readonly IResultChecker _resultChecker;
        public PiecePlacer(ILegalMoveChecker legalMoveChecker, IResultChecker resultChecker)
        {
            _legalMoveChecker = legalMoveChecker;
            _resultChecker = resultChecker;
        }
        public bool PlacePiece(string color, int col, int row, LEDButton[,] leds)
        {
            //if(!_resultChecker.check_Winner(color,leds))
            //{
            //    MessageBox.Show("Error: ENDGAME");
            //    return false;
            //}
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
