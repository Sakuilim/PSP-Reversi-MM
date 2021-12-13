using PSP_Reversi_MM_Winforms.Logic.DirectionLogic;
using PSP_Reversi_MM_Winforms.Logic.StrategyLogic;
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
        private readonly IColorTurningLogic _colorTurningLogic;
        private readonly IDirectionChecker _directionChecker;
        ColorTurningInitiator colorTurningInitiator = new ColorTurningInitiator();
        public LegalMoveChecker(IColorTurningLogic colorTurningLogic, IDirectionChecker directionChecker)
        {
            _colorTurningLogic = colorTurningLogic;
            _directionChecker = directionChecker;
        }
        public bool IsLegalMove(bool turner, string color, int row, int col, ButtonTable buttonTable)
        {
            if ((string)buttonTable.Leds[row, col].Tag != "green")
            {
                MessageBox.Show("Error, this position is already occupied.");
                return false;
            }
            if (turner)
            {
                colorTurningInitiator.SetStrategy(_directionChecker, _colorTurningLogic,new ColorTurningStrategyA(_directionChecker,_colorTurningLogic));
                return colorTurningInitiator.initiateColorTurning(color, row, col, turner, buttonTable);
            }
            colorTurningInitiator.SetStrategy(_directionChecker, _colorTurningLogic, new ColorTurningStrategyB());
            return colorTurningInitiator.initiateColorTurning(color, row, col, turner, buttonTable);
        }
    }
}

