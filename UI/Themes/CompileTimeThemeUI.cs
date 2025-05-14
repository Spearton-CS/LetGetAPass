using System.Runtime.Versioning;

namespace LetGetAPass.UI.Themes
{
    /// <summary>UI Theme, that known at compilation time. Prefixes: A - Active, InA - Inactive, D - Death, L - Link, S - Strict, W - Window</summary>
    [SupportedOSPlatform("windows")]
    public abstract class CompileTimeThemeUI : ThemeUI
    {
        public string Name { get; init; }

        public string Author { get; init; }

        public DateTime CreatedAt { get; init; }

        public DateTime ModifiedAt { get; init; }

        public Color SBackground { get; init; }

        public Color ABackground { get; init; }

        public Color InABackground { get; init; }

        public Color SForeground { get; init; }

        public Color AForeground { get; init; }

        public Color InAForeground { get; init; }

        public Color LForeground { get; init; }

        public Color InALForeground { get; init; }

        public Color WABackground { get; init; }

        public Color WInABackground { get; init; }

        public Color WDBackground { get; init; }

        public Color WAForeground { get; init; }

        public Color WInAForeground { get; init; }

        public Color WDForeground { get; init; }

        public Color WABorderground { get; init; }

        public Color WInABorderground { get; init; }

        public Color WDBorderground { get; init; }

        public Color WACaptionBackground { get; init; }

        public Color WInACaptionBackground { get; init; }

        public Color WDCaptionBackground { get; init; }

        public Color WACaptionForeground { get; init; }

        public Color WInACaptionForeground { get; init; }

        public Color WDCaptionForeground { get; init; }

        public Color DBackground { get; init; }

        public Color DForeground { get; init; }

        public Color DLForeground { get; init; }

        public Color InASBackground { get; init; }

        public Color DSBackground { get; init; }

        public Color InASForeground { get; init; }

        public Color DSForeground { get; init; }

        public IReadOnlyDictionary<string, Image> Icons { get; init; }
    }
}