﻿using Microsoft.Extensions.Logging;
using PSP_Reversi_MM_Winforms.Constants;
using PSP_Reversi_MM_Winforms.Logic;
using PSP_Reversi_MM_Winforms.Logic.SystemLogic;
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
    public partial class GameWindow : Form, IGameWindow
    {
        private readonly ISystemInitializer _systemInitializer;
        private readonly IInitiateGameSys _initiateGameSys;

        LEDButton[,] leds = new LEDButton[8, 8];
        int turn = 1;
        public GameWindow(ISystemInitializer systemInitializer, IInitiateGameSys initiateGameSys)
        {
            _systemInitializer = systemInitializer;
            _initiateGameSys = initiateGameSys;
            InitializeComponent();

        }
        public GameWindow Create()
        {
            return new GameWindow(_systemInitializer, _initiateGameSys);
        }
        private LEDButton[,] startGame()
        {
            _initiateGameSys.print_Table(leds);
            return leds;
        }
        public void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (turn % 2 > 0)
            {
                label2.Text = "Black";
            }
            else
            {
                label2.Text = "White";
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            _systemInitializer.Return_GroupBox(groupBox1, startGame());
        }
    }
}
