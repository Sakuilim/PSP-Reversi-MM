using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Constants
{
    public class GetPlayerSign
    {
        public static int OpponentSignGetter(Player player)
        {
            if(player.Sign == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

    }
}
