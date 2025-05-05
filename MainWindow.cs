using LetGetAPass.PInvoke;

namespace LetGetAPass
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DwmApi.CustomWindow(BackColor, Color.Red, Color.Red, Handle);

        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            DwmApi.CustomWindow(ForeColor, BackColor, ForeColor, Handle);
        }

        private void MainWindow_Deactivate(object sender, EventArgs e)
        {
            DwmApi.CustomWindow(BackColor, ForeColor, BackColor, Handle);
        }
    }
}