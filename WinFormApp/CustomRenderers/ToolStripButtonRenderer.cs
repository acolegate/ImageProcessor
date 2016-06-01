using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessor.CustomRenderers
{
    public class MyToolStripRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStripButton button = e.Item as ToolStripButton;

            if (button != null && button.CheckOnClick && button.Checked)
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(160, 160, 160)), bounds);
            }
            else
            {
                base.OnRenderButtonBackground(e);
            }
        }
    }
}
