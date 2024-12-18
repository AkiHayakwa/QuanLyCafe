using BUS;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BUS;
using DTO;
namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_registerbtn_Click(object sender, EventArgs e)
        {
            GiaoDienDangki RegisterForm = new GiaoDienDangki();
            RegisterForm.Show();

            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Tài khoản , mật khẩu không được để trống ", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TaiKhoanBus taikhoanbus = new TaiKhoanBus();
                bool isValid = taikhoanbus.Login(Login_username.Text, login_password.Text);

                if (isValid)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GiaoDienAdmin adminControl = new GiaoDienAdmin();
                    adminControl.Show();

                    // Ẩn form đăng nhập (Form1)
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void login_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showpassword.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            if (Login_username.Text == "" || login_password.Text == "")
            {
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
