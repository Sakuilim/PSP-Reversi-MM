using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Constants
{
    public class PointLogic
    {
        public string PointChecker(bool possibleMove, Player player, Player player1)
        {
            if (possibleMove == false)
            {
                if (player.amountOfPieces > player1.amountOfPieces)
                {
                    return "Winner is Player 1!";
                }
                else if (player.amountOfPieces < player1.amountOfPieces)
                {
                    return "Winner is Player 2!";
                }
                else if (player.amountOfPieces == player1.amountOfPieces)
                {
                    return "It's a Draw!";
                }
            }
            return "Game Continues";
        }
    }
}
