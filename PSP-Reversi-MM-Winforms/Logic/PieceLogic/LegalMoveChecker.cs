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
        private readonly IColorTurningLogic _colorTurningLogic;
        private readonly IDirectionChecker _directionChecker;
        public LegalMoveChecker(IDirectionChecker directionChecker, IColorTurningLogic colorTurningLogic)
        {
            _directionChecker = directionChecker;
            _colorTurningLogic = colorTurningLogic;
        }
        public bool IsLegalMove(bool turner, string color, int row, int col, ButtonTable buttonTable)
        {
            int tmp = 0;
            if ((string)buttonTable.leds[row, col].Tag != "green" && (string)buttonTable.leds[row, col].Tag != color)
            {
                MessageBox.Show("Error, this position is already occupied by the other player.");
                return false;
            }
            else if ((string)buttonTable.leds[row, col].Tag == color)
            {
                MessageBox.Show("Error, this position is already occupied by you!");
                return false;
            }

            string[] directions = { "topLeft", "topCenter", "topRight", "rightCenter", "bottomRight", "bottomCenter", "bottomLeft", "leftCenter" };
            bool success = false;
            foreach (var direction in directions)
            {
                if (_directionChecker.checkDirection(color, row, col, direction, buttonTable) > 0)
                {
                    tmp = _directionChecker.checkDirection(color, row, col, direction, buttonTable);
                    if (direction == "topLeft")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.leftModifier, buttonTable, tmp);
                        }
                        success = true;
                    }
                    else if (direction == "topCenter")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.emptyModifier, buttonTable, tmp);
                        }
                        success = true;
                    }
                    else if (direction == "topRight")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.downModifier, SideModifiers.rightModifier, buttonTable, tmp);
                        }
                        success = true;
                    }
                    else if (direction == "rightCenter")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.rightModifier, buttonTable, tmp);
                        }
                        success = true;
                    }
                    else if (direction == "bottomRight")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.rightModifier, buttonTable, tmp);
                        }
                        success = true;
                    }
                    else if (direction == "bottomCenter")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.emptyModifier, buttonTable, tmp);
                        }
                        success = true;
                    }
                    else if (direction == "bottomLeft")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.upModifier, SideModifiers.leftModifier, buttonTable, tmp);
                        }
                        success = true;
                    }
                    else if (direction == "leftCenter")
                    {
                        if (turner)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, SideModifiers.emptyModifier, SideModifiers.leftModifier, buttonTable, tmp);
                        }
                        success = true;
                    }

                }
            }
            return success;
        }
    }
}
