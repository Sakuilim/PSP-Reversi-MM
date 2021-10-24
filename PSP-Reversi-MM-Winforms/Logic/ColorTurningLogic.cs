using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public class ColorTurningLogic
    {
        public void colorTurner(string color,int newRow, int newCol, int rowModifier, int colModifier, LEDButton[,] leds, int howMany)
        {
            do
            {
                if (color == "black")
                {
                    ButtonConfigurator.configureButtonChanges("black", Resources.black_piece, leds[newRow, newCol]);
                }
                else
                {
                    ButtonConfigurator.configureButtonChanges("white", Resources.white_piece, leds[newRow, newCol]);
                }
                newRow += rowModifier;
                newCol += colModifier;

                howMany--;

            } while (howMany >= 0);
        }
    }
}
