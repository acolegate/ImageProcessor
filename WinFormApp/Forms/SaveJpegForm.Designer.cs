namespace ImageProcessor.Forms
{
    sealed partial class SaveJpegForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.qualityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.qualityTrackBar = new System.Windows.Forms.TrackBar();
            this.qualityComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.showHidePreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qualityNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.qualityTrackBar);
            this.groupBox1.Controls.Add(this.qualityComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Options";
            // 
            // qualityNumericUpDown
            // 
            this.qualityNumericUpDown.Location = new System.Drawing.Point(51, 25);
            this.qualityNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.qualityNumericUpDown.Name = "qualityNumericUpDown";
            this.qualityNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.qualityNumericUpDown.TabIndex = 6;
            this.qualityNumericUpDown.ValueChanged += new System.EventHandler(this.QualityNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "large file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "small file";
            // 
            // qualityTrackBar
            // 
            this.qualityTrackBar.AutoSize = false;
            this.qualityTrackBar.LargeChange = 1;
            this.qualityTrackBar.Location = new System.Drawing.Point(9, 74);
            this.qualityTrackBar.Maximum = 12;
            this.qualityTrackBar.Name = "qualityTrackBar";
            this.qualityTrackBar.Size = new System.Drawing.Size(185, 20);
            this.qualityTrackBar.TabIndex = 3;
            this.qualityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.qualityTrackBar.ValueChanged += new System.EventHandler(this.QualityTrackBar_ValueChanged);
            // 
            // qualityComboBox
            // 
            this.qualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityComboBox.FormattingEnabled = true;
            this.qualityComboBox.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High",
            "Maximum"});
            this.qualityComboBox.Location = new System.Drawing.Point(99, 25);
            this.qualityComboBox.MaxDropDownItems = 4;
            this.qualityComboBox.Name = "qualityComboBox";
            this.qualityComboBox.Size = new System.Drawing.Size(95, 21);
            this.qualityComboBox.TabIndex = 2;
            this.qualityComboBox.SelectedIndexChanged += new System.EventHandler(this.QualityComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quality";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(235, 17);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(235, 53);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // showHidePreviewCheckBox
            // 
            this.showHidePreviewCheckBox.AutoSize = true;
            this.showHidePreviewCheckBox.Location = new System.Drawing.Point(243, 86);
            this.showHidePreviewCheckBox.Name = "showHidePreviewCheckBox";
            this.showHidePreviewCheckBox.Size = new System.Drawing.Size(64, 17);
            this.showHidePreviewCheckBox.TabIndex = 3;
            this.showHidePreviewCheckBox.Text = "Preview";
            this.showHidePreviewCheckBox.UseVisualStyleBackColor = true;
            this.showHidePreviewCheckBox.CheckedChanged += new System.EventHandler(this.ShowHidePreviewCheckBox_CheckedChanged);
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Location = new System.Drawing.Point(240, 110);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(37, 13);
            this.fileSizeLabel.TabIndex = 4;
            this.fileSizeLabel.Text = "[SIZE]";
            // 
            // SaveJpegForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(325, 136);
            this.Controls.Add(this.fileSizeLabel);
            this.Controls.Add(this.showHidePreviewCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveJpegForm";
            this.ShowInTaskbar = false;
            this.Text = "JPEG Options";
            this.Load += new System.EventHandler(this.SaveJpegForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar qualityTrackBar;
        private System.Windows.Forms.ComboBox qualityComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox showHidePreviewCheckBox;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.NumericUpDown qualityNumericUpDown;
    }
}