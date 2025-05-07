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
            mainGroup = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            SuspendLayout();
            // 
            // mainGroup
            // 
            mainGroup.Dock = DockStyle.Top;
            mainGroup.Location = new Point(0, 0);
            mainGroup.Name = "mainGroup";
            mainGroup.Size = new Size(350, 100);
            mainGroup.TabIndex = 0;
            mainGroup.TabStop = false;
            mainGroup.Text = "groupBox1";
            // 
            // groupBox2
            // 
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(350, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 200);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(350, 100);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // groupBox4
            // 
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 300);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(350, 100);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "groupBox4";
            // 
            // groupBox5
            // 
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Location = new Point(0, 400);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(350, 100);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "groupBox5";
            // 
            // SettingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(mainGroup);
            Name = "SettingsPage";
            Size = new Size(350, 550);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox mainGroup;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
    }
}
