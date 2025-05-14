using LetGetAPass.Structures;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Text;

namespace LetGetAPass.UI.Themes
{
    [SupportedOSPlatform("windows")]
    public class UserDefinedThemeUI : ThemeUI
    {
        public UserDefinedThemeUI()
        {
            Dictionary<string, Image> icons = [];
            Icons = new(icons);
        }

        public static readonly char[] SerializationFormatSign = ['L', 'G', 'M', 'A', 'P', '_', 'U', 'D', '_', 'T', 'H', 'E', 'M', 'E'];

        public static bool TryDeserialize(Stream input, out UserDefinedThemeUI? theme)
        {
            try
            {
                theme = new();

                using BinaryReader reader = new(input, Encoding.UTF8, true);

                char[] sign = new char[SerializationFormatSign.Length];
                if (reader.Read(sign) != sign.Length)
                    throw new InvalidDataException("Invalid sign");
                for (int i = 0; i < sign.Length; i++)
                    if (sign[i] != SerializationFormatSign[i])
                        throw new InvalidDataException("Invalid sign");

                {
                    theme.Name = reader.ReadString();
                    theme.Author = reader.ReadString();
                    theme.CreatedAt = DateTime.FromBinary(reader.ReadInt64());
                    theme.ModifiedAt = DateTime.FromBinary(reader.ReadInt64());
                } //HEADER

                {
                    theme.WABackground = Color.FromArgb(reader.ReadInt32());
                    theme.WAForeground = Color.FromArgb(reader.ReadInt32());
                    theme.WABorderground = Color.FromArgb(reader.ReadInt32());
                    theme.WACaptionBackground = Color.FromArgb(reader.ReadInt32());
                    theme.WACaptionForeground = Color.FromArgb(reader.ReadInt32());

                    theme.WInABackground = Color.FromArgb(reader.ReadInt32());
                    theme.WInAForeground = Color.FromArgb(reader.ReadInt32());
                    theme.WInABorderground = Color.FromArgb(reader.ReadInt32());
                    theme.WInACaptionBackground = Color.FromArgb(reader.ReadInt32());
                    theme.WInACaptionForeground = Color.FromArgb(reader.ReadInt32());
                } //WINDOW APPEARANCE

                {
                    theme.SBackground = Color.FromArgb(reader.ReadInt32());
                    theme.SForeground = Color.FromArgb(reader.ReadInt32());

                    theme.InASBackground = Color.FromArgb(reader.ReadInt32());
                    theme.InASForeground = Color.FromArgb(reader.ReadInt32());

                    theme.DSBackground = Color.FromArgb(reader.ReadInt32());
                    theme.DSForeground = Color.FromArgb(reader.ReadInt32());
                } //STRICT APPEARANCE

                {
                    theme.LForeground = Color.FromArgb(reader.ReadInt32());
                    theme.InALForeground = Color.FromArgb(reader.ReadInt32());
                    theme.DLForeground = Color.FromArgb(reader.ReadInt32());
                } //LINK APPEARANCE

                {
                    theme.ABackground = Color.FromArgb(reader.ReadInt32());
                    theme.AForeground = Color.FromArgb(reader.ReadInt32());

                    theme.InABackground = Color.FromArgb(reader.ReadInt32());
                    theme.InAForeground = Color.FromArgb(reader.ReadInt32());

                    theme.DBackground = Color.FromArgb(reader.ReadInt32());
                    theme.DForeground = Color.FromArgb(reader.ReadInt32());
                } //DEFAULT APPEARANCE

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                theme = null;
                return false;
            }
        }
        public void Serialize(Stream output)
        {
            using BinaryWriter writer = new(output, Encoding.UTF8, true);

            writer.Write(SerializationFormatSign);

            {
                writer.Write(Name);
                writer.Write(Author);
                writer.Write(CreatedAt.ToBinary());
                writer.Write(ModifiedAt.ToBinary());
            } //HEADER

            {
                writer.Write(WABackground.ToArgb());
                writer.Write(WAForeground.ToArgb());
                writer.Write(WABorderground.ToArgb());
                writer.Write(WACaptionBackground.ToArgb());
                writer.Write(WACaptionForeground.ToArgb());

                writer.Write(WInABackground.ToArgb());
                writer.Write(WInAForeground.ToArgb());
                writer.Write(WInABorderground.ToArgb());
                writer.Write(WInACaptionBackground.ToArgb());
                writer.Write(WInACaptionForeground.ToArgb());

                writer.Write(WDBackground.ToArgb());
                writer.Write(WDForeground.ToArgb());
                writer.Write(WDBorderground.ToArgb());
                writer.Write(WDCaptionBackground.ToArgb());
                writer.Write(WDCaptionForeground.ToArgb());
            } //WINDOW APPEARANCE

            {
                writer.Write(SBackground.ToArgb());
                writer.Write(SForeground.ToArgb());

                writer.Write(InASBackground.ToArgb());
                writer.Write(InASForeground.ToArgb());

                writer.Write(DSBackground.ToArgb());
                writer.Write(DSForeground.ToArgb());
            } //STRICT APPEARANCE

            {
                writer.Write(LForeground.ToArgb());
                writer.Write(InALForeground.ToArgb());
                writer.Write(DLForeground.ToArgb());
            } //LINK APPEARANCE

            {
                writer.Write(ABackground.ToArgb());
                writer.Write(AForeground.ToArgb());

                writer.Write(InABackground.ToArgb());
                writer.Write(InAForeground.ToArgb());

                writer.Write(DBackground.ToArgb());
                writer.Write(DForeground.ToArgb());
            } //DEFAULT APPEARANCE
        }

        #region Fields
        public string Name { get; set; } = "Unnamed";

        public string Author { get; set; } = "Noname";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        public Color SBackground { get; set; }

        public Color InASBackground { get; set; }

        public Color DSBackground { get; set; }

        public Color ABackground { get; set; }

        public Color InABackground { get; set; }

        public Color DBackground { get; set; }

        public Color SForeground { get; set; }

        public Color InASForeground { get; set; }

        public Color DSForeground { get; set; }

        public Color AForeground { get; set; }

        public Color InAForeground { get; set; }

        public Color DForeground { get; set; }

        public Color LForeground { get; set; }

        public Color InALForeground { get; set; }

        public Color DLForeground { get; set; }

        public Color WABackground { get; set; }

        public Color WInABackground { get; set; }

        public Color WDBackground { get; set; }

        public Color WAForeground { get; set; }

        public Color WInAForeground { get; set; }

        public Color WDForeground { get; set; }

        public Color WABorderground { get; set; }

        public Color WInABorderground { get; set; }

        public Color WDBorderground { get; set; }

        public Color WACaptionBackground { get; set; }

        public Color WInACaptionBackground { get; set; }

        public Color WDCaptionBackground { get; set; }

        public Color WACaptionForeground { get; set; }

        public Color WInACaptionForeground { get; set; }

        public Color WDCaptionForeground { get; set; }

        public ModifyOnlyDictionary<string, Image> Icons { get; init; }
        IReadOnlyDictionary<string, Image> ThemeUI.Icons => Icons;
        #endregion
    }
}