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
    public partial class GiaoDienThuNganDatMon : UserControl
    {
        public GiaoDienThuNganDatMon()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string tenDanhMuc = CashierCategory.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(tenDanhMuc))
                {
                    // Lấy idDanhMuc từ tên danh mục
                    DanhMucBUS danhmucbus = new DanhMucBUS();
                    List<DanhMucDTO> danhMucList = danhmucbus.GetAllDanhMuc();
                    int idDanhMuc = danhMucList.FirstOrDefault(d => d.TenDanhMuc == tenDanhMuc)?.Id_danhMuc ?? 0;

                    if (idDanhMuc > 0)
                    {
                        // Gọi hàm load sản phẩm theo danh mục
                        LoadSanPhamByDanhMuc(idDanhMuc);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ID danh mục.", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn danh mục.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi danh mục: " + ex.Message, "Lỗi");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String s = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            labelTime.Text = s;

            if (!string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.Text.Substring(1) + this.Text[0];
            }
        }

        private void label_ThoiGian_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void GiaoDienThuNganDatMon_Load(object sender, EventArgs e)
        {
            if (dgv_Order.Columns.Count == 0)
            {
                dgv_Order.Columns.Add("TenSanPham", "Tên Sản Phẩm");
                dgv_Order.Columns.Add("GiaBan", "Đơn Giá");
                dgv_Order.Columns.Add("SoLuong", "Số Lượng");
            }
            LoadDanhMuc();
        }

        private void dgv_Prd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Prd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉ số dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Kiểm tra nếu các cột "TenSanPham" và "GiaBan" tồn tại
                if (!dgv_Prd.Columns.Contains("TenSanPham"))
                {
                    MessageBox.Show("Cột 'TenSanPham' không tồn tại!", "Lỗi");
                    return; // Dừng nếu cột không tồn tại
                }

                if (!dgv_Prd.Columns.Contains("GiaMua"))
                {
                    MessageBox.Show("Cột 'GiaBan' không tồn tại!", "Lỗi");
                    return; // Dừng nếu cột không tồn tại
                }

                // Lấy ô cột "TenSanPham" và "GiaBan"
                var tenSanPhamCell = dgv_Prd.Rows[e.RowIndex].Cells["TenSanPham"];
                var giaBanCell = dgv_Prd.Rows[e.RowIndex].Cells["GiaMua"];

                // Kiểm tra nếu các ô này có giá trị hợp lệ (không phải null hoặc DBNull)
                if (tenSanPhamCell != null && tenSanPhamCell.Value != DBNull.Value && giaBanCell != null && giaBanCell.Value != DBNull.Value)
                {
                    string tenSanPham = tenSanPhamCell.Value.ToString();
                    string giaBan = giaBanCell.Value.ToString();

                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = MessageBox.Show($"Bạn muốn order sản phẩm '{tenSanPham}' không?", "Xác nhận Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool daTonTai = false;

                        // Kiểm tra xem sản phẩm đã có trong đơn hàng chưa
                        foreach (DataGridViewRow row in dgv_Order.Rows)
                        {
                            if (row.Cells["TenSanPham"]?.Value != null && row.Cells["TenSanPham"].Value.ToString() == tenSanPham)
                            {
                                try
                                {
                                    int soLuongHienTai = 0;
                                    if (row.Cells["SoLuong"]?.Value != null)
                                    {
                                        int.TryParse(row.Cells["SoLuong"].Value.ToString(), out soLuongHienTai);
                                    }

                                    // Tăng số lượng sản phẩm
                                    row.Cells["SoLuong"].Value = soLuongHienTai + 1;
                                    daTonTai = true;
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Lỗi khi tăng số lượng: {ex.Message}", "Lỗi");
                                }
                            }
                        }

                        // Nếu sản phẩm chưa có trong đơn hàng, thêm mới
                        if (!daTonTai)
                        {
                            dgv_Order.Rows.Add(tenSanPham, giaBan, 1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ trong các ô 'Tên Sản Phẩm' hoặc 'Giá Bán'.", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Chọn một dòng hợp lệ trong bảng.", "Lỗi");
            }
        }


        private void LoadDanhMuc()
        {
          
                try
                {
                    DanhMucBUS danhmucbus = new DanhMucBUS();
                    List<DanhMucDTO> danhMucList = danhmucbus.GetAllDanhMuc();

                    CashierCategory.Items.Clear();
                    foreach (var danhMuc in danhMucList)
                    {
                        CashierCategory.Items.Add(danhMuc.TenDanhMuc);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi");
                }
          
        }


        // Hàm tùy chỉnh hiển thị cột DataGridView
        private void LoadSanPhamByDanhMuc(int idDanhMuc)
        {
            try
            {
                SanPhamBUS sanphambus = new SanPhamBUS();
                List<SanPhamDTO> sanPhamList = sanphambus.GetSanPhamByIdDanhMuc(idDanhMuc);

                if (sanPhamList == null || sanPhamList.Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm nào trong danh mục này.", "Thông báo");
                    dgv_Prd.DataSource = null;
                    return;
                }

                //dgv_Prd.AutoGenerateColumns = true;
                dgv_Prd.DataSource = sanPhamList;

                if (dgv_Prd.Columns.Contains("Id_DanhMuc"))
                {
                    dgv_Prd.Columns.Remove("Id_DanhMuc");
                }

                if (dgv_Prd.Columns.Count > 0)
                {
                    dgv_Prd.Columns["Id_SanPham"].HeaderText = "ID Sản phẩm";
                    dgv_Prd.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                    dgv_Prd.Columns["GiaMua"].HeaderText = "Giá Bán";


                    if (dgv_Prd.Columns.Contains("SoLuongTon"))
                    {
                        dgv_Prd.Columns["SoLuongTon"].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Lấy button đã click
            Button clickedButton = sender as Button;

            // Kiểm tra và thay đổi màu sắc
            if (clickedButton.BackColor == Color.Red)
            {
                clickedButton.BackColor = SystemColors.Control; // Màu mặc định
            }
            else
            {
                clickedButton.BackColor = Color.Red;
            }
        }

        private void Cashierbtnpayment_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv_Order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    } 
 }
