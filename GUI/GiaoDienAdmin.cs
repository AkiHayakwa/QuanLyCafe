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

       

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình ? ", "Đồng ý" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void giaoDienAdminThemNguoiDung1_Load(object sender, EventArgs e)
        {

        }


        private void giaoDienThongKe1_Load(object sender, EventArgs e)
        {

        }

        private void giaoDienAdminThemSP1_Load(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            giaoDienAdminThemNguoiDung1.Visible = false;
            giaoDienAdminThemSP1.Visible = false;
            giaoDienThongKe1.Visible = true;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            giaoDienAdminThemNguoiDung1.Visible = true;
            giaoDienAdminThemSP1.Visible = false;
            giaoDienThongKe1.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            giaoDienAdminThemNguoiDung1.Visible = false;
            giaoDienAdminThemSP1.Visible = true;
            giaoDienThongKe1.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn đăng xuất ?", "Đồng ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }
    }
}
