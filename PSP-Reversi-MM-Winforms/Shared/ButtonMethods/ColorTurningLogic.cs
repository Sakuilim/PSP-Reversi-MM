using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public class ColorTurningLogic : IColorTurningLogic
    {
        public void colorTurner(string color, int newRow, int newCol, int rowModifier, int colModifier, ButtonTable buttonTable, int howMany)
        {
            do
            {
                if (color == "black")
                {
                    ButtonConfigurator.configureButtonChanges("black", Resources.black_piece, buttonTable.Leds[newRow, newCol]);
                }
                else
                {
                    ButtonConfigurator.configureButtonChanges("white", Resources.white_piece, buttonTable.Leds[newRow, newCol]);
                }
                newRow += rowModifier;
                newCol += colModifier;

                howMany--;

            } while (howMany >= 0);

        }
    }
}
