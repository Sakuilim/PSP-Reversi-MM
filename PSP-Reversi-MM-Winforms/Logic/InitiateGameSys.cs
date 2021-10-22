using PSP_Reversi_MM_Winforms.Constants;
using PSP_Reversi_MM_Winforms.Forms;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public class InitiateGameSys : IInitiateGameSys
    {
        ColorTurningLogic colorTurningLogic = new ColorTurningLogic();
        char color = 'g';
        int sk = 1;
        public LEDButton[,] print_Table(LEDButton[,] leds)
        {
            for (int y = 0; y < leds.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < leds.GetUpperBound(1) + 1; x++)
                {
                    if (x == 3 && y == 3 || x == 4 && y == 4)
                    {
                        leds[y, x] = ButtonMaker.MakeWhiteLEDButton(leds[y, x], y, x);
                    }
                    else if (x == 3 && y == 4 || x == 4 && y == 3)
                    {
                        leds[y, x] = ButtonMaker.MakeBlackLEDButton(leds[y, x], y, x);
                    }
                    else
                    {
                        leds[y, x] = ButtonMaker.MakeLEDButton(leds[y, x], y, x);
                    }
                    leds[y, x].Click += (sender, EventArgs) => { BtnClick(sender, EventArgs, leds); };
                }
            }
            return leds;
        }
        public void BtnClick(object sender, EventArgs e, LEDButton[,] leds)
        {
            if (sk % 2 > 0)
            {
                color = 'b';
            }
            else
            {
                color = 'w';
            }
            LEDButton myButton = sender as LEDButton;
            string[] coord = myButton.Name.Split(':');
            int y = Int32.Parse(coord[0]);
            int x = Int32.Parse(coord[1]);
            MessageBox.Show(" " + y + " " + x + " " + leds[y, x].Tag);
            if (PlacePiece(color, y, x, myButton, leds))
            {
                sk++;
            }
        }
        public GroupBox Return_GroupBox(GroupBox controls, LEDButton[,] leds)
        {
            for (int y = 0; y < leds.GetUpperBound(0) + 1; y++)
                for (int x = 0; x < leds.GetUpperBound(1) + 1; x++)
                    controls.Controls.Add(leds[y, x]);

            return controls;
        }
        public bool PlacePiece(char color, int row, int col, LEDButton led, LEDButton[,] leds)
        {
            if (IsLegalMove(color, led, col, row, leds))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error: This is an illegal move.  Please pick a new location.");
                return false;
            }
        }
        public bool IsLegalMove(char color, LEDButton led, int row, int col, LEDButton[,] leds)
        {
            int tmp = 0;
            if ((string)leds[row, col].Tag != "green")
            {
                MessageBox.Show("Error, this position is already occupied by the other player.");
                return false;
            }

            string[] directions = { "topLeft", "topCenter", "topRight", "rightCenter", "bottomRight", "bottomCenter", "bottomLeft", "leftCenter" };

            for (int i = 0; i < 8; i++)
            {
                if (CheckDirection(color, row, col, directions[i], led, leds) > 0)
                {
                    tmp = CheckDirection(color, row, col, directions[i], led, leds);
                    if (directions[i] == "topLeft")
                    {
                        colorTurningLogic.colorTurner(color,row, col, -1, -1, leds, tmp);
                    }
                    else if (directions[i] == "topCenter")
                    {
                        colorTurningLogic.colorTurner(color,row, col, -1, 0, leds, tmp);
                    }
                    else if (directions[i] == "topRight")
                    {
                        colorTurningLogic.colorTurner(color, row, col, -1, 1, leds, tmp);
                    }
                    else if (directions[i] == "rightCenter")
                    {
                        colorTurningLogic.colorTurner(color, row, col, 0, 1, leds, tmp);
                    }
                    else if (directions[i] == "bottomRight")
                    {
                        colorTurningLogic.colorTurner(color, row, col, 1, 1, leds, tmp);
                    }
                    else if (directions[i] == "bottomCenter")
                    {
                        colorTurningLogic.colorTurner(color, row, col, 1, 0, leds, tmp);
                    }
                    else if (directions[i] == "bottomLeft")
                    {
                        colorTurningLogic.colorTurner(color, row, col, 1, -1, leds, tmp);
                    }
                    else if (directions[i] == "leftCenter")
                    {
                        colorTurningLogic.colorTurner(color, row, col, 0, -1, leds, tmp);
                    }
                    return true;
                }
            }
            return false;
        }
        public List<LEDButton> MakeArrayOfLine(char color, int newRow, int newCol, int rowModifier, int colModifier, LEDButton led, LEDButton[,] leds)
        {
            List<LEDButton> array = new List<LEDButton>();

            int fakeNewRow = newRow;
            int fakeNewCol = newCol;
            fakeNewRow += rowModifier;
            fakeNewCol += colModifier;
            if ((string)leds[fakeNewRow, fakeNewCol].Tag == "green" || newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
            {
                return array;
            }
            else
            {
                array.Add(leds[fakeNewRow, fakeNewCol]);
                do
                {
                    fakeNewRow += rowModifier;
                    fakeNewCol += colModifier;
                    array.Add(leds[fakeNewRow, fakeNewCol]);

                } while (fakeNewRow > 0 && fakeNewCol > 0 && fakeNewRow < 8 - 1 && fakeNewCol < 8 - 1);
                return array;
            }
        }
        public int checkArrayForColorLine(char color, List<LEDButton> array)
        {
            string terminatingTerm;
            if (color == 'w')
            {
                terminatingTerm = "white";
            }
            else
            {
                terminatingTerm = "black";
            }
            int numOpposingColor = 0;
            for (int i = 0; i < array.Count; i++)
            {

                if ((string)array[i].Tag == terminatingTerm)
                {
                    if (numOpposingColor > 0)
                    {
                        return numOpposingColor;
                    }
                }
                else if ((string)array[i].Tag != "green")
                {
                    numOpposingColor++;
                }
            }
            return numOpposingColor;
        }
        
        public int CheckDirection(char color, int newRow, int newCol, string direction, LEDButton led, LEDButton[,] leds)
        {
            List<LEDButton> lineArray;
            switch (direction)
            {
                case "topLeft":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, -1, -1, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                case "topCenter":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, -1, 0, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                case "topRight":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, -1, 1, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                case "rightCenter":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, 0, 1, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                case "bottomRight":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, 1, 1, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                case "bottomCenter":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, 1, 0, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                case "bottomLeft":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, 1, -1, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                case "leftCenter":
                    lineArray = MakeArrayOfLine(color, newRow, newCol, 0, -1, led, leds);
                    return checkArrayForColorLine(color, lineArray);
                default:
                    MessageBox.Show("Error: unidentified direction.");
                    return 0;
            }
        }
    }
}
