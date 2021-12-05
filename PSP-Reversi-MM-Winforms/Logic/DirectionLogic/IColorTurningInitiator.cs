using PSP_Reversi_MM_Winforms.Shared.Model;

namespace PSP_Reversi_MM_Winforms.Logic.DirectionLogic
{
    public interface IColorTurningInitiator
    {
        bool initiateColorTurning(string color, int row, int col, bool turner, ButtonTable buttonTable);
    }
}