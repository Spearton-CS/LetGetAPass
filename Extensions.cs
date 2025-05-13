using System.Runtime.Versioning;

namespace LetGetAPass
{
    public static class Extensions
    {
        [SupportedOSPlatform("windows")]
        public static bool CompareFont(this Font a, Font b) =>
            a.Name == b.Name
            && a.Style == b.Style
            && a.Size == b.Size;
        public static string ToInformationalString(this Font font) => $"{font.Name} ({font.Size}) [{font.Style}]";
    }
}