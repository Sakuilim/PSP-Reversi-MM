using System;

namespace PSP_Reversi_MM_Winforms.Forms
{
    public interface IGameWindow
    {
        GameWindow Create();
        void InitializeComponent();
    }
}