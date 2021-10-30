using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Shared
{
    public class LabelChangingLogic : ILabelChangingLogic
    {
        public string getLabel(int? turn)
        {
            if (turn == null)
            {
                return getLabel(1);
            }
            else
            {
                if (turn % 2 == 0)
                {
                    return "black";
                }
                else
                {
                    return "white";
                }
            }

        }
    }
}
