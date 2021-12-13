using PSP_Reversi_MM_Winforms.Shared.HelperMethods;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Shared.TestHelperMethods
{
    public static class TestHelperMethods
    {
        public static ButtonTable GetSut()
        {
            ButtonTable buttonTable = new ButtonTable();
            ButtonMakingHelper buttonMakingHelper = new ButtonMakingHelper();
            for (int x = 0; x < buttonTable.Leds.GetUpperBound(0) + 1; x++)
            {
                for (int y = 0; y < buttonTable.Leds.GetUpperBound(1) + 1; y++)
                {
                    buttonMakingHelper.createButtonTable(buttonTable, x, y);
                }
            }
            return buttonTable;
        }
    }
}
