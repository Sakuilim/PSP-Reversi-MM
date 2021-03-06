using Microsoft.Extensions.Logging;
using PSP_Reversi_MM_Winforms.Constants;
using PSP_Reversi_MM_Winforms.Logic;
using PSP_Reversi_MM_Winforms.Logic.SystemLogic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using PSP_Reversi_MM_Winforms.Shared;
using PSP_Reversi_MM_Winforms.Shared.Model;
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
    public partial class GameWindow : Form, IGameWindow
    {
        private readonly ISystemInitializer _systemInitializer;
        private readonly IInitiateGameSys _initiateGameSys;
        private readonly ILabelChangingLogic _labelChangingLogic;
        ButtonTable buttonTable = new ButtonTable();
        public GameWindow(ILabelChangingLogic labelChangingLogic, ISystemInitializer systemInitializer, IInitiateGameSys initiateGameSys)
        {
            _systemInitializer = systemInitializer;
            _initiateGameSys = initiateGameSys;
            _labelChangingLogic = labelChangingLogic;
            InitializeComponent();
            
        }

        public GameWindow Create()
        {
            return new GameWindow(_labelChangingLogic, _systemInitializer, _initiateGameSys);
        }
        private ButtonTable startGame()
        {
            
            return _initiateGameSys.print_Table(buttonTable);
        }
        private void startBtn_Click(object sender, EventArgs e)
        {
            _systemInitializer.Return_GroupBox(groupBox1, startGame());
        }
    }
}
