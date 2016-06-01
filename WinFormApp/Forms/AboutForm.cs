using System.Diagnostics;
using System.Windows.Forms;

namespace ImageProcessor.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:adrian@colegate.net?subject=ImageProcessor");
        }
    }
}
