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
    public partial class FrmGiaoDien: Form
    {
        public string currentUsername;
        public FrmGiaoDien(string username)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#b9cdcb");
            currentUsername = username;
            lblWelcome.Text = "Chào mừng";
            lblUsername.Text = username;
            lblUsername.Left = (lblUsername.Parent.Width - lblUsername.Width) / 2;
            lblUsername.Top = (lblUsername.Parent.Height - lblUsername.Height) / 2;
            MakeroundPtbHillBean(PtbHillBean, 30);
            panelMain.BringToFront(); // khi cần hiển thị Form con
            PtbCat.BringToFront(); // nếu muốn ảnh mèo nổi lên trên lại
            lbHowAreYou.BringToFront();
            lbXinChao.BringToFront();
            MakepanelMain(panelMain, 20);
        }

        private void MakepanelMain(Panel panelMain, int raidus)
        {
            Rectangle bounds = panelMain.ClientRectangle;
            GraphicsPath path = new GraphicsPath();
            int diameter = raidus * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            panelMain.Region = new Region(path);

            panelMain.Invalidate();
        }

        private void MakeroundPtbHillBean(PictureBox ptbHillBean, int raidus)
        {
            Rectangle bounds = ptbHillBean.ClientRectangle;
            GraphicsPath path = new GraphicsPath();
            int diameter = raidus * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            ptbHillBean.Region = new Region(path);

            ptbHillBean.Invalidate();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangNhap FromMain = new FrmDangNhap();
            FromMain.ShowDialog();
            this.Close();
        }
        private void LoadForm(Form frm)
        {
            panelMain.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(frm);
            panelMain.Tag = frm;
            frm.Show();
        }
        private void HideWelcomeLabels()
        {
            PtbCat.Visible = false;
            lbXinChao.Visible = false;
            lbHowAreYou.Visible = false;
        }

        // btnBanHangClick
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            HideWelcomeLabels();
            LoadForm(new FrmBanHang());
        }

        // btnHoaDon
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HideWelcomeLabels();
            LoadForm(new FrmHoaDon());
        }

        // btnNhanViem
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            HideWelcomeLabels();
            LoadForm(new FrmQuanLiNhanVien());
        }

        // btnKhoHang
        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            HideWelcomeLabels();
            LoadForm(new FrmKhoHang());
        }

        // btnThongKeDoanhThu
        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            HideWelcomeLabels();
            LoadForm(new FrmThongKeDoanhThu1());
        }

        private void btnKhuVucBan_Click(object sender, EventArgs e)
        {
            HideWelcomeLabels();
            LoadForm(new FrmKhuVucBan());
        }
    }
}
