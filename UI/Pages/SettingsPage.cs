using LetGetAPass.UI.Themes;
using System.Runtime.Versioning;

namespace LetGetAPass.UI.Pages
{
    [SupportedOSPlatform("windows")]
    public partial class SettingsPage : UserControl
    {
        private List<ThemeUI> themes = [];
        private Font defaultFont = new("Seqgoe UI", 11, FontStyle.Regular);

        public SettingsPage()
        {
            InitializeComponent();
            selectedFontBox.Text = GetShortFontName(Font);
        }

        public event Action<ThemeUI>? ThemeSettingChanged;
        public event Action<Font>? FontSettingChanged;

        private static string GetShortFontName(Font font) => $"{font.Name} ({font.Size}) [{font.Style}]";

        private void selectedFontBox_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                FontSettingChanged?.Invoke(fontDialog.Font);
                selectedFontBox.Text = GetShortFontName(Font);
                fontDialog.Font = Font;
            }
        }

        private void returnFontBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to restore font to default?", "LetGetAPass", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FontSettingChanged?.Invoke(defaultFont);
                selectedFontBox.Text = GetShortFontName(Font);
                fontDialog.Font = Font;
            }
        }
    }
}