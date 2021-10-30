using System;

namespace PSP_Reversi_MM_Winforms.Forms
{
    public interface IGameWindow
    {
        GameWindow Create();
        void groupBox1_Enter(object sender, EventArgs e);
        void InitializeComponent();
    }
}