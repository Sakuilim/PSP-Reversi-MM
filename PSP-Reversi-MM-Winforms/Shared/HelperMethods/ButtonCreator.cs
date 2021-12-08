using Microsoft.Extensions.Logging;
using PSP_Reversi_MM_Winforms.Constants;
using PSP_Reversi_MM_Winforms.Forms;
using PSP_Reversi_MM_Winforms.Logic;
using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Shared.HelperMethods
{
    public class ButtonCreator : IButtonCreator
    {
        private readonly ILogger _log;
        private readonly IPiecePlacer _piecePlacer;
        private readonly ILabelChangingLogic _labelChangingLogic;
        private readonly ITurnLogic _turnLogic;
        private readonly IPointLogic _pointLogic;
        public ButtonCreator(IPointLogic pointLogic, ITurnLogic turnLogic, ILabelChangingLogic labelChangingLogic, IPiecePlacer piecePlacer, ILogger<InitiateGameSys> log)
        {
            _pointLogic = pointLogic;
            _turnLogic = turnLogic;
            _labelChangingLogic = labelChangingLogic;
            _piecePlacer = piecePlacer;
            _log = log;
        }
        private readonly Turns turns = new Turns();
        public void executeClick(object sender, ButtonTable buttonTable)
        {
            if (!BtnClick(sender, buttonTable))
            {
                _pointLogic.PointChecker(buttonTable);
                GameWindow obj = (GameWindow)Application.OpenForms["GameWindow"];
                obj.Close();
            }
        }
        private bool BtnClick(object sender, ButtonTable buttonTable)
        {
            LEDButton myButton = sender as LEDButton;
            string[] coord = myButton.Name.Split(':');
            int y = Int32.Parse(coord[0]);
            int x = Int32.Parse(coord[1]);
            string color = _labelChangingLogic.getLabel(turns.currentTurn);
            string placePiece = _piecePlacer.PlacePiece(color, x, y, buttonTable);
            if (placePiece == "legal")
            {
                _log.LogInformation(" { color } made a move {x} {y}", color, x, y);
                turns.currentTurn = _turnLogic.TurnIncreaser(turns.currentTurn);
                color = _labelChangingLogic.getLabel(turns.currentTurn);
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
