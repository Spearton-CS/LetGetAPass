using System.Diagnostics;
using System.Text.RegularExpressions;
using LetGetAPass.Properties;

namespace MainTests
{
    [TestClass]
    public sealed class RegexTests
    {
        private Regex iniParamRegex;

        public RegexTests()
        {
            iniParamRegex = PortableSettings.IniParamRegex();
            Debug.WriteLine("Initialized");
        }

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
