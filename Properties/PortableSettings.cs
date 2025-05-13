using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;

namespace LetGetAPass.Properties
{
    [SupportedOSPlatform("windows")]
    public partial class PortableSettings
    {
        protected readonly Dictionary<string, object?> defaults = new()
        {
            { "selectedtheme", "Default DARK" },
            { "selectedfont", new Font("Segoe UI", 11, FontStyle.Regular) },
            { "dologs", true }
        };
        protected Dictionary<string, object?> settings = [];

        protected readonly Regex iniParamRegex = IniParamRegex(),
            fontSerializedStrRegex = FontSerializedStrRegex();

        public PortableSettings()
        {

        }
        public static readonly PortableSettings Shared = new();

        public object? this[string setting]
        {
            get
            {
                setting = setting.ToLower();
                return settings.TryGetValue(setting, out var value)
                ? value
                : defaults.TryGetValue(setting, out value)
                    ? value
                    : throw new KeyNotFoundException("No such setting in current config or defaults");
            }
            set
            {
                setting = setting.ToLower();
                // Use TryGetValue optimization (1 check vs 2)
                if (defaults.TryGetValue(setting, out var defaultValue) && defaultValue == value)
                    settings.Remove(setting); //Its default value, it will returned from defaults dictionary
                else if (!settings.TryAdd(setting, value))
                    settings[setting] = value; //Its not default value, it will returned from settings dictionary
            }
        }
        public object? GetDefault(string setting)
            => defaults.TryGetValue(setting.ToLower(), out var value)
            ? value
            : throw new KeyNotFoundException("No such setting in current config or defaults");

        /// <summary>Trying to get (1) current or (2) default value for <paramref name="setting"/>, cast to <typeparamref name="T"/></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setting"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException">Can't cast current or default value to <typeparamref name="T"/></exception>
        /// <exception cref="KeyNotFoundException">No such setting in current config or defaults</exception>
        public T? GetValueAsT<T>(string setting)
        {
            if (settings.TryGetValue(setting, out object? value))
                try
                {
                    return (T?)value;
                }
                catch (InvalidCastException ice)
                {
                    if (defaults.TryGetValue(setting, out value))
                        return (T?)value;
                    else
                        throw new InvalidCastException($"No such setting in defaults. Can't cast current value to '{typeof(T).Name}'", ice);
                }
            else if (defaults.TryGetValue(setting, out value))
                try
                {
                    return (T?)value;
                }
                catch (InvalidCastException ice)
                {
                    throw new InvalidCastException($"No such setting in current config. Can't cast default value to '{typeof(T).Name}'", ice);
                }
            else
                throw new KeyNotFoundException("No such setting in current config or defaults");
        }

        public bool Remove(string setting, out object? value) => settings.Remove(setting, out value);
        public void Clear() => settings.Clear();

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
            Dictionary<string, object?> read = [];
            int count = reader.ReadInt32();
            try
            {
                while (count > 0)
                {
                    string name = reader.ReadString().ToLower();
                    object? value = (SettingType)reader.ReadByte() switch
                    {
                        SettingType.String => reader.ReadString(),
                        SettingType.UInt128 => new UInt128(reader.ReadUInt64(), reader.ReadUInt64()),
                        SettingType.Int128 => new Int128(reader.ReadUInt64(), reader.ReadUInt64()),
                        SettingType.Decimal => reader.ReadDecimal(),
                        SettingType.UInt64 => reader.ReadUInt64(),
                        SettingType.Int64 => reader.ReadInt64(),
                        SettingType.Double => reader.ReadDouble(),
                        SettingType.UInt32 => reader.ReadUInt32(),
                        SettingType.Int32 => reader.ReadInt32(),
                        SettingType.Float => reader.ReadSingle(),
                        SettingType.UInt16 => reader.ReadUInt16(),
                        SettingType.Int16 => reader.ReadInt16(),
                        SettingType.Half => reader.ReadHalf(),
                        SettingType.UInt8 => reader.ReadByte(),
                        SettingType.Int8 => reader.ReadSByte(),
                        SettingType.Bool => reader.ReadBoolean(),
                        SettingType.Font => new Font(reader.ReadString(), reader.ReadSingle(), (FontStyle)reader.ReadByte()),
                        _ => null
                    };
                    if (!read.TryAdd(name, value))
                        read[name] = value;
                    count--;
                }

            }
            catch
            {
                try
                {
                    foreach (var setting in read)
                        if (setting.Value is IDisposable dispose)
                            dispose.Dispose();
                }
                catch { }
                read.Clear();
                return false;
            }

            try
            {
                foreach (var setting in settings)
                    if (setting.Value is IDisposable dispose)
                        dispose.Dispose();
            }
            catch { }
            settings.Clear();
            settings = read;

            return true;
        }
        public bool TrySync(BinaryWriter writer)
        {
            try
            {
                writer.Write(settings.Count);
                foreach (var setting in settings)
                {
                    writer.Write(setting.Key.ToLower());

                    if (setting.Value is null)
                    {
                        writer.Write((byte)SettingType.NULL);
                    }
                    else if (setting.Value is bool boolean)
                    {
                        writer.Write((byte)SettingType.Bool);
                        writer.Write(boolean);
                    }
                    else if (setting.Value is byte ui8)
                    {
                        writer.Write((byte)SettingType.UInt8);
                        writer.Write(ui8);
                    }
                    else if (setting.Value is sbyte i8)
                    {
                        writer.Write((byte)SettingType.Int8);
                        writer.Write(i8);
                    }
                    else if (setting.Value is ushort ui16)
                    {
                        writer.Write((byte)SettingType.UInt16);
                        writer.Write(ui16);
                    }
                    else if (setting.Value is short i16)
                    {
                        writer.Write((byte)SettingType.Int16);
                        writer.Write(i16);
                    }
                    else if (setting.Value is Half f16)
                    {
                        writer.Write((byte)SettingType.Half);
                        writer.Write(f16);
                    }
                    else if (setting.Value is uint ui32)
                    {
                        writer.Write((byte)SettingType.UInt32);
                        writer.Write(ui32);
                    }
                    else if (setting.Value is int i32)
                    {
                        writer.Write((byte)SettingType.Int32);
                        writer.Write(i32);
                    }
                    else if (setting.Value is float f32)
                    {
                        writer.Write((byte)SettingType.Float);
                        writer.Write(f32);
                    }
                    else if (setting.Value is ulong ui64)
                    {
                        writer.Write((byte)SettingType.UInt64);
                        writer.Write(ui64);
                    }
                    else if (setting.Value is long i64)
                    {
                        writer.Write((byte)SettingType.Int64);
                        writer.Write(i64);
                    }
                    else if (setting.Value is double f64)
                    {
                        writer.Write((byte)SettingType.Double);
                        writer.Write(f64);
                    }
                    else if (setting.Value is UInt128 ui128)
                    {
                        writer.Write((byte)SettingType.UInt128);
                        unsafe
                        {
                            ulong* ptr = (ulong*)&ui128;
                            writer.Write(ptr[1]);
                            writer.Write(ptr[0]);
                        }
                    }
                    else if (setting.Value is Int128 i128)
                    {
                        writer.Write((byte)SettingType.Int128);
                        unsafe
                        {
                            ulong* ptr = (ulong*)&i128;
                            writer.Write(ptr[1]);
                            writer.Write(ptr[0]);
                        }
                    }
                    else if (setting.Value is decimal f128)
                    {
                        writer.Write((byte)SettingType.Decimal);
                        writer.Write(f128);
                    }
                    else if (setting.Value is string str)
                    {
                        writer.Write((byte)SettingType.String);
                        writer.Write(str);
                    }
                    else if (setting.Value is Font font)
                    {
                        writer.Write((byte)SettingType.Font);
                        writer.Write(font.FontFamily.Name);
                        writer.Write(font.Size);
                        writer.Write((byte)font.Style);
                    }
                    else
                    {
                        string? value = setting.Value.ToString();
                        if (value is null)
                        {
                            writer.Write((byte)SettingType.NULL);
                        }
                        else
                        {
                            writer.Write((byte)SettingType.String);
                            writer.Write(value);
                        }
                    }
                    writer.Flush();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TrySync(StreamReader reader)
        {
            Dictionary<string, object?> read = [];
            try
            {
                string? line;
                Match match;
                while ((line = reader.ReadLine()) is not null
                    && (match = iniParamRegex.Match(line)).Success)
                {
                    object? value = null;

                    if (match.Groups["value"].Success)
                    {
                        string strValue = match.Groups["value"].Value.Trim('\"');
                        if (string.IsNullOrWhiteSpace(strValue))
                            value = null;
                        //From min to max!
                        else if (bool.TryParse(strValue, out bool boolean))
                            value = boolean;
                        else if (sbyte.TryParse(strValue, out sbyte int8))
                            value = int8;
                        else if (byte.TryParse(strValue, out byte uint8))
                            value = uint8;
                        else if (short.TryParse(strValue, out short int16))
                            value = int16;
                        else if (ushort.TryParse(strValue, out ushort uint16))
                            value = uint16;
                        else if (int.TryParse(strValue, out int int32))
                            value = int32;
                        else if (uint.TryParse(strValue, out uint uint32))
                            value = uint32;
                        else if (long.TryParse(strValue, out long int64))
                            value = int64;
                        else if (ulong.TryParse(strValue, out ulong uint64))
                            value = uint64;
                        else if (Int128.TryParse(strValue, out Int128 int128))
                            value = int128;
                        else if (UInt128.TryParse(strValue, out UInt128 uint128))
                            value = uint128;
                        else
                        {
                            Match subMatch;
                            /*FUCK THAT SHIT*/ //if (decimal.TryParse(strValue, out decimal decimalValue))
                            //{
                            //    // Try Half
                            //    try
                            //    {
                            //        Half halfValue = (Half)decimalValue;
                            //        if ((decimal)halfValue == decimalValue) // Accuracy check
                            //        {
                            //            value = halfValue; // Exit early, found smallest type
                            //            goto Exit;
                            //        }
                            //    }
                            //    catch { }

                            //    // Try Float
                            //    try
                            //    {
                            //        float floatValue = (float)decimalValue;
                            //        if ((decimal)floatValue == decimalValue) // Accuracy check
                            //        {
                            //            value = floatValue; // Exit early, found smallest type
                            //            goto Exit;
                            //        }
                            //    }
                            //    catch { }
                            //    // Try Double
                            //    try
                            //    {
                            //        double doubleValue = (double)decimalValue;
                            //        if ((decimal)doubleValue == decimalValue) // Accuracy check
                            //        {
                            //            value = doubleValue; // Exit early, found smallest type
                            //            goto Exit;
                            //        }
                            //    }
                            //    catch { }
                            //    // If none of the floating-point types work without loss of precision, keep the decimal
                            //    value = decimalValue;
                            //Exit:;
                            //}
                            /*else*/ if ((subMatch = fontSerializedStrRegex.Match(strValue)).Success)
                            {
                                Group sz = subMatch.Groups["size"], style = subMatch.Groups["style"];

                                value = new Font(subMatch.Groups["name"].Value,
                                    float.TryParse(sz.Value, out float szValue)
                                    ? szValue
                                    : 11,
                                    style.Success
                                    ? byte.TryParse(style.Value, out byte styleValue)
                                        ? (FontStyle)styleValue
                                        : FontStyle.Regular
                                    : FontStyle.Regular);
                            }
                            else
                                value = strValue;
                        }
                    }

                    read.Add(match.Groups["param"].Value.Trim().Trim('\"').ToLower(), value);
                }
            }
            catch
            {
                foreach (var setting in read)
                    if (setting.Value is IDisposable dispose)
                        dispose.Dispose();
                read.Clear();
                return false;
            }

            try
            {
                foreach (var setting in settings)
                    if (setting.Value is IDisposable dispose)
                        dispose.Dispose();
            }
            catch { }
            settings.Clear();
            settings = read;

            return true;
        }
        public bool TrySync(StreamWriter writer)
        {
            try
            {
                foreach (var setting in settings)
                {
                    writer.Write($"\"{setting.Key}\"=");
                    if (setting.Value is not null)
                        if (setting.Value is Font font)
                            writer.WriteLine($"\"{font.FontFamily.Name} {font.Size} {(byte)font.Style}\"");
                        else
                            writer.WriteLine($"\"{setting.Value}\"");
                    else
                        writer.WriteLine();
                    writer.Flush();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*Short version of previous (all long) versions generated by GPTs*/
        [GeneratedRegex("^\\s*(?<param>\"?[a-zA-Z0-9_!+,. -]+\"?)\\s*=\\s*(?<value>\"[a-zA-Z0-9_!+,. -]*\"|[a-zA-Z0-9_!+,. -]*)\\s*$")] //Group[1] - PARAM, Group[2] - VALUE
        //ALL - [GeneratedRegex("\\s*(?:([a-zA-Z\\\\-_!+,. ]+)|(?:\\\"([a-zA-Z\\\\-_!+,. ]*)\\\"))\\s*=\\s*(?:([a-zA-Z\\\\-_!+,. ]*)|(?:\\\"([a-zA-Z\\\\-_!+,. ]*)\\\"))?\\s*$")]
        //3/5 - [GeneratedRegex("^\\s*\\\"((?:[^\\\"]|(?<=\\\\)\\\")*)\\\"\\s*=\\s*(?:\\\"((?:[^\\\"]|(?<=\\\\)\\\")*)\\\"|([^\\r\\n]*))\\s*$")]
        //?/? - [GeneratedRegex("(.+?)=(.+)?")]
        public static partial Regex IniParamRegex();

        [GeneratedRegex(@"^(?<name>.+?)\s+(?<size>\d+([.,]\d+)?)(?:\s+(?<style>\d{1,2}))?$", RegexOptions.IgnoreCase)]
        //[GeneratedRegex(@"^(?<name>.+?)(?:\s+(?<size>\d+([.,]\d+)?)(?:\s+(?<style>\d{1,2}))?)?$", RegexOptions.IgnoreCase)] //Segoe UI || Segoe UI 11.0 || Segoe UI 11.0 0
        //[GeneratedRegex(@"^(?<name>.+?)\s+(?<size>\d+(?:\.\d+)?)(?:\s+(?<style>\d{1,2}))?$", RegexOptions.IgnoreCase)] //Segoe UI 11.0 || Segoe UI 11.0 0
        //[GeneratedRegex(@"^(?<name>.+?)\s+(?<size>\d+(?:\.\d+)?)\s+(?<style>\d{1,2})$", RegexOptions.IgnoreCase)] //Segoe UI 11.0 0
        //[GeneratedRegex(@"^Font\s+(?<name>.+?)\s+(?<size>\d+(?:\.\d+)?)\s+(?<style>\d{1,2})$", RegexOptions.IgnoreCase)] //Font Segoe UI 11.0 0
        public static partial Regex FontSerializedStrRegex();

        public enum SettingType : byte
        {
            NULL,

            String,

            UInt128,
            Int128,

            Decimal,

            UInt64,
            Int64,

            Double,

            UInt32,
            Int32,

            Float,

            UInt16,
            Int16,

            Half,

            UInt8,
            Int8,

            Bool,

            Font
        }
    }
}