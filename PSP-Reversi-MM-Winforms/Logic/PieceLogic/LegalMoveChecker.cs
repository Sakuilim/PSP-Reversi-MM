using PSP_Reversi_MM_Winforms.Logic.DirectionLogic;
using PSP_Reversi_MM_Winforms.Model;
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
        public bool IsLegalMove(bool turner, string color, int row, int col, LEDButton[,] leds)
        {
            int tmp = 0;
            if ((string)leds[row, col].Tag != "green" && (string)leds[row, col].Tag == color)
            {
                MessageBox.Show("Error, this position is already occupied by the other player.");
                return false;
            }

            string[] directions = { "topLeft", "topCenter", "topRight", "rightCenter", "bottomRight", "bottomCenter", "bottomLeft", "leftCenter" };
            bool success = false;
            for (int i = 0; i < 8; i++)
            {
                if (_directionChecker.checkDirection(color, row, col, directions[i], leds) > 0)
                {
                    tmp = _directionChecker.checkDirection(color, row, col, directions[i], leds);
                    if (directions[i] == "topLeft")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, -1, -1, leds, tmp);
                        }
                        success = true;
                    }
                    else if (directions[i] == "topCenter")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, -1, 0, leds, tmp);
                        }
                        success = true;
                    }
                    else if (directions[i] == "topRight")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, -1, 1, leds, tmp);
                        }
                        success = true;
                    }
                    else if (directions[i] == "rightCenter")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, 0, 1, leds, tmp);
                        }
                        success = true;
                    }
                    else if (directions[i] == "bottomRight")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, 1, 1, leds, tmp);
                        }
                        success = true;
                    }
                    else if (directions[i] == "bottomCenter")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, 1, 0, leds, tmp);
                        }
                        success = true;
                    }
                    else if (directions[i] == "bottomLeft")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, 1, -1, leds, tmp);
                        }
                        success = true;
                    }
                    else if (directions[i] == "leftCenter")
                    {
                        if (turner == true)
                        {
                            _colorTurningLogic.colorTurner(color, row, col, 0, -1, leds, tmp);
                        }
                        success = true;
                    }

                }
            }
            return success;
        }
    }
}
