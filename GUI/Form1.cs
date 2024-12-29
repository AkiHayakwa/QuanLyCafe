
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
                string password = login_password.Text;
                if(password == "")
                {
                    MessageBox.Show("lỗi không cho có dấu cách ");
                }
                    string quyen = taikhoanbus.Login(Login_username.Text, password); // Lấy quyền người dùng
                    
                    if (quyen != null)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Kiểm tra quyền người dùng và chuyển tới form tương ứng
                        if (quyen == "Admin")
                        {
                            GiaoDienAdmin adminControl = new GiaoDienAdmin();
                            adminControl.Show();
                        }
                        else if (quyen == "Thu Ngân")
                        {
                            GiaoDienThuNgan thuNganControl = new GiaoDienThuNgan();
                            thuNganControl.Show();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không có quyền hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                 
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



        private void label5_Click(object sender, EventArgs e)
        {
            string username = Login_username.Text;  // Lấy tên người dùng từ trường nhập

            // Kiểm tra nếu người dùng chưa nhập tên
            if (string.IsNullOrWhiteSpace(username) || username == "Nhập tên người dùng...")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng trước khi reset mật khẩu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị hộp thoại yêu cầu người dùng nhập mật khẩu mới
            using (Form resetPasswordForm = new Form())
            {
                resetPasswordForm.Text = "Đổi mật khẩu"; // Tiêu đề form
                resetPasswordForm.Size = new Size(300, 150); // Kích thước form

                
                TextBox txtNewPassword = new TextBox()
                {
                    Text = "Nhập mật khẩu mới...", 
                    PasswordChar = '*',
                    Dock = DockStyle.Bottom,
                    Margin = new Padding(10),
                    ForeColor = Color.Gray
                };

                // Tạo nút Đổi mật khẩu
                Button btnSubmit = new Button()
                {
                    Text = "Đổi mật khẩu",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                resetPasswordForm.Controls.Add(txtNewPassword);
                resetPasswordForm.Controls.Add(btnSubmit);

                // Khi người dùng nhấn nút Đổi mật khẩu
                btnSubmit.Click += (senderBtn, eBtn) =>
                {
                    string newPassword = txtNewPassword.Text;

                    // Kiểm tra nếu mật khẩu mới rỗng
                    if (string.IsNullOrWhiteSpace(newPassword) || newPassword == "Nhập mật khẩu mới...")
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật mật khẩu mới sau khi xác nhận
                    var result = MessageBox.Show("Bạn có chắc chắn muốn đổi mật khẩu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Gọi phương thức để cập nhật mật khẩu mới vào cơ sở dữ liệu
                        ResetPassword(username, newPassword);
                    }

                    resetPasswordForm.Close();
                };

                // Hiển thị form cho phép người dùng nhập mật khẩu mới
                resetPasswordForm.ShowDialog();
            }
        }

        // Phương thức xử lý logic đổi mật khẩu
        private void ResetPassword(string username, string newPassword)
        {
            try
            {
                // Gọi phương thức trong BUS để reset mật khẩu
                TaiKhoanBus taiKhoanBus = new TaiKhoanBus();
                bool result = taiKhoanBus.ResetPassword(username, newPassword);

                if (result)
                {
                    MessageBox.Show("Mật khẩu đã được reset thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản, không thể reset mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

    }
    }
