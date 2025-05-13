using LetGetAPass.Properties;
using LetGetAPass.UI.Themes;
using System.Runtime.Versioning;

namespace LetGetAPass.UI.Pages
{
    [SupportedOSPlatform("windows")]
    public partial class SettingsPage : UserControl
    {
        private const string logPrefix = "SettingsPage:";
        private List<ThemeUI> themes = [];
        private Font defaultFont = new("Seqgoe UI", 11, FontStyle.Regular);

        public SettingsPage()
        {
            InitializeComponent();
        }

        public event Action<ThemeUI>? ThemeSettingChanged;
        public event Action<Font>? FontSettingChanged;

        private void selectedFontBox_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Font old = Font;
                if (old.CompareFont(fontDialog.Font))
                {
                    PortableLogger.Shared?.Log($"{logPrefix} '{old.ToInformationalString}' already selected");
                    return;
                }

                FontSettingChanged?.Invoke(fontDialog.Font);
                selectedFontBox.Text = Font.ToInformationalString();
                fontDialog.Font = Font;

                if (old.CompareFont(Font))
                    PortableLogger.Shared?.Log($"{logPrefix} Trying change '{old.ToInformationalString()}'" +
                        $" to '{fontDialog.Font}'," +
                        $" but {nameof(FontSettingChanged)} ignored changing");
                else
                    PortableLogger.Shared?.Log($"{logPrefix} '{old.ToInformationalString()}' changed to" +
                        $" '{Font.ToInformationalString()}'" +
                        $" when selected '{fontDialog.Font.ToInformationalString()}'");
            }
        }

        private void returnFontBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to restore font to default?", "LetGetAPass", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Font old = Font;
                if (old.CompareFont(defaultFont))
                {
                    PortableLogger.Shared?.Log($"{logPrefix} Trying to restore font to default," +
                        $" but '{defaultFont.ToInformationalString}' already selected");
                    return;
                }
                FontSettingChanged?.Invoke(defaultFont);
                selectedFontBox.Text = Font.ToInformationalString();
                fontDialog.Font = Font;

                if (old.CompareFont(Font))
                    PortableLogger.Shared?.Log($"{logPrefix} Trying to restore font to default");
            }
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            PortableLogger? logger = PortableLogger.Shared;
            try
            {
                using FileStream fs = File.Open("settings.ini", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
                using StreamReader reader = new(fs);
                fs.Position = 0;
                PortableSettings.Shared.TrySync(reader);

                logger?.Log($"{logPrefix} Settings initialized from 'settings.ini'");
            }
            catch (Exception ex)
            {
                logger?.Log($"{logPrefix} Exception when tried to initialize settings: {ex}");
            }

            try
            {
                FontSettingChanged?.Invoke(PortableSettings.Shared.GetValueAsT<Font>("selectedfont")!);
            }
            catch (Exception ex)
            {
                logger?.Log($"{logPrefix} Exception when tried to sync Font from settings" +
                    $" and invoke {nameof(FontSettingChanged)}: {ex}");
            }
            selectedFontBox.Text = Font.ToInformationalString();
            fontDialog.Font = Font;

            string theme = PortableSettings.Shared.GetValueAsT<string>("selectedtheme")!;

            logger?.Log($"{logPrefix} initialized");
        }
    }
}