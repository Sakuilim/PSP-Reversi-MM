﻿using PSP_Reversi_MM_Winforms.Logic.ColorCheckingLogic;
using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.DirectionLogic
{
    public class DirectionChecker : IDirectionChecker
    {
        private readonly IColorLineChecker _colorLineChecker;
        private readonly IArrayLineChecker _arrayLineChecker;
        public DirectionChecker(IColorLineChecker colorLineChecker, IArrayLineChecker arrayLineChecker)
        {
            _colorLineChecker = colorLineChecker;
            _arrayLineChecker = arrayLineChecker;
        }
        public int checkDirection(string color, int newRow, int newCol, string direction, LEDButton[,] leds)
        {
            List<LEDButton> lineArray;
            switch (direction)
            {
                case "topLeft":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, -1, -1, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                case "topCenter":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, -1, 0, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                case "topRight":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, -1, 1, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                case "rightCenter":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, 0, 1, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                case "bottomRight":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, 1, 1, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                case "bottomCenter":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, 1, 0, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                case "bottomLeft":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, 1, -1, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                case "leftCenter":
                    lineArray = _arrayLineChecker.makeArrayOfLine(color, newRow, newCol, 0, -1, leds);
                    return _colorLineChecker.checkArrayForColorLine(color, lineArray);
                default:
                    MessageBox.Show("Error: unidentified direction.");
                    return 0;
            }
        }

    }
}
