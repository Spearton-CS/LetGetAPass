using LetGetAPass.Properties;
using System.Diagnostics;

namespace MainTests
{
    [TestClass]
    public class SettingsTests
    {
        private readonly Dictionary<string, object?> values = new()
        {
            { "STRING", "Hello world" },
            { "FONT", new System.Drawing.Font("Segoe UI", 11.5f, System.Drawing.FontStyle.Regular) },
            /*FUCK THAT SHIT*/ //{ "DECIMAL", 12345678901234567890.1234567M },
            //{ "DOUBLE", 1.2345678901234567D },
            //{ "FLOAT", 70000.5F },
            //{ "HALF", (Half)12.34 },
            { "UINT128", UInt128.MaxValue },
            { "INT128", Int128.MaxValue },
            { "UINT64", UInt64.MaxValue },
            { "INT64", Int64.MaxValue },
            { "UINT32", UInt32.MaxValue },
            { "INT32", Int32.MaxValue },
            { "UINT16", UInt16.MaxValue },
            { "INT16", Int16.MaxValue },
            { "UINT8", Byte.MaxValue },
            { "INT8", SByte.MaxValue },
            { "BOOLEAN", false },
            { "NULL", null }

        };
        private PortableSettings settings;
        public SettingsTests()
        {
            settings = new();
            Debug.WriteLine("Initialized");
            Debug.WriteLine("----------------------------------");
        }

        private void Fill()
        {
            foreach (var value in values)
                settings[value.Key] = value.Value;
        }
        private void Check()
        {
            foreach (var value in values)
                Assert.AreEqual(value.Value, settings[value.Key], value.Key);
        }

        [TestMethod]
        public void FillAndCheck()
        {
            Fill();
            Check();
        }

        [TestMethod]
        public void SyncBinary()
        {
            Fill();
            using MemoryStream ms = new(1024 * 1024 * 20);
            ms.Position = 0;
            Assert.IsTrue(settings.TrySync(ms, true, true), "OUT");
            string path = Path.GetTempFileName();
            using (FileStream fs = File.Create(path))
            {
                ms.Position = 0;
                ms.CopyTo(fs);
                Debug.WriteLine(path);
            }
            ms.Position = 0;
            settings.Clear();
            Assert.IsTrue(settings.TrySync(ms, true, false), "IN");
            Check();
        }

        [TestMethod]
        public void SyncIni()
        {
            Fill();
            using MemoryStream ms = new(1024 * 1024 * 20);
            ms.Position = 0;
            Assert.IsTrue(settings.TrySync(ms, false, true), "OUT");
            string path = Path.GetTempFileName();
            using (FileStream fs = File.Create(path))
            {
                ms.Position = 0;
                ms.CopyTo(fs);
                Debug.WriteLine(path);
            }
            ms.Position = 0;
            settings.Clear();
            Assert.IsTrue(settings.TrySync(ms, false, false), "IN");
            Check();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Debug.WriteLine("----------------------------------");
        }
    }
}