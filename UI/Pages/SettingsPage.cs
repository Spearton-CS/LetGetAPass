using LetGetAPass.UI.Themes;
using System.Runtime.Versioning;

namespace LetGetAPass.UI.Pages
{
    [SupportedOSPlatform("windows")]
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        public event Action<ThemeUI>? ThemeChanged;
    }
}