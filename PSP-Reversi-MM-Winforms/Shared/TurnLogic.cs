using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Constants
{
    public class TurnLogic : ITurnLogic
    {
        public int TurnIncreaser(int? currentTurn)
        {
            if (currentTurn == null)
            {
                return TurnIncreaser(0);
            }
            else
            {
                if (currentTurn == 0)
                {
                    return 1;
                }
                else
                {
                    currentTurn++;
                    return (int)currentTurn;
                }
            }
        }
    }
}
