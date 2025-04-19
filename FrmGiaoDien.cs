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
            lblWelcome.Text = "Chào mừng " + username;
            MakeroundPtbHillBean(PtbHillBean, 30);
            panelBanHang.BringToFront(); // khi cần hiển thị Form con
            PtbCat.BringToFront(); // nếu muốn ảnh mèo nổi lên trên lại
            lbHowAreYou.BringToFront();
            lbXinChao.BringToFront();
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

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            // Ẩn mèo và các dòng chào
            PtbCat.Visible = false;
            lbXinChao.Visible = false;
            lbHowAreYou.Visible = false;

            // Load form FrmBanHang vào panelMain
            FrmBanHang frmBanHang = new FrmBanHang();
            LoadFormCon(frmBanHang);
        }

        
        private void LoadFormCon(Form formCon)
        {
            panelBanHang.Controls.Clear(); // dùng đúng tên Panel
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            panelBanHang.Controls.Add(formCon);
            panelBanHang.Tag = formCon;
            formCon.Show();
        }

      
    }
}
