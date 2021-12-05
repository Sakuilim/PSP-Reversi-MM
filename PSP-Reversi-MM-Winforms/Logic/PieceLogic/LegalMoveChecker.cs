using PSP_Reversi_MM_Winforms.Logic.DirectionLogic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public class LegalMoveChecker : ILegalMoveChecker
    {
        private readonly IColorTurningInitiator _colorTurningInitiator;

        public LegalMoveChecker(IColorTurningInitiator colorTurningInitiator)
        {
            _colorTurningInitiator = colorTurningInitiator;
        }
        public bool IsLegalMove(bool turner, string color, int row, int col, ButtonTable buttonTable)
        {
            if ((string)buttonTable.Leds[row, col].Tag != "green")
            {
                MessageBox.Show("Error, this position is already occupied.");
                return false;
            }

            return _colorTurningInitiator.initiateColorTurning(color,row,col,turner,buttonTable);
        }
    }
}

