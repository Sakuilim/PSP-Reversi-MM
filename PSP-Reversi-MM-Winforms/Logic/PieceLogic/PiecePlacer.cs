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
        public string PlacePiece(string color, int col, int row, LEDButton[,] leds)
        {
            if(!_legalMoveChecker.IsLegalMove(true, color, col, row, leds))
            {
                return "illegal";
            }
            if (_resultChecker.check_Winner(color, leds))
            {
                MessageBox.Show("Error: ENDGAME");
                return "end";
            }
            else
            {
                return "legal";
            }
        }
    }
}
