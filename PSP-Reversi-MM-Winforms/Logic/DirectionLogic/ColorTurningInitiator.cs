using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.DirectionLogic
{
    public class ColorTurningInitiator : IColorTurningInitiator
    {
        private readonly IColorTurningLogic _colorTurningLogic;
        private readonly IDirectionChecker _directionChecker;
        public ColorTurningInitiator(IDirectionChecker directionChecker, IColorTurningLogic colorTurningLogic)
        {
            _directionChecker = directionChecker;
            _colorTurningLogic = colorTurningLogic;
        }
        public bool initiateColorTurning(string color, int row, int col, bool turner, ButtonTable buttonTable)
        {
            string[] directions = { "topLeft", "topCenter", "topRight", "rightCenter", "bottomRight", "bottomCenter", "bottomLeft", "leftCenter" };
            bool success = false;
            {
                foreach (var direction in directions)
                {
                    if (_directionChecker.checkDirection(color, row, col, direction, buttonTable) > 0)
                    {
                        success = colorSwitcher(color, row, col, turner, direction, buttonTable);
                    }
                }
            }
            return success;
        }
        private bool colorSwitcher(string color, int row, int col, bool turner, string direction, ButtonTable buttonTable)
        {
            int foundLines = _directionChecker.checkDirection(color, row, col, direction, buttonTable);
            switch (direction)
            {
                case "topLeft":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.leftModifier, turner, buttonTable, foundLines);
                    return true;
                case "topCenter":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.emptyModifier, turner, buttonTable, foundLines);
                    return true;
                case "topRight":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.rightModifier, turner, buttonTable, foundLines);
                    return true;
                case "rightCenter":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.rightModifier, turner, buttonTable, foundLines);
                    return true;
                case "bottomRight":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.rightModifier, turner, buttonTable, foundLines);
                    return true;
                case "bottomCenter":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.emptyModifier, turner, buttonTable, foundLines);
                    return true;
                case "bottomLeft":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.leftModifier, turner, buttonTable, foundLines);
                    return true;
                case "leftCenter":
                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.leftModifier, turner, buttonTable, foundLines);
                    return true;
                default:
                    MessageBox.Show("Error: unidentified direction.");
                    return false;
            }
        }
    }
}
