using System.Globalization;
using System.Runtime.InteropServices;

namespace LetGetAPass.PInvoke
{
    public static partial class DwmApi
    {
        public static string ToBgr(Color c) => $"{c.B:X2}{c.G:X2}{c.R:X2}";
        [LibraryImport("DwmApi")]
        public static partial int DwmSetWindowAttribute(nint hWnd, int attribute, int[] attributeValue, int attributeSize);
        public const int DWWMA_BORDER_COLOR = 34, DWWMA_CAPTION_COLOR = 35, DWMWA_TEXT_COLOR = 36;
        public static void CustomWindow(Color captionColor, Color fontColor, Color borderColor, nint handle)
        {
            _ = DwmSetWindowAttribute(handle, DWWMA_CAPTION_COLOR, [int.Parse(ToBgr(captionColor), NumberStyles.HexNumber)], 4);
            _ = DwmSetWindowAttribute(handle, DWMWA_TEXT_COLOR, [int.Parse(ToBgr(fontColor), NumberStyles.HexNumber)], 4);
            _ = DwmSetWindowAttribute(handle, DWWMA_BORDER_COLOR, [int.Parse(ToBgr(borderColor), NumberStyles.HexNumber)], 4);
        }
    }
}