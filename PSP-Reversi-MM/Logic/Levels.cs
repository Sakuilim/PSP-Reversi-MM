using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_Reversi_MM.Logic
{
    public class Levels
    {
        public static List<string> LoadComboBoxLevels()
        {
            List<string> stringArr = new List<string>()
            {
             "Easy",
             "Medium",
             "Hard"
            };
            return stringArr;
        }
    }
}
