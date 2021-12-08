using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PSP_Reversi_MM_Winforms.Constants;
using PSP_Reversi_MM_Winforms.Forms;
using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using PSP_Reversi_MM_Winforms.Shared;
using PSP_Reversi_MM_Winforms.Shared.HelperMethods;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public class InitiateGameSys : IInitiateGameSys
    {
        private readonly IButtonCreator _buttonCreator;
        private readonly IButtonMakingHelper _buttonMakingHelper;

        public InitiateGameSys(IButtonCreator buttonCreator, IButtonMakingHelper buttonMakingHelper)
        {
            _buttonCreator = buttonCreator;
            _buttonMakingHelper = buttonMakingHelper;

        }
        public ButtonTable print_Table(ButtonTable buttonTable)
        {
            for (int x = 0; x < buttonTable.Leds.GetUpperBound(0) + 1; x++)
            {
                for (int y = 0; y < buttonTable.Leds.GetUpperBound(1) + 1; y++)
                {
                    _buttonMakingHelper.createButtonTable(buttonTable,x,y);
                    buttonTable.Leds[x, y].Click += startAction(buttonTable);
                }
            }
            return buttonTable;
        }
        private EventHandler startAction(ButtonTable buttonTable)
        {
            return (sender, EventArgs) =>
            {
                _buttonCreator.executeClick(sender, buttonTable);
            };
        }
    }
}
