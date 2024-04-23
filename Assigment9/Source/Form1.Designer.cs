namespace GUITest3 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            Scan = new Button();
            Remove = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // Scan
            // 
            Scan.Location = new Point(207, 109);
            Scan.Name = "Scan";
            Scan.Size = new Size(75, 23);
            Scan.TabIndex = 0;
            Scan.Text = "Scan";
            Scan.UseVisualStyleBackColor = true;
            Scan.Click += Scan_Click;
            // 
            // Remove
            // 
            Remove.BackgroundImageLayout = ImageLayout.None;
            Remove.Location = new Point(574, 109);
            Remove.Name = "Remove";
            Remove.Size = new Size(75, 23);
            Remove.TabIndex = 1;
            Remove.Text = "Remove";
            Remove.UseVisualStyleBackColor = true;
            Remove.Click += Remove_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(272, 164);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(308, 147);
            textBox1.TabIndex = 2;
            textBox1.Text = "Info box";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(Remove);
            Controls.Add(Scan);
            Name = "Form1";
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Scan;
        private Button Remove;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox1;
    }
}