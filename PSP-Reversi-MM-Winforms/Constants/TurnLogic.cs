using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Constants
{
    public class TurnLogic
    {
        public int TurnIncreaser(int currentTurn)
        {
            if(currentTurn == 0)
            {
                return 1;
            }
            else
            {
                currentTurn++;
                return currentTurn;
            }
            
        }
    }
}
