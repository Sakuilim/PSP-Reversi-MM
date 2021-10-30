using Microsoft.Extensions.Logging;
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
        private readonly ILogger _log;
        private readonly IGameWindow _gameWindow;
        public WelcomeWindow(IGameWindow gameWindow,ILogger<WelcomeWindow> log)
        {
            _gameWindow = gameWindow;
            _log = log; 
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameWindow newGameWindow = _gameWindow.Create();
            newGameWindow.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
