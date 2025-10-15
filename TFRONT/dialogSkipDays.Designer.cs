namespace TFRONT
{
    partial class DialogSkipDays
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxNbSkipDays = new ComboBox();
            label1 = new Label();
            buttonSkip = new Button();
            SuspendLayout();
            // 
            // comboBoxNbSkipDays
            // 
            comboBoxNbSkipDays.FormattingEnabled = true;
            comboBoxNbSkipDays.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            comboBoxNbSkipDays.Location = new Point(163, 54);
            comboBoxNbSkipDays.Name = "comboBoxNbSkipDays";
            comboBoxNbSkipDays.Size = new Size(121, 23);
            comboBoxNbSkipDays.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 59);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 1;
            label1.Text = "Number of days to skip";
            // 
            // buttonSkip
            // 
            buttonSkip.Location = new Point(245, 108);
            buttonSkip.Name = "buttonSkip";
            buttonSkip.Size = new Size(110, 34);
            buttonSkip.TabIndex = 2;
            buttonSkip.Text = "Skip";
            buttonSkip.UseVisualStyleBackColor = true;
            buttonSkip.Click += buttonSkip_Click;
            // 
            // DialogSkipDays
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 187);
            Controls.Add(buttonSkip);
            Controls.Add(label1);
            Controls.Add(comboBoxNbSkipDays);
            Name = "DialogSkipDays";
            Text = "dialogSkipDays";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxNbSkipDays;
        private Label label1;
        private Button buttonSkip;
    }
}