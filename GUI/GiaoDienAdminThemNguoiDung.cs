using BUS;
using DAO;
using DTO;
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
    public partial class GiaoDienAdminThemNguoiDung : UserControl
    {
        public GiaoDienAdminThemNguoiDung()
        {
            InitializeComponent();
        }

        public bool emptyField()
        {
            if(AdminAddUser_username.Text == "" || AdminAddUser_password.Text == "" || AdminAddUser_Role.Text == "" || AdminAddUser_Status.Text == "")
            {
                return true;
            }
            return false;
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (emptyField())
            {
                MessageBox.Show("Tài khoản , mật khẩu không được để trống ", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                // Tạo đối tượng người dùng mới
                TaiKhoanDTO newUser = new TaiKhoanDTO
                {
                    TenNguoiDung = AdminAddUser_username.Text,
                    MatKhau = AdminAddUser_password.Text,
                    Quyen = AdminAddUser_Role.Text,
                    TrangThai = AdminAddUser_Status.Text
                };

                // Sử dụng lớp BUS để thêm người dùng
                TaiKhoanBus taiKhoanBus = new TaiKhoanBus();
                bool result = taiKhoanBus.AddTaiKhoan(newUser);

                if (result)
                {
                    MessageBox.Show("Thêm người dùng thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset các trường nhập sau khi thêm thành công
                    AdminAddUser_username.Text = "";
                    AdminAddUser_password.Text = "";
                    AdminAddUser_Role.Text = "";
                    AdminAddUser_Status.Text = "";

                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại. Vui lòng thử lại!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachTaiKhoan()
        {
            TaiKhoanBus taiKhoanBus = new TaiKhoanBus();
            try
            {
                List<TaiKhoanDTO> danhSachTaiKhoan = taiKhoanBus.GetAllTaiKhoan();
                dgv_UserAccount.DataSource = danhSachTaiKhoan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void LoadDataGridView()
        {
            TaiKhoanBus taiKhoanBus = new TaiKhoanBus();
            List<TaiKhoanDTO> danhSachTaiKhoan = taiKhoanBus.GetAllTaiKhoan(); // Lấy danh sách từ cơ sở dữ liệu
            dgv_UserAccount.DataSource = danhSachTaiKhoan; // Gán nguồn dữ liệu
        }

        private void Admin_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GiaoDienAdminThemNguoiDung_Load(object sender, EventArgs e)
        {
            LoadDanhSachTaiKhoan();
        }

        private void dgv_UserAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int id = 0;
        private void dgv_UserAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_UserAccount.Rows[e.RowIndex];
            id = (int)row.Cells[0].Value;
            AdminAddUser_username.Text = row.Cells[1].Value.ToString();
            AdminAddUser_password.Text = row.Cells[2].Value.ToString();
            AdminAddUser_Role.Text = row.Cells[4].Value.ToString();
            AdminAddUser_Status.Text = row.Cells[3].Value.ToString();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường có trống không
            if (emptyField())
            {
                MessageBox.Show("Tài khoản, mật khẩu và các thông tin không được để trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật người dùng : " + AdminAddUser_username.Text.Trim() + "?", "Thông Báo đồng ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                // Lấy thông tin từ các TextBox
                string userName = AdminAddUser_username.Text.Trim();
                string passWord = AdminAddUser_password.Text.Trim();
                string role = AdminAddUser_Role.SelectedItem.ToString();
                string status  = AdminAddUser_Status.SelectedItem.ToString(); // ComboBox chọn trạng thái    // ComboBox chọn quyền
                

                // Tạo đối tượng TaiKhoanDTO
                TaiKhoanDTO taiKhoan = new TaiKhoanDTO
                {
                    Id_TaiKhoan = id,
                    TenNguoiDung = userName,
                    MatKhau = passWord,
                    Quyen = role , 
                    TrangThai = status  
                };

                // Gọi hàm cập nhật trong BUS
                TaiKhoanBus taiKhoanBus = new TaiKhoanBus();
                bool isUpdated = taiKhoanBus.UpdateTaiKhoan(taiKhoan);

                // Thông báo kết quả
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearFields()
        {
            AdminAddUser_username.Text = "";
            AdminAddUser_password.Text = "";
            AdminAddUser_Role.SelectedIndex = -1;
            AdminAddUser_Status.SelectedIndex = -1;
        }
        private void btnClearUser_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường có trống không
            if (emptyField())
            {
                MessageBox.Show("Tài khoản, mật khẩu và các thông tin không được để trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn xóa người dùng : " + AdminAddUser_username.Text.Trim() + "?", "Thông Báo đồng ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                // Lấy thông tin từ các TextBox


                // Tạo đối tượng TaiKhoanDTO

                // Gọi hàm cập nhật trong BUS
                TaiKhoanBus taiKhoanBus = new TaiKhoanBus();
                bool isDeleted = taiKhoanBus.DeleteTaiKhoan(id);

                // Thông báo kết quả
                if (isDeleted)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView(); // Tải lại danh sách tài khoản sau khi xóa
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
