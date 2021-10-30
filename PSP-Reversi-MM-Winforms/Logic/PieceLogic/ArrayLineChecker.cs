using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public class ArrayLineChecker : IArrayLineChecker
    {
        public List<LEDButton> makeArrayOfLine(string color, int newRow, int newCol, int rowModifier, int colModifier, LEDButton[,] leds)
        {
            List<LEDButton> array = new List<LEDButton>();

            newRow += rowModifier;
            newCol += colModifier;
            if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
            {
                return array;
            }
            else if ((string)leds[newRow, newCol].Tag == "green")
            {
                return array;
            }
            else
            {
                array.Add(leds[newRow, newCol]);
                do
                {

                    newRow += rowModifier;
                    newCol += colModifier;
                    if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
                    {
                        return array;
                    }
                    array.Add(leds[newRow, newCol]);

                } while (newRow > 0 && newCol > 0 && newRow < 8 - 1 && newCol < 8 - 1);
                return array;
            }
        }
    }
}
