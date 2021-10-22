using PSP_Reversi_MM_Winforms.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Constants
{
    public class ColorChangingLogic
    {
        public static void ChangeColorBlack(Button button)
        {
            button.Image = Resources.black_piece;
        }

        public static void ChangeColorWhite(Button button)
        {
            button.Image = Resources.white_piece;
        }

    }
}
