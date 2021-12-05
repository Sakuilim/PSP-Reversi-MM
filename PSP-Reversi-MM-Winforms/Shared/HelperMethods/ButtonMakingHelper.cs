using PSP_Reversi_MM_Winforms.Logic;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Shared.HelperMethods
{
    public class ButtonMakingHelper : IButtonMakingHelper
    {
        public void createButtonTable(ButtonTable buttonTable, int x, int y)
        {
            if ((x != 3 || y != 3) && (x != 4 || y != 4))
            {
                buttonTable.Leds[x, y] = (x == 3 && y == 4) || (x == 4 && y == 3)
                    ? ButtonMaker.MakeBlackLEDButton(buttonTable.Leds[x, y], x, y)
                    : ButtonMaker.MakeLEDButton(buttonTable.Leds[x, y], x, y);
            }
            else
            {
                buttonTable.Leds[x, y] = ButtonMaker.MakeWhiteLEDButton(buttonTable.Leds[x, y], x, y);
            }
        }
    }
}

