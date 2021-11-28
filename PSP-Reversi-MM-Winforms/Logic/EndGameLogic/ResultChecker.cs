using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic.EndGameLogic
{
    public class ResultChecker : IResultChecker
    {
        private readonly ILegalMoveChecker _legalMoveChecker;
        public ResultChecker(ILegalMoveChecker legalMoveChecker)
        {
            _legalMoveChecker = legalMoveChecker;
        }
        public bool check_Winner(string color, ButtonTable buttonTable)
        {
            bool isValid = true;

            for (int y = 0; y < buttonTable.leds.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < buttonTable.leds.GetUpperBound(1) + 1; x++)
                {
                    if ((string)buttonTable.leds[y, x].Tag == "green" && !_legalMoveChecker.IsLegalMove(false, color, y, x, buttonTable))
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
    }
}
