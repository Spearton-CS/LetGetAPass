using System.Runtime.Versioning;

namespace LetGetAPass.UI.Themes
{
    [SupportedOSPlatform("windows")]
    public class DefaultLightThemeUI : CompileTimeThemeUI
    {
        public DefaultLightThemeUI()
        {
            Name = "Default LIGHT";
            Author = "Spearton";
            CreatedAt = new(2025, 05, 06, 22, 00, 00);
            ModifiedAt = new(2025, 05, 07, 18, 05, 00);

            {
                WABackground = Color.FromKnownColor(KnownColor.Window);
                WAForeground = Color.FromKnownColor(KnownColor.WindowText);

                WABorderground = WAForeground;

                WACaptionBackground = WAForeground;
                WACaptionForeground = WABackground;

                WInABackground = WAForeground;
                WInAForeground = WABackground;

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
                SBackground = Color.FromKnownColor(KnownColor.ControlLightLight);
                InASBackground = Color.FromKnownColor(KnownColor.ControlDark);
                DSBackground = SBackground;

                ABackground = Color.FromKnownColor(KnownColor.ControlLight);
                InABackground = Color.FromKnownColor(KnownColor.ControlDarkDark);
                DBackground = ABackground;

                SForeground = Color.FromKnownColor(KnownColor.ControlText);
                InASForeground = SForeground;
                DSForeground = Color.Red;

                AForeground = Color.FromKnownColor(KnownColor.ControlText);
                InAForeground = Color.FromKnownColor(KnownColor.ControlText);
                DForeground = Color.Red;

                LForeground = Color.Blue;
                InALForeground = Color.DarkBlue;
                DLForeground = Color.Red;
            } //Controls

            {
                Dictionary<string, Image> icons = new()
                {
                    { "restore", (Image)Properties.Resources.ResourceManager.GetObject("restoreBlack")! }
                };
                Icons = icons;
            } //Icons
        }
    }
}