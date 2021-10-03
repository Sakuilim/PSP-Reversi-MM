using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public class TableLogic
    {

        TableLogic()
        {

        }
        public void Print_Table()
        {
            TableData newTable = new TableData();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    newTable.tableSize[i][j] = 0;
                }
                newTable.tableSize[3][3] = 2;
                newTable.tableSize[3][4] = 1;
                newTable.tableSize[4][3] = 1;
                newTable.tableSize[4][4] = 2;
            }
        }

        public void Prepare_Table()
        {

        }
    }
}
