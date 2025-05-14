using System.Runtime.Versioning;

namespace LetGetAPass.UI.Themes
{
    /// <summary>Interface, which applied to UI-themes. Prefixes: A - Active, InA - Inactive, D - Death, L - Link, S - Strict, W - Window</summary>
    [SupportedOSPlatform("windows")]
    public interface ThemeUI
    {
        public string Name { get; }
        public string Author { get; }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }

        #region Background

        public Color SBackground { get; }
        public Color InASBackground { get; }
        public Color DSBackground { get; }

        public Color ABackground { get; }

        public Color InABackground { get; }

        public Color DBackground { get; }

        #endregion

        #region Foreground

        public Color SForeground { get; }
        public Color InASForeground { get; }
        public Color DSForeground { get; }

        public Color AForeground { get; }
        public Color InAForeground { get; }
        public Color DForeground { get; }

        public Color LForeground { get; }
        public Color InALForeground { get; }
        public Color DLForeground { get; }

        #endregion

        #region Window appearance

        public Color WABackground { get; }
        public Color WInABackground { get; }
        public Color WDBackground { get; }

        public Color WAForeground { get; }
        public Color WInAForeground { get; }
        public Color WDForeground { get; }

        public Color WABorderground { get; }
        public Color WInABorderground { get; }
        public Color WDBorderground { get; }

        public Color WACaptionBackground { get; }
        public Color WInACaptionBackground { get; }
        public Color WDCaptionBackground { get; }

        public Color WACaptionForeground { get; }
        public Color WInACaptionForeground { get; }
        public Color WDCaptionForeground { get; }

        #endregion

        #region Icons

        public IReadOnlyDictionary<string, Image> Icons { get; }

        #endregion
    }
}