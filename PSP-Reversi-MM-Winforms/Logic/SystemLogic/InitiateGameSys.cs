using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PSP_Reversi_MM_Winforms.Constants;
using PSP_Reversi_MM_Winforms.Forms;
using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Properties;
using PSP_Reversi_MM_Winforms.Shared;
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
        private readonly ILogger _log;
        private readonly IConfiguration _config;
        private readonly IColorTurningLogic _colorTurningLogic;
        private readonly IPiecePlacer _piecePlacer;
        private readonly ILabelChangingLogic _labelChangingLogic;
        private readonly ITurns _turns;

        public InitiateGameSys(ITurns turns,ILabelChangingLogic labelChangingLogic,IPiecePlacer piecePlacer, IColorTurningLogic colorTurningLogic, ILogger<InitiateGameSys> log, IConfiguration config)
        {
            _turns = turns;
            _labelChangingLogic = labelChangingLogic;
            _piecePlacer = piecePlacer;
            _colorTurningLogic = colorTurningLogic;
            _log = log;
            _config = config;
        }
        public LEDButton[,] print_Table(LEDButton[,] leds)
        {
            for (int y = 0; y < leds.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < leds.GetUpperBound(1) + 1; x++)
                {
                    if (x == 3 && y == 3 || x == 4 && y == 4)
                    {
                        leds[y, x] = ButtonMaker.MakeWhiteLEDButton(leds[y, x], y, x);
                    }
                    else if (x == 3 && y == 4 || x == 4 && y == 3)
                    {
                        leds[y, x] = ButtonMaker.MakeBlackLEDButton(leds[y, x], y, x);
                    }
                    else
                    {
                        leds[y, x] = ButtonMaker.MakeLEDButton(leds[y, x], y, x);
                    }
                    leds[y, x].Click += (sender, EventArgs) => { BtnClick(sender, EventArgs, leds); };
                }
            }
            return leds;
        }
        public void BtnClick(object sender, EventArgs e, LEDButton[,] leds)
        {
            string color = _labelChangingLogic.getLabel(_turns.currentTurn);
            if (_turns.currentTurn % 2 > 0)
            {
                _log.LogInformation("Its { color }", color);
            }
            else
            {
                _log.LogInformation("Its { color }", color);
            }
            LEDButton myButton = sender as LEDButton;
            string[] coord = myButton.Name.Split(':');
            MessageBox.Show(myButton.Tag + " ");
            int y = Int32.Parse(coord[0]);
            int x = Int32.Parse(coord[1]);
            if (_piecePlacer.PlacePiece(color, y, x, leds))
            {
                _turns.currentTurn++;
            }
        }
    }
}
