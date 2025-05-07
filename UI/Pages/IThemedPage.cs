namespace LetGetAPass.UI.Pages
{
    /// <summary>Page, which has additional theme logic</summary>
    public interface IThemedPage
    {
        /// <summary>Refreshes this pages using information about appearance from theme</summary>
        /// <param name="back"></param>
        /// <param name="fore"></param>
        /// <param name="link"></param>
        /// <param name="sback"></param>
        /// <param name="sfore"></param>
        public void ApplyAppearance(Color back, Color fore, Color link, Color sback, Color sfore);
    }
}