using PSP_Reversi_MM_Winforms.Logic;
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
    public partial class WelcomeWindow : Form
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
