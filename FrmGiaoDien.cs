﻿using System;
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

<<<<<<< HEAD
            FrmDangNhap FromMain = new FrmDangNhap();
=======
            FrmMain FromMain = new FrmMain();
>>>>>>> 9a978c4f068d4732da3c60f77809364a6549c814
            FromMain.ShowDialog();

            this.Close();
        }
    }
}
