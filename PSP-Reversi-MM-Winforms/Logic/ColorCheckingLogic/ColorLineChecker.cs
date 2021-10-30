using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Logic.ColorCheckingLogic
{
    public class ColorLineChecker : IColorLineChecker
    {
        public int checkArrayForColorLine(string color, List<LEDButton> array)
        {

            int numOpposingColor = 0;
            for (int i = 0; i < array.Count; i++)
            {

                if ((string)array[i].Tag == color)
                {
                    if (numOpposingColor > 0)
                    {
                        return numOpposingColor;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if ((string)array[i].Tag == "green")
                {
                    return 0;
                }
                else
                {
                    numOpposingColor++;
                }
            }
            return 0;
        }
    }
}
