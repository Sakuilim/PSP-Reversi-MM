using PSP_Reversi_MM_Winforms.Model;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;

namespace PSP_Reversi_MM_Winforms.Logic
{
    public interface IInitiateGameSys
    {
        ButtonTable print_Table(ButtonTable buttonTable);
    }
}