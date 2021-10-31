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
        private readonly IPiecePlacer _piecePlacer;
        private readonly ILabelChangingLogic _labelChangingLogic;
        private readonly ITurns _turns;
        private readonly ITurnLogic _turnLogic;

        public InitiateGameSys(ITurnLogic turnLogic, ITurns turns, ILabelChangingLogic labelChangingLogic, IPiecePlacer piecePlacer, ILogger<InitiateGameSys> log)
        {
            _turnLogic = turnLogic;
            _turns = turns;
            _labelChangingLogic = labelChangingLogic;
            _piecePlacer = piecePlacer;
            _log = log;

        }
        public LEDButton[,] print_Table(LEDButton[,] leds)
        {
            for (int x = 0; x < leds.GetUpperBound(0) + 1; x++)
            {
                for (int y = 0; y < leds.GetUpperBound(1) + 1; y++)
                {
                    if (x == 3 && y == 3 || x == 4 && y == 4)
                    {
                        leds[x, y] = ButtonMaker.MakeWhiteLEDButton(leds[x, y], x, y);
                    }
                    else if (x == 3 && y == 4 || x == 4 && y == 3)
                    {
                        leds[x, y] = ButtonMaker.MakeBlackLEDButton(leds[x, y], x, y);
                    }
                    else
                    {
                        leds[x, y] = ButtonMaker.MakeLEDButton(leds[x, y], x, y);
                    }

                    leds[x, y].Click += (sender, EventArgs) => { BtnClick(sender,  leds); };
                }
            }
            return leds;
        }
        private void BtnClick(object sender, LEDButton[,] leds)
        {
            
            LEDButton myButton = sender as LEDButton;
            string[] coord = myButton.Name.Split(':');
            int y = Int32.Parse(coord[0]);
            int x = Int32.Parse(coord[1]);
            string color = _labelChangingLogic.getLabel(_turns.currentTurn);
            if (_piecePlacer.PlacePiece(color, x, y, leds))
            {
                _log.LogInformation(" { color } made a move", color);
                _turns.currentTurn = _turnLogic.TurnIncreaser(_turns.currentTurn);
                color = _labelChangingLogic.getLabel(_turns.currentTurn);
                GameWindow.label2.Text = color;
            }
        }
    }
}
