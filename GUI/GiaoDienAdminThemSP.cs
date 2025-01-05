using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class GiaoDienAdminThemSP : UserControl
    {
        public GiaoDienAdminThemSP()
        {
            InitializeComponent();
        }

        // Kiểm tra các trường nhập liệu có trống không
        public bool EmptyField()
        {
            return string.IsNullOrWhiteSpace(AdmPrd_NamePrd.Text) ||
                   string.IsNullOrWhiteSpace(AdmPrd_Price.Text) ||
                   string.IsNullOrWhiteSpace(AdmPrd_Stock.Text) ||
                   string.IsNullOrWhiteSpace(AdmPrd_Status.Text) ||
                   AdmPrd_Category.SelectedIndex == -1;
        }

        // Load dữ liệu vào DataGridView
        private void LoadDataGridView()
        {
            try
            {
                SanPhamDAO sanPhamDao = new SanPhamDAO();
                List<SanPhamDTO> danhSachSanPham = sanPhamDao.GetAllSanPham(); // Lấy tất cả sản phẩm từ cơ sở dữ liệu

                List<DanhMucDTO> danhSachDanhMuc = GetDanhMucList(); // Lấy tất cả danh mục

                // Kết hợp sản phẩm với tên danh mục
                var sanPhamWithCategory = danhSachSanPham.Select(sanPham =>
                {
                    var danhMuc = danhSachDanhMuc.FirstOrDefault(dm => dm.Id_danhMuc == sanPham.Id_DanhMuc);
                    return new
                    {
                        sanPham.Id_SanPham,
                        sanPham.TenSanPham,
                        TenDanhMuc = danhMuc?.TenDanhMuc ?? "Chưa xác định", // Nếu không có danh mục, hiển thị "Chưa xác định"
                        sanPham.GiaMua,
                        sanPham.SoLuongTon,
                        sanPham.TrangThai
                    };
                }).ToList();

                dgv_Prod.DataSource = sanPhamWithCategory;

                // Tùy chỉnh tiêu đề cột
                dgv_Prod.Columns["Id_SanPham"].HeaderText = "ID Sản Phẩm";
                dgv_Prod.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dgv_Prod.Columns["TenDanhMuc"].HeaderText = "Tên Danh Mục";
                dgv_Prod.Columns["GiaMua"].HeaderText = "Giá Mua";
                dgv_Prod.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
                dgv_Prod.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Lấy danh sách danh mục
        private List<DanhMucDTO> GetDanhMucList()
        {
            DanhMucDAO danhMucDao = new DanhMucDAO();
            return danhMucDao.GetAllDanhMuc(); // Lấy tất cả danh mục từ cơ sở dữ liệu
        }

        // Lấy danh mục vào ComboBox
        private void LoadDanhMucToComboBox()
        {
            try
            {
                DanhMucDAO danhMucDao = new DanhMucDAO();
                List<DanhMucDTO> danhMucList = danhMucDao.GetAllDanhMuc();

                AdmPrd_Category.DataSource = danhMucList;
                AdmPrd_Category.DisplayMember = "TenDanhMuc";  // Tên danh mục hiển thị
                AdmPrd_Category.ValueMember = "Id_danhMuc";   // Id danh mục làm giá trị
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message);
            }
        }

        // Xử lý khi nhấn nút Thêm Sản Phẩm
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu
                if (EmptyField())
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Lấy thông tin từ các TextBox và ComboBox
                int id_sanpham = Convert.ToInt32(AdmPrd_IdPrd.Text);
                string tenSanPham = AdmPrd_NamePrd.Text;
                float giaMua = Convert.ToSingle(AdmPrd_Price.Text); // Sửa lại để chuyển đổi thành float
                int soLuongTon = Convert.ToInt32(AdmPrd_Stock.Text);
                string trangThai = AdmPrd_Status.Text;


                // Kiểm tra danh mục đã chọn
                var selectedDanhMuc = AdmPrd_Category.SelectedItem as DanhMucDTO;
                if (selectedDanhMuc == null)
                {
                    MessageBox.Show("Danh mục không hợp lệ.");
                    return;
                }

                int idDanhMuc = selectedDanhMuc.Id_danhMuc;

                // Debug thông tin sản phẩm trước khi thêm
                MessageBox.Show($"Id Sản phẩm : {id_sanpham} , Tên sản phẩm: {tenSanPham}, Giá mua: {giaMua}, Số lượng tồn: {soLuongTon}, Trạng thái: {trangThai}, ID danh mục: {idDanhMuc}");

                // Tạo đối tượng SanPhamDTO
                SanPhamDTO sanPham = new SanPhamDTO(id_sanpham, tenSanPham, giaMua, soLuongTon, trangThai, idDanhMuc);

                // Thêm sản phẩm vào cơ sở dữ liệu
                SanPhamBUS sanPhambus = new SanPhamBUS();
                bool isSuccess = sanPhambus.AddSanPham(sanPham);

                if (isSuccess)
                {
                    MessageBox.Show("Sản phẩm đã được thêm thành công.");
                    LoadDataGridView(); // Tải lại danh sách sản phẩm
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }


        // Xử lý khi form được load
        private void GiaoDienAdminThemSP_Load(object sender, EventArgs e)
        {
            LoadDanhMucToComboBox(); 
            LoadDataGridView(); 
        }

        private void btnUpdateProd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                // Lấy thông tin từ các TextBox và ComboBox
                int id_sanpham = Convert.ToInt32(AdmPrd_IdPrd.Text);
                string tenSanPham = AdmPrd_NamePrd.Text;
                float giaMua = Convert.ToSingle(AdmPrd_Price.Text); // Sửa lại để chuyển đổi thành float
                int soLuongTon = Convert.ToInt32(AdmPrd_Stock.Text);
                string trangThai = AdmPrd_Status.Text;


                var selectedDanhMuc = AdmPrd_Category.SelectedItem as DanhMucDTO;
                if (selectedDanhMuc == null)
                {
                    MessageBox.Show("Danh mục không hợp lệ.");
                    return;
                }

                int idDanhMuc = selectedDanhMuc.Id_danhMuc;

                // Kiểm tra dữ liệu đầu vào
                if (id_sanpham <= 0 || string.IsNullOrEmpty(tenSanPham) || giaMua <= 0 || soLuongTon < 0)
                {
                    MessageBox.Show("Thông tin sản phẩm không hợp lệ!");
                    return;
                }

                // Tạo đối tượng SanPhamDTO
                SanPhamDTO sanPham = new SanPhamDTO(id_sanpham, tenSanPham, giaMua, soLuongTon, trangThai, idDanhMuc);

                SanPhamBUS sanPhambus = new SanPhamBUS();
                // Gọi phương thức UpdateSanPham từ BUS
                bool result = sanPhambus.UpdateSanPham(sanPham);

                if (result)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    LoadDataGridView();  
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }
        }

        private void dgv_Prod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_Prod.Rows[e.RowIndex];
            AdmPrd_IdPrd.Text = row.Cells["id_SanPham"].Value.ToString();
            AdmPrd_NamePrd.Text = row.Cells["TenSanPham"].Value.ToString();
            AdmPrd_Price.Text = row.Cells["giaMua"].Value.ToString();
            AdmPrd_Stock.Text = row.Cells["SoLuongTon"].Value.ToString();
            AdmPrd_Status.Text = row.Cells["TrangThai"].Value.ToString();
            AdmPrd_Category.Text = row.Cells["TenDanhMuc"].Value.ToString();
        }

        private void btnDeleteProd_Click(object sender, EventArgs e)
        {
            try
            {
                // Giả sử bạn có một TextBox để nhập ID sản phẩm cần xóa
                int idSanPham;
                if (int.TryParse(AdmPrd_IdPrd.Text, out idSanPham))
                {
                    // Kiểm tra xem ID sản phẩm có hợp lệ hay không
                    if (idSanPham <= 0)
                    {
                        MessageBox.Show("ID sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Xác nhận lại với người dùng trước khi xóa
                    var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm có ID {idSanPham}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    SanPhamBUS sanPhambus = new SanPhamBUS();
                    if (result == DialogResult.Yes)
                    {
                        bool isDeleted = sanPhambus.DeleteSanPham(idSanPham);

                        if (isDeleted)
                        {
                            MessageBox.Show("Xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Làm mới danh sách sản phẩm sau khi xóa
                            LoadDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm hoặc xóa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ID sản phẩm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearFields()
        {
            AdmPrd_IdPrd.Text = "";
            AdmPrd_NamePrd.Text = "";
            AdmPrd_Category.SelectedIndex = -1;
            AdmPrd_Stock.Text = "";
            AdmPrd_Price.Text = "";
            AdmPrd_Status.SelectedIndex = -1;
        }
        private void btnClearProd_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_Prod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
