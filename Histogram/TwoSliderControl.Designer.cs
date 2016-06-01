namespace Histogram
{
    sealed partial class TwoSliderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shadowsPictureBox = new System.Windows.Forms.PictureBox();
            this.highlightsPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.shadowsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // shadowsPictureBox
            // 
            this.shadowsPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.shadowsPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.shadowsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.shadowsPictureBox.Image = global::Histogram.Properties.Resources.shadows;
            this.shadowsPictureBox.Location = new System.Drawing.Point(0, 0);
            this.shadowsPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.shadowsPictureBox.Name = "shadowsPictureBox";
            this.shadowsPictureBox.Size = new System.Drawing.Size(9, 10);
            this.shadowsPictureBox.TabIndex = 3;
            this.shadowsPictureBox.TabStop = false;
            this.shadowsPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.shadowsPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.shadowsPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // highlightsPictureBox
            // 
            this.highlightsPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.highlightsPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.highlightsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.highlightsPictureBox.Image = global::Histogram.Properties.Resources.highlights;
            this.highlightsPictureBox.Location = new System.Drawing.Point(256, 0);
            this.highlightsPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.highlightsPictureBox.Name = "highlightsPictureBox";
            this.highlightsPictureBox.Size = new System.Drawing.Size(9, 10);
            this.highlightsPictureBox.TabIndex = 5;
            this.highlightsPictureBox.TabStop = false;
            this.highlightsPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.highlightsPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.highlightsPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // TwoSliderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.highlightsPictureBox);
            this.Controls.Add(this.shadowsPictureBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(265, 10);
            this.MinimumSize = new System.Drawing.Size(265, 10);
            this.Name = "TwoSliderControl";
            this.Size = new System.Drawing.Size(265, 10);
            ((System.ComponentModel.ISupportInitialize)(this.shadowsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightsPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox shadowsPictureBox;
        private System.Windows.Forms.PictureBox highlightsPictureBox;

    }
}
