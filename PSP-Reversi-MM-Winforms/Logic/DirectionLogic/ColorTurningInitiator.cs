using PSP_Reversi_MM_Winforms.Logic.StrategyLogic;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.DirectionLogic
{
    public class ColorTurningInitiator : IColorTurningInitiator
    {
        private IInitiateColorTurningStrategy _initiateColorTurningStrategy;
        private IColorTurningLogic _colorTurningLogic;
        private IDirectionChecker _directionChecker;
        public ColorTurningInitiator()
        {

        }
        public void SetStrategy(IDirectionChecker directionChecker, IColorTurningLogic colorTurningLogic, IInitiateColorTurningStrategy initiateColorTurningStrategy)
        {
            _directionChecker = directionChecker;
            _colorTurningLogic = colorTurningLogic;
            _initiateColorTurningStrategy = initiateColorTurningStrategy;
        }
        public ColorTurningInitiator(IDirectionChecker directionChecker, IColorTurningLogic colorTurningLogic, IInitiateColorTurningStrategy initiateColorTurningStrategy)
        {
            _directionChecker = directionChecker;
            _colorTurningLogic = colorTurningLogic;
            _initiateColorTurningStrategy = initiateColorTurningStrategy;
        }
        public bool initiateColorTurning(string color, int row, int col,bool turner, ButtonTable buttonTable)
        {
            string[] directions = { "topLeft", "topCenter", "topRight", "rightCenter", "bottomRight", "bottomCenter", "bottomLeft", "leftCenter" };
            bool success = false;
            {
                foreach (var direction in directions)
                {
                    if (_directionChecker.checkDirection(color, row, col, direction, buttonTable) > 0)
                    {
                        if (turner)
                        {
                            success = _initiateColorTurningStrategy.colorSwitcher(color, row, col, direction, buttonTable);
                        }
                    }
                }
            }
            return success;
        }
    }
}
