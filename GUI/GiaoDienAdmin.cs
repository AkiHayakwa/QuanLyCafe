using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GiaoDienAdmin : Form 
    {
        public GiaoDienAdmin()
        {
            InitializeComponent();
        }

        private void GiaoDienAdmin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Khởi tạo UserControl mới
            GiaoDienAdminDashboard giaoDienAdminDashBoard = new GiaoDienAdminDashboard();

            // Kiểm tra xem UserControl đã được thêm vào chưa
            if (!this.Controls.Contains(giaoDienAdminDashBoard))
            {
                // Thêm UserControl vào form
                giaoDienAdminDashBoard.Dock = DockStyle.None; // Không dùng DockStyle.Fill để tự do điều chỉnh vị trí
                this.Controls.Add(giaoDienAdminDashBoard);

                // Căn chỉnh UserControl vào giữa form
                giaoDienAdminDashBoard.Location = new Point(
       (1251 - giaoDienAdminDashBoard.Width) / 2,
       (745 - giaoDienAdminDashBoard.Height) / 2
   );
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình ? ", "Đồng ý" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox .Show("Bạn có muốn đăng xuất ?","Đồng ý",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();  
                loginForm.Show();

                this.Hide();
            }
        }

        private void giaoDienAdminThemNguoiDung1_Load(object sender, EventArgs e)
        {

        }
    }
}
