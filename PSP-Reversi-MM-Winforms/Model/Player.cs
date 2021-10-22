using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Model
{
    public class Player
    {
        private string nameOfPlayer;
        private string color;

        public Player(string nameOfPlayer, string color)
        {
            this.nameOfPlayer = nameOfPlayer;
            this.color = color;
        }
        
        public int amountOfPieces { get; set; }
        public int Sign { get; set; } = 0;
        
    }
}
