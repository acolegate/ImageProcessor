namespace ImageProcessor.Underwater
{
    partial class FilterForm
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
            this.afterPictureBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.beforePictureBox = new System.Windows.Forms.PictureBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.blueGammaTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.greenGammaTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.redGammaTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.redHighValueClipTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.redGenerationIntensityTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.afterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beforePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueGammaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenGammaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redGammaTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redHighValueClipTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redGenerationIntensityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // afterPictureBox
            // 
            this.afterPictureBox.BackColor = System.Drawing.Color.Gray;
            this.afterPictureBox.Location = new System.Drawing.Point(332, 12);
            this.afterPictureBox.Name = "afterPictureBox";
            this.afterPictureBox.Size = new System.Drawing.Size(320, 320);
            this.afterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.afterPictureBox.TabIndex = 0;
            this.afterPictureBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(783, 309);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Location = new System.Drawing.Point(702, 309);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 2;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // beforePictureBox
            // 
            this.beforePictureBox.BackColor = System.Drawing.Color.Gray;
            this.beforePictureBox.Location = new System.Drawing.Point(12, 12);
            this.beforePictureBox.Name = "beforePictureBox";
            this.beforePictureBox.Size = new System.Drawing.Size(320, 320);
            this.beforePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.beforePictureBox.TabIndex = 8;
            this.beforePictureBox.TabStop = false;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.resetButton.Location = new System.Drawing.Point(783, 240);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.blueGammaTrackBar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.greenGammaTrackBar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.redGammaTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(665, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 97);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gamma";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "B";
            // 
            // blueGammaTrackBar
            // 
            this.blueGammaTrackBar.AutoSize = false;
            this.blueGammaTrackBar.LargeChange = 10;
            this.blueGammaTrackBar.Location = new System.Drawing.Point(22, 66);
            this.blueGammaTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.blueGammaTrackBar.Maximum = 150;
            this.blueGammaTrackBar.Minimum = 50;
            this.blueGammaTrackBar.Name = "blueGammaTrackBar";
            this.blueGammaTrackBar.Size = new System.Drawing.Size(168, 25);
            this.blueGammaTrackBar.TabIndex = 15;
            this.blueGammaTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.blueGammaTrackBar.Value = 100;
            this.blueGammaTrackBar.Scroll += new System.EventHandler(this.GammaTrackBar_Scroll);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "G";
            // 
            // greenGammaTrackBar
            // 
            this.greenGammaTrackBar.AutoSize = false;
            this.greenGammaTrackBar.LargeChange = 10;
            this.greenGammaTrackBar.Location = new System.Drawing.Point(22, 41);
            this.greenGammaTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.greenGammaTrackBar.Maximum = 150;
            this.greenGammaTrackBar.Minimum = 50;
            this.greenGammaTrackBar.Name = "greenGammaTrackBar";
            this.greenGammaTrackBar.Size = new System.Drawing.Size(168, 25);
            this.greenGammaTrackBar.TabIndex = 13;
            this.greenGammaTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.greenGammaTrackBar.Value = 100;
            this.greenGammaTrackBar.Scroll += new System.EventHandler(this.GammaTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "R";
            // 
            // redGammaTrackBar
            // 
            this.redGammaTrackBar.AutoSize = false;
            this.redGammaTrackBar.LargeChange = 10;
            this.redGammaTrackBar.Location = new System.Drawing.Point(22, 16);
            this.redGammaTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.redGammaTrackBar.Maximum = 150;
            this.redGammaTrackBar.Minimum = 50;
            this.redGammaTrackBar.Name = "redGammaTrackBar";
            this.redGammaTrackBar.Size = new System.Drawing.Size(168, 25);
            this.redGammaTrackBar.TabIndex = 11;
            this.redGammaTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.redGammaTrackBar.Value = 100;
            this.redGammaTrackBar.Scroll += new System.EventHandler(this.GammaTrackBar_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.redHighValueClipTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(665, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 48);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Red high value clip";
            // 
            // redHighValueClipTrackBar
            // 
            this.redHighValueClipTrackBar.AutoSize = false;
            this.redHighValueClipTrackBar.LargeChange = 10;
            this.redHighValueClipTrackBar.Location = new System.Drawing.Point(3, 16);
            this.redHighValueClipTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.redHighValueClipTrackBar.Maximum = 255;
            this.redHighValueClipTrackBar.Name = "redHighValueClipTrackBar";
            this.redHighValueClipTrackBar.Size = new System.Drawing.Size(187, 25);
            this.redHighValueClipTrackBar.TabIndex = 11;
            this.redHighValueClipTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.redHighValueClipTrackBar.Value = 255;
            this.redHighValueClipTrackBar.Scroll += new System.EventHandler(this.RedHighValueClipTrackBar_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox3.Controls.Add(this.redGenerationIntensityTrackBar);
            this.groupBox3.Location = new System.Drawing.Point(665, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 47);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Red generation intensity";
            // 
            // redGenerationIntensityTrackBar
            // 
            this.redGenerationIntensityTrackBar.AutoSize = false;
            this.redGenerationIntensityTrackBar.LargeChange = 10;
            this.redGenerationIntensityTrackBar.Location = new System.Drawing.Point(3, 16);
            this.redGenerationIntensityTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.redGenerationIntensityTrackBar.Maximum = 255;
            this.redGenerationIntensityTrackBar.Name = "redGenerationIntensityTrackBar";
            this.redGenerationIntensityTrackBar.Size = new System.Drawing.Size(187, 25);
            this.redGenerationIntensityTrackBar.TabIndex = 11;
            this.redGenerationIntensityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.redGenerationIntensityTrackBar.Value = 255;
            this.redGenerationIntensityTrackBar.Scroll += new System.EventHandler(this.RedGenerationIntensityTrackBar_Scroll);
            // 
            // FilterForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(870, 345);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.beforePictureBox);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.afterPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.Text = "Underwater";
            ((System.ComponentModel.ISupportInitialize)(this.afterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beforePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueGammaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenGammaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redGammaTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.redHighValueClipTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.redGenerationIntensityTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox afterPictureBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.PictureBox beforePictureBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar redGammaTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar redHighValueClipTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar blueGammaTrackBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar greenGammaTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar redGenerationIntensityTrackBar;
    }
}