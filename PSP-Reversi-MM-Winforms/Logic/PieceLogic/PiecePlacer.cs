using PSP_Reversi_MM_Winforms.Logic.EndGameLogic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
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
        public string PlacePiece(string color, int row, int col, ButtonTable buttonTable)
        {
            if(!_legalMoveChecker.IsLegalMove(true, color, row, col, buttonTable))
            {
                return "illegal";
            }
            else if (_resultChecker.check_Winner(color, buttonTable))
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
