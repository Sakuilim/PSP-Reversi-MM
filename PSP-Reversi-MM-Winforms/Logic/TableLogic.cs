using PSP_Reversi_MM_Winforms.Forms;
using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public class TableLogic : GameWindow
    {

        public static TableData Print_Table(TableData newTable)
        {
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    newTable.tableSize[i,j] = 0;

                }
                
            }
            newTable.tableSize[3,3] = 2;
            newTable.tableSize[3,4] = 1;
            newTable.tableSize[4,3] = 1;
            newTable.tableSize[4,4] = 2;

            return newTable;
        }

    }
}
