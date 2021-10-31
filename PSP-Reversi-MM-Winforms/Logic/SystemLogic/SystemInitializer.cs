using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.SystemLogic
{
    public class SystemInitializer : ISystemInitializer
    {
        public GroupBox Return_GroupBox(GroupBox controls, LEDButton[,] leds)
        {
            for (int y = 0; y < leds.GetUpperBound(0) + 1; y++)
                for (int x = 0; x < leds.GetUpperBound(1) + 1; x++)
                    controls.Controls.Add(leds[y, x]);

            return controls;
        }
    }
}
