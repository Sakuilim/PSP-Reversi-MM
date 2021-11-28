using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Shared.Model
{
    public static class SideModifiers
    {
        public static int emptyModifier => 0;
        public static int leftModifier => -1;
        public static int upModifier => 1;
        public static int downModifier => -1;
        public static int rightModifier => 1;
    }
}
