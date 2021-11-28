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
        private readonly IPointLogic _pointLogic;

        public InitiateGameSys(IPointLogic pointLogic, ITurnLogic turnLogic, ITurns turns, ILabelChangingLogic labelChangingLogic, IPiecePlacer piecePlacer, ILogger<InitiateGameSys> log)
        {
            _pointLogic = pointLogic;
            _turnLogic = turnLogic;
            _turns = turns;
            _labelChangingLogic = labelChangingLogic;
            _piecePlacer = piecePlacer;
            _log = log;

        }
        public void print_Table(ButtonTable buttonTable)
        {
            for (int x = 0; x < buttonTable.leds.GetUpperBound(0) + 1; x++)
            {
                for (int y = 0; y < buttonTable.leds.GetUpperBound(1) + 1; y++)
                {
                    if (x == 3 && y == 3 || x == 4 && y == 4)
                    {
                        buttonTable.leds[x, y] = ButtonMaker.MakeWhiteLEDButton(buttonTable.leds[x, y], x, y);
                    }
                    else if (x == 3 && y == 4 || x == 4 && y == 3)
                    {
                        buttonTable.leds[x, y] = ButtonMaker.MakeBlackLEDButton(buttonTable.leds[x, y], x, y);
                    }
                    else
                    {
                        buttonTable.leds[x, y] = ButtonMaker.MakeLEDButton(buttonTable.leds[x, y], x, y);
                    }
                    buttonTable.leds[x, y].Click += (sender, EventArgs) =>
                    {
                        if (BtnClick(sender, buttonTable) == false)
                        {
                            _pointLogic.PointChecker(buttonTable.leds);
                            GameWindow obj = (GameWindow)Application.OpenForms["GameWindow"];
                            obj.Close();
                        };
                    };
                }
            }
        }
        private bool BtnClick(object sender, ButtonTable buttonTable)
        {
            LEDButton myButton = sender as LEDButton;
            string[] coord = myButton.Name.Split(':');
            int y = Int32.Parse(coord[0]);
            int x = Int32.Parse(coord[1]);
            string color = _labelChangingLogic.getLabel(_turns.currentTurn);
            string placePiece = _piecePlacer.PlacePiece(color, x, y, buttonTable);
            if (placePiece == "legal")
            {
                _log.LogInformation(" { color } made a move", color);
                _turns.currentTurn = _turnLogic.TurnIncreaser(_turns.currentTurn);
                color = _labelChangingLogic.getLabel(_turns.currentTurn);
                GameWindow.label2.Text = color;
                return true;
            }
            else if (placePiece == "end")
            {
                return false;
            }
            return true;
        }
    }
}
