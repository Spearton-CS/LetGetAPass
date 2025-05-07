namespace LetGetAPass
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabs = new TabControl();
            mainTab = new TabPage();
            collectionTab = new TabPage();
            generationTab = new TabPage();
            checkTab = new TabPage();
            settingsTab = new TabPage();
            iconsList = new ImageList(components);
            settingsPage = new LetGetAPass.UI.Pages.SettingsPage();
            tabs.SuspendLayout();
            settingsTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabs
            // 
            tabs.Controls.Add(mainTab);
            tabs.Controls.Add(collectionTab);
            tabs.Controls.Add(generationTab);
            tabs.Controls.Add(checkTab);
            tabs.Controls.Add(settingsTab);
            tabs.Dock = DockStyle.Fill;
            tabs.ImageList = iconsList;
            tabs.Location = new Point(0, 0);
            tabs.Multiline = true;
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(584, 361);
            tabs.TabIndex = 0;
            // 
            // mainTab
            // 
            mainTab.AutoScroll = true;
            mainTab.Location = new Point(4, 39);
            mainTab.Name = "mainTab";
            mainTab.Size = new Size(576, 318);
            mainTab.TabIndex = 0;
            mainTab.Text = "Main";
            mainTab.UseVisualStyleBackColor = true;
            // 
            // collectionTab
            // 
            collectionTab.AutoScroll = true;
            collectionTab.Location = new Point(4, 39);
            collectionTab.Name = "collectionTab";
            collectionTab.Size = new Size(576, 318);
            collectionTab.TabIndex = 1;
            collectionTab.Text = "Collection";
            collectionTab.UseVisualStyleBackColor = true;
            // 
            // generationTab
            // 
            generationTab.AutoScroll = true;
            generationTab.Location = new Point(4, 39);
            generationTab.Name = "generationTab";
            generationTab.Size = new Size(576, 318);
            generationTab.TabIndex = 2;
            generationTab.Text = "Generation";
            generationTab.UseVisualStyleBackColor = true;
            // 
            // checkTab
            // 
            checkTab.AutoScroll = true;
            checkTab.Location = new Point(4, 39);
            checkTab.Name = "checkTab";
            checkTab.Size = new Size(576, 318);
            checkTab.TabIndex = 4;
            checkTab.Text = "Check";
            checkTab.UseVisualStyleBackColor = true;
            // 
            // settingsTab
            // 
            settingsTab.AutoScroll = true;
            settingsTab.Controls.Add(settingsPage);
            settingsTab.Location = new Point(4, 39);
            settingsTab.Name = "settingsTab";
            settingsTab.Size = new Size(576, 318);
            settingsTab.TabIndex = 3;
            settingsTab.Text = "Settings";
            settingsTab.UseVisualStyleBackColor = true;
            // 
            // iconsList
            // 
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(32, 32);
            iconsList.TransparentColor = Color.Transparent;
            // 
            // settingsPage
            // 
            settingsPage.AutoScroll = true;
            settingsPage.Dock = DockStyle.Fill;
            settingsPage.Location = new Point(0, 0);
            settingsPage.Name = "settingsPage";
            settingsPage.Size = new Size(576, 318);
            settingsPage.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(584, 361);
            Controls.Add(tabs);
            Font = new Font("Segoe UI", 11F);
            ForeColor = Color.White;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(400, 250);
            Name = "MainWindow";
            Text = "LetGetAPass";
            Activated += MainWindow_Activated;
            Deactivate += MainWindow_Deactivate;
            FormClosing += MainWindow_FormClosing;
            tabs.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabs;
        private ImageList iconsList;
        private TabPage mainTab;
        private TabPage collectionTab;
        private TabPage generationTab;
        private TabPage checkTab;
        private TabPage settingsTab;
        private UI.Pages.SettingsPage settingsPage;
    }
}
