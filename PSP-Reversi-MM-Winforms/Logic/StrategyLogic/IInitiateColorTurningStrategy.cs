using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic.StrategyLogic
{
    public interface IInitiateColorTurningStrategy
    {
        public bool colorSwitcher(string color, int row, int col, string direction, ButtonTable buttonTable);
    }
}
