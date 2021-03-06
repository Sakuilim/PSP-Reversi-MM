using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic.PieceLogic
{
    public class ArrayLineChecker : IArrayLineChecker
    {
        public List<LEDButton> makeArrayOfLine(int newRow, int newCol, int rowModifier, int colModifier, ButtonTable buttonTable)
        {
            List<LEDButton> array = new List<LEDButton>();

            newRow += rowModifier;
            newCol += colModifier;
            if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
            {
                return array;
            }
            else if ((string)buttonTable.Leds[newRow, newCol].Tag == "green")
            {
                return array;
            }
            else
            {
                array.Add(buttonTable.Leds[newRow, newCol]);
                do
                {
                    newRow += rowModifier;
                    newCol += colModifier;
                    if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
                    {
                        return array;
                    }
                    array.Add(buttonTable.Leds[newRow, newCol]);

                } while (newRow > 0 && newCol > 0 && newRow < 8 - 1 && newCol < 8 - 1);
                return array;
            }
        }
    }
}
