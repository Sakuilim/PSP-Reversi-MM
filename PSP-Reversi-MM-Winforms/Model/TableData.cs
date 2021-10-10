using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Model
{
    public class TableData
    {
        public int totalAmountPieces { get; set; }
        public int[,] tableSize = new int[8, 8];
    }
}
