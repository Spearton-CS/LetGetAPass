namespace LetGetAPass.UI.Pages
{
    partial class SettingsPage
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            GroupBox mainGroup;
            TableLayoutPanel mainSettingsTable;
            Label selectedFontLabel;
            GroupBox groupBox2;
            GroupBox groupBox3;
            selectedFontBox = new TextBox();
            returnFontBox = new PictureBox();
            infoTip = new ToolTip(components);
            fontDialog = new FontDialog();
            mainGroup = new GroupBox();
            mainSettingsTable = new TableLayoutPanel();
            selectedFontLabel = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            mainGroup.SuspendLayout();
            mainSettingsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)returnFontBox).BeginInit();
            SuspendLayout();
            // 
            // mainGroup
            // 
            mainGroup.Controls.Add(mainSettingsTable);
            mainGroup.Dock = DockStyle.Top;
            mainGroup.Location = new Point(0, 0);
            mainGroup.Margin = new Padding(3, 4, 3, 4);
            mainGroup.Name = "mainGroup";
            mainGroup.Padding = new Padding(3, 4, 3, 4);
            mainGroup.Size = new Size(350, 267);
            mainGroup.TabIndex = 0;
            mainGroup.TabStop = false;
            mainGroup.Text = "Main settings";
            // 
            // mainSettingsTable
            // 
            mainSettingsTable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainSettingsTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            mainSettingsTable.ColumnCount = 3;
            mainSettingsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            mainSettingsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            mainSettingsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            mainSettingsTable.Controls.Add(selectedFontLabel, 0, 0);
            mainSettingsTable.Controls.Add(selectedFontBox, 1, 0);
            mainSettingsTable.Controls.Add(returnFontBox, 2, 0);
            mainSettingsTable.Location = new Point(6, 27);
            mainSettingsTable.Name = "mainSettingsTable";
            mainSettingsTable.RowCount = 4;
            mainSettingsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainSettingsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainSettingsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainSettingsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainSettingsTable.Size = new Size(338, 165);
            mainSettingsTable.TabIndex = 0;
            // 
            // selectedFontLabel
            // 
            selectedFontLabel.AutoSize = true;
            selectedFontLabel.Dock = DockStyle.Fill;
            selectedFontLabel.Location = new Point(5, 2);
            selectedFontLabel.Name = "selectedFontLabel";
            selectedFontLabel.Size = new Size(97, 40);
            selectedFontLabel.TabIndex = 0;
            selectedFontLabel.Text = "Selected font";
            selectedFontLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // selectedFontBox
            // 
            selectedFontBox.BorderStyle = BorderStyle.FixedSingle;
            selectedFontBox.Dock = DockStyle.Fill;
            selectedFontBox.Location = new Point(110, 10);
            selectedFontBox.Margin = new Padding(3, 8, 3, 3);
            selectedFontBox.Name = "selectedFontBox";
            selectedFontBox.PlaceholderText = "FONT";
            selectedFontBox.ReadOnly = true;
            selectedFontBox.ScrollBars = ScrollBars.Horizontal;
            selectedFontBox.Size = new Size(185, 27);
            selectedFontBox.TabIndex = 1;
            selectedFontBox.Tag = "strict";
            selectedFontBox.TextAlign = HorizontalAlignment.Center;
            infoTip.SetToolTip(selectedFontBox, "Click to change font");
            selectedFontBox.Click += selectedFontBox_Click;
            // 
            // returnFontBox
            // 
            returnFontBox.BorderStyle = BorderStyle.FixedSingle;
            returnFontBox.Dock = DockStyle.Fill;
            returnFontBox.Location = new Point(301, 4);
            returnFontBox.Margin = new Padding(1, 2, 0, 3);
            returnFontBox.Name = "returnFontBox";
            returnFontBox.Size = new Size(35, 35);
            returnFontBox.SizeMode = PictureBoxSizeMode.CenterImage;
            returnFontBox.TabIndex = 2;
            returnFontBox.TabStop = false;
            infoTip.SetToolTip(returnFontBox, "Restores default font");
            returnFontBox.Click += returnFontBox_Click;
            // 
            // groupBox2
            // 
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 267);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(350, 133);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 400);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(350, 133);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // infoTip
            // 
            infoTip.IsBalloon = true;
            infoTip.ToolTipIcon = ToolTipIcon.Info;
            infoTip.ToolTipTitle = "Keep in mind that is..";
            // 
            // fontDialog
            // 
            fontDialog.Font = new Font("Segoe UI", 11F);
            fontDialog.FontMustExist = true;
            // 
            // SettingsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(mainGroup);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettingsPage";
            Size = new Size(350, 550);
            Load += SettingsPage_Load;
            mainGroup.ResumeLayout(false);
            mainSettingsTable.ResumeLayout(false);
            mainSettingsTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)returnFontBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox mainGroup;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox selectedFontBox;
        private ToolTip infoTip;
        private FontDialog fontDialog;
        private PictureBox returnFontBox;
    }
}
