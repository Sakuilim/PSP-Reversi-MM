using PSP_Reversi_MM_Winforms.Shared.Model;

namespace PSP_Reversi_MM_Winforms.Shared.HelperMethods
{
    public interface IButtonCreator
    {
        void executeClick(object sender, ButtonTable buttonTable);
    }
}