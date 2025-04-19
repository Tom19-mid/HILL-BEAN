using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HILL_BEAN
{
    public partial class FrmDangNhap: Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#b9cdcb");
            MakeRoundPtbHillBean(PtbHillBean, 30);
            MakeRoundPtbIconCoffee(PtbconCoffee, 46);

            Image original = Image.FromFile("iconCoffee-removebg-preview.png");

            Image rotated = RotateImage(original, 20);

            PtbconCoffee.Image = rotated;

            Image originalImage = Image.FromFile("b61fa94de9190721e7c3ece1e81ee285-removebg-preview (1).png");

            Image flippedImageHorizontal = FlipImage(originalImage, true); 

            Image flippedImageVertical = FlipImage(originalImage, false);

            PtbhoaCoffe2.Image = flippedImageHorizontal; 
        }

        private Image FlipImage(Image originalImage, bool flipHorizontal)
        {
            Bitmap flippedImage = new Bitmap(originalImage);
            
            using (Graphics g = Graphics.FromImage(flippedImage))
            {
                if (flipHorizontal)
                {
                    // Lật ảnh theo chiều ngang
                    g.Clear(Color.White);
                    g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height), 
                        new Rectangle(originalImage.Width, 0, -originalImage.Width, originalImage.Height), 
                        GraphicsUnit.Pixel);
                }
                else
                {
                    // Lật ảnh theo chiều dọc
                    g.Clear(Color.White);
                    g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height), 
                        new Rectangle(0, originalImage.Height, originalImage.Width, -originalImage.Height), 
                        GraphicsUnit.Pixel);
                }
            }
            return flippedImage;
        }

        public void MakeRoundPtbHillBean(PictureBox ptbHillBean, int raidus)
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

        public static Bitmap RotateImage(Image image, float angle)
        {
            // Tính toán góc radian từ độ
            float radAngle = angle * (float)Math.PI / 180f;
            float cos = Math.Abs((float)Math.Cos(radAngle));
            float sin = Math.Abs((float)Math.Sin(radAngle));

            // Tính toán kích thước mới của ảnh sau khi xoay
            int newWidth = (int)(image.Width * cos + image.Height * sin);
            int newHeight = (int)(image.Width * sin + image.Height * cos);

            Bitmap rotatedBmp = new Bitmap(newWidth, newHeight);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                // Di chuyển tâm ảnh đến giữa để xoay
                g.TranslateTransform(newWidth / 2f, newHeight / 2f);

                // Xoay ảnh 90 độ (hoặc thay đổi góc tùy nhu cầu)
                g.RotateTransform(angle);                            // xoay theo góc
                g.TranslateTransform(-image.Width / 2f, -image.Height / 2f); // Quay lại vị trí cũ

                // Vẽ lại ảnh sau khi xoay
                g.DrawImage(image, new Point(0, 0));

                // làm rõ ảnh
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            }
            return rotatedBmp;

        }
        private void MakeRoundPtbIconCoffee(PictureBox ptbIconCoffee, int raidus)
        {
           
            // Đảm bảo PictureBox có kích thước thích hợp
            int diameter = raidus * 2;
            ptbIconCoffee.Width = diameter;
            ptbIconCoffee.Height = diameter;
            PtbconCoffee.Width = 100;  
            PtbconCoffee.Height = 100; 

            // Lấy vùng của PictureBox
            Rectangle bounds = ptbIconCoffee.ClientRectangle;
            GraphicsPath path = new GraphicsPath();

            // Thêm các đường cong để tạo hình tròn góc
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            // Gán vùng cho PictureBox để bo góc
            ptbIconCoffee.Region = new Region(path);

            // Gọi lại Invalidate để vẽ lại PictureBox với vùng mới
            ptbIconCoffee.Invalidate();
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            if(username == "admin" && password == "123")
            {
                this.Hide();
                FrmGiaoDien FromGDien = new FrmGiaoDien(username);
                FromGDien.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu !");
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
