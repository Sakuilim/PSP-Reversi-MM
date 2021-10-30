using PSP_Reversi_MM_Winforms.Model;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public interface IColorTurningLogic
    {
        void colorTurner(string color, int newRow, int newCol, int rowModifier, int colModifier, LEDButton[,] leds, int howMany);
    }
}