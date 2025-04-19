using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HILL_BEAN
{
    public partial class FrmQuanLiNhanVien: Form
    {
        public FrmQuanLiNhanVien()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#b9cdcb");
            MakeroundPtbHillBean(PtbHillBean, 20);
        }

        private void MakeroundPtbHillBean(PictureBox ptbHillBean, int radius)
        {
            Rectangle bounds = ptbHillBean.ClientRectangle;
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            ptbHillBean.Region = new Region(path);

            ptbHillBean.Invalidate();
        }

        private void FrmQuanLiNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
