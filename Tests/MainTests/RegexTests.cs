using System.Text;
using System.Text.RegularExpressions;
using LetGetAPass.Properties;

namespace MainTests
{
    [TestClass]
    public sealed class RegexTests
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Regex regex = PortableSettings.IniParamRegex();
            string l1 = "\"CorrectParam\"=\"Correct Value With Theme\"",
                l2 = "\"CorrectParam\"=",
                l3 = "\"CorrectParam\"=Incorrect Value",
                l4 = "Incorrect Param = Incorrect Value",
                l5 = "Incorrect Param = \"Correct Value\"";
            using StreamWriter writer = new(Path.Combine(context.ResultsDirectory ?? Path.GetTempPath(), "regexTests.log"), true, Encoding.UTF8);
            writer.WriteLine();
            writer.WriteLine("PortableSettings.IniParamRegex()");
            writer.WriteLine();
            writer.Flush();
            Mbox(l1);
            Mbox(l2);
            Mbox(l3);
            Mbox(l4);
            Mbox(l5);

            void Mbox(string l)
            {
                writer.WriteLine(l);
                Match m = regex.Match(l);
                if (m.Success)
                {
                    writer.WriteLine("True");
                    writer.WriteLine(m.Value);
                    writer.WriteLine();
                    writer.WriteLine();
                    writer.WriteLine($"{m.Groups.Count} groups:");
                    foreach (Group group in m.Groups)
                    {
                        writer.WriteLine($"[{group.Index}] {group.Name}: {group.Value}");
                        writer.WriteLine();
                    }
                }
                else
                    writer.WriteLine("False");
                writer.WriteLine();
                writer.WriteLine();
                writer.Flush();
            }
        }
    }
}
