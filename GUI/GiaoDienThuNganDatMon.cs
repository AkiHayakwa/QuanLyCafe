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
            InitializeDgvOrder();
        }

        private void InitializeDgvOrder()
        {
            if (dgv_Order.Columns.Count == 0)
            {
                dgv_Order.Columns.Add("IdSanPham", "ID Sản phẩm");
                dgv_Order.Columns.Add("TenSanPham", "Tên Sản phẩm");
                dgv_Order.Columns.Add("SoLuong", "Số lượng");
                dgv_Order.Columns.Add("DonGia", "Đơn giá");
                dgv_Order.Columns.Add("TongTien", "Tổng Tiền");
            }
        }


        private void dgv_Prd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Prd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin sản phẩm
                int idSanPham = Convert.ToInt32(dgv_Prd.Rows[e.RowIndex].Cells["id_SanPham"].Value);
                string tenSanPham = dgv_Prd.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
                decimal giaSanPham = Convert.ToDecimal(dgv_Prd.Rows[e.RowIndex].Cells["GiaMua"].Value);
                int soLuongTonHienTai = Convert.ToInt32(dgv_Prd.Rows[e.RowIndex].Cells["SoLuongTon"].Value);

                // Kiểm tra số lượng tồn
                if (soLuongTonHienTai > 0)
                {
                    // Thêm sản phẩm vào giỏ hàng
                    bool productExists = false;

                    foreach (DataGridViewRow row in dgv_Order.Rows)
                    {
                        // Kiểm tra nếu sản phẩm đã tồn tại trong giỏ hàng
                        if (Convert.ToInt32(row.Cells["IdSanPham"].Value) == idSanPham)
                        {
                            // Cập nhật số lượng
                            int currentQuantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                            row.Cells["SoLuong"].Value = currentQuantity + 1;

                            // Cập nhật tổng tiền
                            decimal totalPrice = Convert.ToInt32(row.Cells["SoLuong"].Value) * giaSanPham;
                            row.Cells["TongTien"].Value = totalPrice;

                            productExists = true;
                            break;
                        }
                    }

                    if (!productExists)
                    {
                        // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                        dgv_Order.Rows.Add(idSanPham, tenSanPham, 1, giaSanPham, giaSanPham); // Mặc định số lượng = 1, tính tổng tiền = đơn giá

                        // Cập nhật số lượng tồn
                        dgv_Prd.Rows[e.RowIndex].Cells["SoLuongTon"].Value = soLuongTonHienTai - 1;
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm này không còn đủ số lượng.", "Lỗi");
                }
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

        private void dgv_Order_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 
 }
