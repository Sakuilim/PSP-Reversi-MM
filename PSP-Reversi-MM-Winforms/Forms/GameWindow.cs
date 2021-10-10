using PSP_Reversi_MM_Winforms.Logic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Forms
{
    public partial class GameWindow : Form
    {
        
        public GameWindow() 
        {
            InitializeComponent();
            TableData tableData = new TableData();
            TableLogic.Print_Table(tableData);
        }
       
        public void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        private void Make_Table(TableData tableData)
        {
            if(tableData.tableSize[3,3] == 2)
            {
               // pictureBox28.Image = Properties.Resources.white_piece;

            }
            if(tableData.tableSize[3, 4] == 1)
            {
               // pictureBox29.Image = Properties.Resources.black_piece;
            }
            if(tableData.tableSize[4, 3] == 1)
            {
               // pictureBox61.Image = Properties.Resources.white_piece;

            }
            if(tableData.tableSize[4, 4] == 2)
            {
               // pictureBox60.Image = Properties.Resources.black_piece;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button29.Image = Properties.Resources.black_piece;
        }

        private void button29_Click(object sender, EventArgs e)
        {

        }
    }
}
