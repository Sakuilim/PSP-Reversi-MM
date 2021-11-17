using PSP_Reversi_MM_Winforms.Model;
using System.Windows.Forms;

namespace PSP_Reversi_MM_Winforms.Logic.SystemLogic
{
    public interface ISystemInitializer
    {
        void Return_GroupBox(GroupBox controls, LEDButton[,] leds);
    }
}