namespace LetGetAPass.UI.Themes
{
    public class DefaultDarkThemeUI : CompileTimeThemeUI
    {
        public DefaultDarkThemeUI()
        {
            Name = "Default DARK";
            Author = "Spearton";
            CreatedAt = new(2025, 05, 06, 21, 44, 00);
            ModifiedAt = new(2025, 05, 06, 18, 00, 00);

            {
                WABackground = ColorTranslator.FromHtml("#151515");
                WAForeground = Color.White;

                WABorderground = WAForeground;

                WACaptionBackground = WAForeground;
                WACaptionForeground = WABackground;

                WInABackground = WABackground;
                WInAForeground = WAForeground;

                WInABorderground = WInABackground;

                WInACaptionBackground = WInABackground;
                WInACaptionForeground = WInAForeground;

                WDBackground = WABackground;
                WDForeground = Color.Red;
                WDBorderground = Color.Red;
                WDCaptionBackground = Color.Red;
                WDCaptionForeground = WACaptionForeground;
            } //Window

            {
                SBackground = ColorTranslator.FromHtml("#292929");
                InASBackground = ColorTranslator.FromHtml("#202020");
                DSBackground = WDBackground;

                ABackground = ColorTranslator.FromHtml("#202020");
                InABackground = ColorTranslator.FromHtml("#151515");
                DBackground = ABackground;

                SForeground = WAForeground;
                InASForeground = Color.Gainsboro;
                DSForeground = Color.Red;

                AForeground = WAForeground;
                InAForeground = Color.Gainsboro;
                DForeground = Color.Red;

                LForeground = Color.Khaki;
                InALForeground = Color.DarkKhaki;
                DLForeground = Color.Red;
            } //Controls
        }
    }
}