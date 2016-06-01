using System.Collections.Generic;

namespace Histogram
{
    partial class LevelsForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.autoButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.showPreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.outputLevelsGreyscalePictureBox = new System.Windows.Forms.PictureBox();
            this.histogramPictureBox = new System.Windows.Forms.PictureBox();
            this.outputLevelsWhiteClipTextBox = new System.Windows.Forms.TextBox();
            this.outputLevelsBlackClipTextBox = new System.Windows.Forms.TextBox();
            this.inputLevelsHighlightsTextBox = new System.Windows.Forms.TextBox();
            this.inputLevelsShadowsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.channelComboBox = new System.Windows.Forms.ComboBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.outputLevelsSlider = new Histogram.TwoSliderControl();
            this.inputLevelsSlider = new Histogram.TwoSliderControl();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputLevelsGreyscalePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(315, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(315, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // autoButton
            // 
            this.autoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoButton.Location = new System.Drawing.Point(315, 109);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(75, 23);
            this.autoButton.TabIndex = 2;
            this.autoButton.Text = "&Auto";
            this.autoButton.UseVisualStyleBackColor = true;
            this.autoButton.Click += new System.EventHandler(this.AutoButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Enabled = false;
            this.optionsButton.Location = new System.Drawing.Point(315, 144);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(75, 23);
            this.optionsButton.TabIndex = 3;
            this.optionsButton.Text = "Op&tions";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // showPreviewCheckBox
            // 
            this.showPreviewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showPreviewCheckBox.AutoSize = true;
            this.showPreviewCheckBox.Checked = true;
            this.showPreviewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPreviewCheckBox.Location = new System.Drawing.Point(315, 181);
            this.showPreviewCheckBox.Name = "showPreviewCheckBox";
            this.showPreviewCheckBox.Size = new System.Drawing.Size(64, 17);
            this.showPreviewCheckBox.TabIndex = 4;
            this.showPreviewCheckBox.Text = "&Preview";
            this.showPreviewCheckBox.UseVisualStyleBackColor = true;
            this.showPreviewCheckBox.CheckedChanged += new System.EventHandler(this.ShowPreviewCheckBox_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.outputLevelsSlider);
            this.groupBox.Controls.Add(this.outputLevelsGreyscalePictureBox);
            this.groupBox.Controls.Add(this.histogramPictureBox);
            this.groupBox.Controls.Add(this.inputLevelsSlider);
            this.groupBox.Controls.Add(this.outputLevelsWhiteClipTextBox);
            this.groupBox.Controls.Add(this.outputLevelsBlackClipTextBox);
            this.groupBox.Controls.Add(this.inputLevelsHighlightsTextBox);
            this.groupBox.Controls.Add(this.inputLevelsShadowsTextBox);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Location = new System.Drawing.Point(12, 7);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(281, 246);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "&Channel";
            // 
            // outputLevelsGreyscalePictureBox
            // 
            this.outputLevelsGreyscalePictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputLevelsGreyscalePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputLevelsGreyscalePictureBox.Location = new System.Drawing.Point(12, 181);
            this.outputLevelsGreyscalePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.outputLevelsGreyscalePictureBox.Name = "outputLevelsGreyscalePictureBox";
            this.outputLevelsGreyscalePictureBox.Size = new System.Drawing.Size(259, 16);
            this.outputLevelsGreyscalePictureBox.TabIndex = 14;
            this.outputLevelsGreyscalePictureBox.TabStop = false;
            // 
            // histogramPictureBox
            // 
            this.histogramPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.histogramPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.histogramPictureBox.Location = new System.Drawing.Point(12, 41);
            this.histogramPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.histogramPictureBox.Name = "histogramPictureBox";
            this.histogramPictureBox.Size = new System.Drawing.Size(259, 70);
            this.histogramPictureBox.TabIndex = 13;
            this.histogramPictureBox.TabStop = false;
            // 
            // outputLevelsWhiteClipTextBox
            // 
            this.outputLevelsWhiteClipTextBox.Location = new System.Drawing.Point(241, 216);
            this.outputLevelsWhiteClipTextBox.Name = "outputLevelsWhiteClipTextBox";
            this.outputLevelsWhiteClipTextBox.Size = new System.Drawing.Size(30, 20);
            this.outputLevelsWhiteClipTextBox.TabIndex = 11;
            this.outputLevelsWhiteClipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // outputLevelsBlackClipTextBox
            // 
            this.outputLevelsBlackClipTextBox.Location = new System.Drawing.Point(11, 216);
            this.outputLevelsBlackClipTextBox.Name = "outputLevelsBlackClipTextBox";
            this.outputLevelsBlackClipTextBox.Size = new System.Drawing.Size(30, 20);
            this.outputLevelsBlackClipTextBox.TabIndex = 10;
            this.outputLevelsBlackClipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // inputLevelsHighlightsTextBox
            // 
            this.inputLevelsHighlightsTextBox.Location = new System.Drawing.Point(241, 129);
            this.inputLevelsHighlightsTextBox.Name = "inputLevelsHighlightsTextBox";
            this.inputLevelsHighlightsTextBox.Size = new System.Drawing.Size(30, 20);
            this.inputLevelsHighlightsTextBox.TabIndex = 9;
            this.inputLevelsHighlightsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // inputLevelsShadowsTextBox
            // 
            this.inputLevelsShadowsTextBox.Location = new System.Drawing.Point(11, 129);
            this.inputLevelsShadowsTextBox.Name = "inputLevelsShadowsTextBox";
            this.inputLevelsShadowsTextBox.Size = new System.Drawing.Size(30, 20);
            this.inputLevelsShadowsTextBox.TabIndex = 7;
            this.inputLevelsShadowsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Output levels:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Input levels:";
            // 
            // channelComboBox
            // 
            this.channelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelComboBox.FormattingEnabled = true;
            this.channelComboBox.Items.AddRange(new object[] {
            "Red\t(Alt+3)",
            "Green\t(Alt+4)",
            "Blue\t(Alt+5)"});
            this.channelComboBox.Location = new System.Drawing.Point(66, 3);
            this.channelComboBox.MaxDropDownItems = 4;
            this.channelComboBox.Name = "channelComboBox";
            this.channelComboBox.Size = new System.Drawing.Size(88, 21);
            this.channelComboBox.TabIndex = 6;
            this.channelComboBox.SelectedIndexChanged += new System.EventHandler(this.ChannelComboBox_SelectedIndexChanged);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(315, 70);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "&Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // outputLevelsSlider
            // 
            this.outputLevelsSlider.HighlightsSliderValue = ((byte)(255));
            this.outputLevelsSlider.Location = new System.Drawing.Point(10, 200);
            this.outputLevelsSlider.Margin = new System.Windows.Forms.Padding(0);
            this.outputLevelsSlider.MaximumSize = new System.Drawing.Size(265, 10);
            this.outputLevelsSlider.MinimumSize = new System.Drawing.Size(265, 10);
            this.outputLevelsSlider.Name = "outputLevelsSlider";
            this.outputLevelsSlider.ShadowsSliderValue = ((byte)(0));
            this.outputLevelsSlider.Size = new System.Drawing.Size(265, 10);
            this.outputLevelsSlider.TabIndex = 15;
            // 
            // inputLevelsSlider
            // 
            this.inputLevelsSlider.HighlightsSliderValue = ((byte)(255));
            this.inputLevelsSlider.Location = new System.Drawing.Point(10, 111);
            this.inputLevelsSlider.Margin = new System.Windows.Forms.Padding(0);
            this.inputLevelsSlider.MaximumSize = new System.Drawing.Size(265, 10);
            this.inputLevelsSlider.MinimumSize = new System.Drawing.Size(265, 10);
            this.inputLevelsSlider.Name = "inputLevelsSlider";
            this.inputLevelsSlider.ShadowsSliderValue = ((byte)(0));
            this.inputLevelsSlider.Size = new System.Drawing.Size(265, 10);
            this.inputLevelsSlider.TabIndex = 12;
            // 
            // LevelsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(402, 265);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.channelComboBox);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.showPreviewCheckBox);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.autoButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelsForm";
            this.ShowInTaskbar = false;
            this.Text = "Levels";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputLevelsGreyscalePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button autoButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.CheckBox showPreviewCheckBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox channelComboBox;
        private System.Windows.Forms.TextBox outputLevelsWhiteClipTextBox;
        private System.Windows.Forms.TextBox outputLevelsBlackClipTextBox;
        private System.Windows.Forms.TextBox inputLevelsHighlightsTextBox;
        private System.Windows.Forms.TextBox inputLevelsShadowsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
        private TwoSliderControl inputLevelsSlider;
        private System.Windows.Forms.PictureBox outputLevelsGreyscalePictureBox;
        private System.Windows.Forms.PictureBox histogramPictureBox;
        private TwoSliderControl outputLevelsSlider;
    }
}