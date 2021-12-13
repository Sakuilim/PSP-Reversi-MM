using PSP_Reversi_MM_Winforms.Logic.DirectionLogic;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.StrategyLogic
{
    public class ColorTurningStrategyB : IInitiateColorTurningStrategy
    {
        public ColorTurningStrategyB()
        {

        }
        public bool colorSwitcher(string color, int row, int col, string direction, ButtonTable buttonTable)
        {
            switch (direction)
            {
                case "topLeft":
                   // _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.leftModifier, buttonTable, foundLines);
                    return true;
                case "topCenter":
                  //  _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.emptyModifier, buttonTable, foundLines);
                    return true;
                case "topRight":
                   // _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.rightModifier, buttonTable, foundLines);
                    return true;
                case "rightCenter":
                //    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.rightModifier, buttonTable, foundLines);
                    return true;
                case "bottomRight":
                   // _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.rightModifier, buttonTable, foundLines);
                    return true;
                case "bottomCenter":
                  //  _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.emptyModifier, buttonTable, foundLines);
                    return true;
                case "bottomLeft":
                   // _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.leftModifier, buttonTable, foundLines);
                    return true;
                case "leftCenter":
                 //   _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.leftModifier, buttonTable, foundLines);
                    return true;
                default:
                    MessageBox.Show("Error: unidentified direction.");
                    return false;
            }
}
    }
}
