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
    public partial class GiaoDienDangki : Form
    {
        public GiaoDienDangki()
        {
            InitializeComponent();
        }

        private void register_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Register_loginbtn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();

            this.Hide();
        }

        private void Register_checkpassword_CheckedChanged(object sender, EventArgs e)
        {
            Register_password.PasswordChar = Register_checkpassword.Checked ? '\0' : '*';
            Register_confirmpassword.PasswordChar = Register_checkpassword.Checked ? '\0' : '*';
        }

        public bool emptyField()    // phương thức này xác định tài khoản và mật khẩu có rỗng hay không 
        {
            if(Register_username.Text == "" || Register_password.Text == "" || Register_confirmpassword.Text == "")
            {
                return true;
            }
            return false;
        }
        private void Register_btn_Click(object sender, EventArgs e)   
        {
            if (emptyField())
            {
                MessageBox.Show("Tài khoản , mật khẩu và xác nhận mật khẩu không được để trống ", "Thông Báo !", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }

            string Username = "SELECT * FROM users WHERE username = @userName";
        }
    }
}
