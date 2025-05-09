using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using LetGetAPass.Properties;

namespace MainTests
{
    [TestClass]
    public sealed class RegexTests
    {
        private Regex iniParamRegex,
            fontSerializedStrRegex;
        private readonly float[] supportedFontSzs = [8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72];


        public RegexTests()
        {
            iniParamRegex = PortableSettings.IniParamRegex();
            fontSerializedStrRegex = PortableSettings.FontSerializedStrRegex();
            Debug.WriteLine("Initialized");
            Debug.WriteLine("----------------------------------");
        }

        #region IniRegex
        [TestMethod]
        public void IniRegexCorrectBoth()
        {
            Assert.IsTrue(RegexIsMatch(iniParamRegex, "\"CorrectParam\"=\"Correct Value With Theme\""));
        }

        [TestMethod]
        public void IniRegexCorrectEmpty()
        {
            Assert.IsTrue(RegexIsMatch(iniParamRegex, "\"CorrectParam\"="));
        }

        [TestMethod]
        public void IniRegexCorrectIncorrect()
        {
            Assert.IsTrue(RegexIsMatch(iniParamRegex, "\"CorrectParam\"=Incorrect Value"));
        }

        [TestMethod]
        public void IniRegexIncorrectBoth()
        {
            Assert.IsTrue(RegexIsMatch(iniParamRegex, "Incorrect Param = Incorrect Value"));
        }

        [TestMethod]
        public void IniRegexIncorrectEmpty()
        {
            Assert.IsTrue(RegexIsMatch(iniParamRegex, "Incorrect Param ="));
        }

        [TestMethod]
        public void IniRegexIncorrectCorrect()
        {
            Assert.IsTrue(RegexIsMatch(iniParamRegex, "Incorrect Param=\"Correct Value\""));
        }
        #endregion

        #region Font serialized as string

        [TestMethod]
        public void FontAsStrDefaultFull()
        {
            Assert.IsTrue(RegexIsMatch(fontSerializedStrRegex, "Segoe UI 11.0 0"));
            Debug.WriteLine("----------------------------------");
            Assert.IsTrue(RegexIsMatch(fontSerializedStrRegex, "Segoe UI 11 0"));
        }

        [TestMethod]
        public void FontAsStrDefaultNormal()
        {
            Assert.IsTrue(RegexIsMatch(fontSerializedStrRegex, "Segoe UI 11"));
            Debug.WriteLine("----------------------------------");
            Assert.IsTrue(RegexIsMatch(fontSerializedStrRegex, "Segoe UI 11.5"));
        }

        [TestMethod]
        public void FontAsStrFull()
        {
            foreach (FontFamily family in FontFamily.Families)
            {
                Debug.WriteLine(family.Name);
                Debug.WriteLine("----------------------------------");
                foreach (float sz in supportedFontSzs)
                {
                    Assert.IsTrue(FontRegexIsMatch($"{family.Name} {sz}", true, false),
                        $"+{sz}");
                    Debug.WriteLine("----------------------------------");
                    Assert.IsTrue(FontRegexIsMatch($"{family.Name} {sz + 0.5f}", true, false),
                        $"+{sz + 0.5f}");
                    Debug.WriteLine("----------------------------------");
                    for (sbyte style = 0; style < 16; style++)
                    {
                        Assert.IsTrue(FontRegexIsMatch($"{family.Name} {sz} {style}", true, true),
                            $"+{sz} +{(FontStyle)style}");
                        Debug.WriteLine("----------------------------------");
                        Assert.IsTrue(FontRegexIsMatch($"{family.Name} {sz + 0.5f} {style}", true, true),
                            $"+{sz + 0.5f} +{(FontStyle)style}");
                    }
                }
                Debug.WriteLine("----------------------------------");
            }
        }

        #endregion

        private bool FontRegexIsMatch(string value, bool size, bool style)
        {
            Debug.WriteLine(value);
            Match m = fontSerializedStrRegex.Match(value);
            if (m.Success)
            {
                Debug.WriteLine("True");
                Debug.WriteLine(null);
                Debug.WriteLine($"{m.Groups.Count} groups:");
                Debug.WriteLine(null);
                bool fsz = false, fstyle = false;
                foreach (Group group in m.Groups)
                {
                    if (group.Success && group.Name == "size")
                        fsz = true;
                    if (group.Success && group.Name == "style")
                        fstyle = true;
                    Debug.WriteLine($"[{group.Index}] {group.Name}: {group.Value}");
                    Debug.WriteLine(null);
                }
                Debug.WriteLine($"Found size: {fsz}; Found style: {fstyle}");
                if (size && !fsz)
                {
                    Debug.WriteLine("Need size");
                    return false;
                }
                if (style && !fstyle)
                {
                    Debug.WriteLine("Need style");
                    return false;
                }
                return true;
            }
            else
            {
                Debug.WriteLine("False");
                return false;
            }
        }
        private bool RegexIsMatch(Regex regex, string value)
        {
            Debug.WriteLine(value);
            Match m = regex.Match(value);
            if (m.Success)
            {
                Debug.WriteLine("True");
                Debug.WriteLine(null);
                Debug.WriteLine($"{m.Groups.Count} groups:");
                Debug.WriteLine(null);
                foreach (Group group in m.Groups)
                {
                    Debug.WriteLine($"[{group.Index}] {group.Name}: {group.Value}");
                    Debug.WriteLine(null);
                }
                return true;
            }
            else
            {
                Debug.WriteLine("False");
                return false;
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            Debug.WriteLine("----------------------------------");
        }
    }
}
