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
                        int foundLines = _directionChecker.checkDirection(color, row, col, direction, buttonTable);
                        switch (direction)
                        {

                            case "topLeft":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.leftModifier, buttonTable, foundLines);
                                }
                                success = true;
                                break;
                            case "topCenter":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.emptyModifier, buttonTable, foundLines);
                                }
                                success = true;
                                break;
                            case "topRight":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.rightModifier, buttonTable, foundLines);
                                }
                                success = true;
                                break;
                            case "rightCenter":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.rightModifier, buttonTable, foundLines);
                                }
                                success = true;
                                break;
                            case "bottomRight":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.rightModifier, buttonTable, foundLines);
                                }
                                success = true;

                                break;
                            case "bottomCenter":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.emptyModifier, buttonTable, foundLines);
                                }
                                success = true;
                                break;
                            case "bottomLeft":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.leftModifier, buttonTable, foundLines);
                                }
                                success = true;
                                break;
                            case "leftCenter":
                                if (turner)
                                {
                                    _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.leftModifier, buttonTable, foundLines);
                                }
                                success = true;
                                break;
                            default:
                                MessageBox.Show("Error: unidentified direction.");
                                success = false;
                                break;
                        }
                    }
                }
            }
            return success;
        }
    }
}
