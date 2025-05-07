using LetGetAPass.PInvoke;
using LetGetAPass.UI.Pages;
using LetGetAPass.UI.Themes;
using System.Runtime.Versioning;

namespace LetGetAPass
{
    [SupportedOSPlatform("windows")]
    public partial class MainWindow : Form
    {
        private ThemeUI theme;
        public MainWindow()
        {
            InitializeComponent();
            theme = new DefaultDarkThemeUI();
            foreach (TabPage tab in tabs.TabPages)
                tab.AutoSize = false;
        }

        /// <summary>Applying <paramref name="state"/> using current theme</summary>
        /// <param name="state">True = Active, False = Inactive, otherwise DEATH</param>
        public void ApplyAppearance(bool? state)
        {
            Color back, fore, link, sback, sfore, wback, wfore, caption, captionText, border;
            switch (state)
            {
                case true: //ACTIVE
                    caption = theme.WACaptionBackground;
                    captionText = theme.WACaptionForeground;
                    border = theme.WABorderground;

                    wback = theme.WABackground;
                    wfore = theme.WAForeground;

                    back = theme.ABackground;
                    fore = theme.AForeground;
                    link = theme.LForeground;
                    sback = theme.SBackground;
                    sfore = theme.SForeground;
                    break;
                case false: //INACTIVE
                    caption = theme.WInACaptionBackground;
                    captionText = theme.WInACaptionForeground;
                    border = theme.WInABorderground;

                    wback = theme.WInABackground;
                    wfore = theme.WInAForeground;

                    back = theme.InABackground;
                    fore = theme.InAForeground;
                    link = theme.InALForeground;
                    sback = theme.InASBackground;
                    sfore = theme.InASForeground;
                    break;
                default: //DEATH
                    caption = theme.WDCaptionBackground;
                    captionText = theme.WDCaptionForeground;
                    border = theme.WDBorderground;

                    wback = theme.WDBackground;
                    wfore = theme.WDForeground;

                    back = theme.DBackground;
                    fore = theme.DForeground;
                    link = theme.DLForeground;
                    sback = theme.DSBackground;
                    sfore = theme.DSForeground;
                    break;
            }

            DwmApi.CustomWindow(caption, captionText, border, Handle);
            BackColor = wback;
            ForeColor = wfore;

            tabs.BackColor = sback;
            tabs.ForeColor = sfore;
            foreach (TabPage tab in tabs.TabPages)
            {
                tab.BackColor = sback;
                tab.ForeColor = sfore;
            } //Tabs

            {
                Stack<Control> applyTo = [];
                {
                    applyTo.Push(settingsPage);
                } //Add pages to stack
                while (applyTo.TryPop(out Control? apply))
                {
                    bool isStrict = false, isLink = false;
                    if (apply.Tag is string tag)
                    {
                        isStrict = tag.Contains("strict", StringComparison.OrdinalIgnoreCase);
                        isLink = tag.Contains("link", StringComparison.OrdinalIgnoreCase);
                    } //Check tags

                    {
                        apply.BackColor = isStrict
                            ? sback
                            : back;
                        apply.ForeColor = isLink
                            ? link
                            : (isStrict
                                ? sfore
                                : fore);
                    } //Change appearance (with tag-check!)

                    foreach (Control sub in apply.Controls)
                        applyTo.Push(sub); //Refill stack until we have other sub controls

                    if (apply is IThemedPage page)
                        page.ApplyAppearance(back, fore, link, sback, sfore);
                } //Process each control in stack
            } //Pages
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplyAppearance(null);
            Thread.Sleep(500);
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            ApplyAppearance(true);
        }

        private void MainWindow_Deactivate(object sender, EventArgs e)
        {
            ApplyAppearance(false);
        }
    }
}