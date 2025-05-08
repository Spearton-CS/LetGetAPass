using System.Text;
using System.Text.RegularExpressions;

namespace LetGetAPass.Properties
{
    public partial class PortableSettings
    {
        private readonly Dictionary<string, object> defaults = new()
        {
            { "SelectedTheme", "Default DARK" }
        };
        private Dictionary<string, object> settings = [];

        private readonly Regex iniParamRegex = IniParamRegex();

        private PortableSettings()
        {
            foreach (var setting in defaults)
                settings.Add(setting.Key, setting.Value);
        }
        public static readonly PortableSettings Instance = new();

        public bool TrySync(Stream stream, bool binary = true, bool output = false)
        {
            if (binary)
                if (output)
                    using (BinaryWriter writer = new(stream, Encoding.UTF8, true))
                        return TrySync(writer);
                else
                    using (BinaryReader reader = new(stream, Encoding.UTF8, true))
                        return TrySync(reader);
            else if (output)
                using (StreamWriter writer = new(stream, Encoding.UTF8, leaveOpen: true))
                    return TrySync(writer);
            else
                using (StreamReader reader = new(stream, Encoding.UTF8, leaveOpen: true))
                    return TrySync(reader);
        }
        public bool TrySync(BinaryReader reader)
        {
            return false;
        }
        public bool TrySync(BinaryWriter writer)
        {
            return false;
        }

        public bool TrySync(StreamReader reader)
        {
            return false;
        }
        public bool TrySync(StreamWriter writer)
        {
            return false;
        }

        [GeneratedRegex("^\\s*(\"?[a-zA-Z0-9_!+,. -]+\"?)\\s*=\\s*(\"[a-zA-Z0-9_!+,. -]*\"|[a-zA-Z0-9_!+,. -]*)\\s*$")] //Group[1] - PARAM, Group[2] - VALUE
        //ALL - [GeneratedRegex("\\s*(?:([a-zA-Z\\\\-_!+,. ]+)|(?:\\\"([a-zA-Z\\\\-_!+,. ]*)\\\"))\\s*=\\s*(?:([a-zA-Z\\\\-_!+,. ]*)|(?:\\\"([a-zA-Z\\\\-_!+,. ]*)\\\"))?\\s*$")]
        //3/5 - [GeneratedRegex("^\\s*\\\"((?:[^\\\"]|(?<=\\\\)\\\")*)\\\"\\s*=\\s*(?:\\\"((?:[^\\\"]|(?<=\\\\)\\\")*)\\\"|([^\\r\\n]*))\\s*$")]
        //?/? - [GeneratedRegex("(.+?)=(.+)?")]
        public static partial Regex IniParamRegex();
    }
}