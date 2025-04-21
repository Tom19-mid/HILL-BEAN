using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Button = System.Windows.Forms.Button;


namespace HILL_BEAN
{
    public partial class FrmKhuVucBan : Form
    {
        public FrmKhuVucBan()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#ECEFF1");
        }
        private void FrmKhuVucBan_Load(object sender, EventArgs e)
        {
            cbTang.Items.Clear();
            cbTang.Items.Add("Tầng trệt");
            cbTang.Items.Add("Tầng 1");
            cbTang.SelectedIndex = 0;
        }

        private void HienThiBanTrongGroupBox(int tu, int den)
        {
            GbKhuVucBan.Controls.Clear(); // Xóa các bàn cũ

            int x = 35, y = 45;
            int count = 0;

            for (int i = tu; i <= den; i++)
            {
                Button btn = new Button();
                btn.Text = "Bàn " + i;
                btn.BackColor = Color.White;
                btn.Size = new Size(130, 70); // Kích thước bàn
                btn.Location = new Point(x, y);
                btn.Font = new Font("Tahoma", 11, FontStyle.Regular);

                GbKhuVucBan.Controls.Add(btn);

                x += 160; // khoảng cách giữa các nút
                count++;

                if (count % 6 == 0) // Sau mỗi 5 bàn thì xuống dòng
                {
                    x = 35;
                    y += 120;
                }
            }
        }


        private void cbTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string khuVuc = cbTang.SelectedItem.ToString();

            if (khuVuc == "Tầng trệt")
            {
                HienThiBanTrongGroupBox(1, 15);
            }
            else if (khuVuc == "Tầng 1")
            {
                HienThiBanTrongGroupBox(16, 30);
            }
        }
    }
}
