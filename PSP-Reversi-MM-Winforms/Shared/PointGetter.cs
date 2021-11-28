using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Constants
{
    public class PointLogic : IPointLogic
    {
        public void PointChecker(ButtonTable buttonTable)
        {
            for (int x = 0; x < buttonTable.Leds.GetUpperBound(0) + 1; x++)
            {
                for (int y = 0; y < buttonTable.Leds.GetUpperBound(1) + 1; y++)
                {
                    if ((string)buttonTable.Leds[x, y].Tag == "black")
                    {
                        Player.blackAmountOfPieces++;
                    }
                    else
                    {
                        Player.whiteAmountOfPieces++;
                    }
                }
            }
            if (Player.blackAmountOfPieces > Player.whiteAmountOfPieces)
            {
                MessageBox.Show($"Winner is Black! with {Player.blackAmountOfPieces} pieces");
            }
            else if (Player.blackAmountOfPieces < Player.whiteAmountOfPieces)
            {
                MessageBox.Show($"Winner is White! with {Player.whiteAmountOfPieces} pieces");
            }
            else if (Player.blackAmountOfPieces == Player.whiteAmountOfPieces)
            {
                MessageBox.Show($"It's a Draw! with both teams having {Player.whiteAmountOfPieces} pieces");
            }
        }
    }
}
