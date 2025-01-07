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
        private Dictionary<int, List<ChiTietHoaDonDTO>> ordersByTable = new Dictionary<int,List<ChiTietHoaDonDTO>>();
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
                string tenDanhMuc = CashierCategory.SelectedItem?.ToString().Trim();
                if (!string.IsNullOrEmpty(tenDanhMuc))
                {
                    // Lấy idDanhMuc từ tên danh mục
                    DanhMucBUS danhmucbus = new DanhMucBUS();
                    List<DanhMucDTO> danhMucList = danhmucbus.GetAllDanhMuc();

                    // In ra danh sách danh mục để kiểm tra
                    foreach (var dm in danhMucList)
                    {
                        Console.WriteLine($"ID: {dm.Id_danhMuc}, Tên: {dm.TenDanhMuc}");
                    }

                    int idDanhMuc = danhMucList.FirstOrDefault(d => d.TenDanhMuc.Trim() == tenDanhMuc)?.Id_danhMuc ?? 0;

                    if (idDanhMuc > 0)
                    {
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
        private SanPhamBUS productBUS = new SanPhamBUS();
        private void LoadProducts() {
            List<SanPhamDTO> products = productBUS.GetAllSanPham();
            dgv_Prd.DataSource = products;
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

        ChiTietHoaDonBus cthdbus = new ChiTietHoaDonBus();
        private void dgv_Prd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedTableId == -1) { MessageBox.Show("Hãy chọn một bàn trước khi chọn sản phẩm.", "Lỗi"); return; }
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_Prd.Rows[e.RowIndex]; 
                    var product = (SanPhamDTO)selectedRow.DataBoundItem; 
                    if (product.SoLuongTon > 0)
                    {
                        bool productExists = false;
                        foreach (DataGridViewRow row in dgv_Order.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["IdSanPham"].Value) == product.Id_SanPham)
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                                row.Cells["SoLuong"].Value = currentQuantity + 1;
                                row.Cells["TongTien"].Value = (currentQuantity + 1) * product.GiaMua;

                                var chiTietHoaDon = new ChiTietHoaDonDTO
                                {
                                    IdHoaDon = Convert.ToInt32(CashierInvoiceId.Text),
                                    IdSanPham = product.Id_SanPham,
                                    SoLuong = currentQuantity + 1,
                                    GiaBan = product.GiaMua,
                                    TongTien = (currentQuantity + 1) * product.GiaMua
                                };

                                cthdbus.UpdateInvoiceDetail(chiTietHoaDon.IdHoaDon , chiTietHoaDon.IdSanPham, chiTietHoaDon.SoLuong, chiTietHoaDon.GiaBan);
                                productExists = true;
                                break;
                            }
                        }
                        if (!productExists)
                        {
                            dgv_Order.Rows.Add(product.Id_SanPham, product.TenSanPham, 1, product.GiaMua, product.GiaMua);
                            var chiTietHoaDon = new ChiTietHoaDonDTO
                            {
                                IdHoaDon = Convert.ToInt32(CashierInvoiceId.Text),
                                IdSanPham = product.Id_SanPham,
                                SoLuong = 1,
                                GiaBan = product.GiaMua,
                                TongTien = product.GiaMua
                            };
                            cthdbus.AddInvoiceDetail(chiTietHoaDon);
                        }
                        productBUS.GiamSoLuongTon(product.Id_SanPham, 1);
                        selectedRow.Cells["SoLuongTon"].Value = product.SoLuongTon - 1;
                        CalculateAndDisplayTotalPrice();
                        if (selectedTableButton != null)
                        {
                            selectedTableButton.BackColor = Color.Green;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm này không còn đủ số lượng.", "Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm vào giỏ hàng: " + ex.Message, "Lỗi");
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
        SanPhamBUS sanphambus = new SanPhamBUS();
        private void LoadSanPhamByDanhMuc(int idDanhMuc)
        {
            try
            {
                
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
                    dgv_Prd.Columns["SoLuongTon"].HeaderText = "Số Lượng còn lại";
                    dgv_Prd.Columns["TrangThai"].HeaderText = "Trạng Thái";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        BanCafeBus bancafebus = new BanCafeBus();
        private Button selectedTableButton = null;
        private int selectedTableId = -1;


        private void CalculateAndDisplayTotalPrice()
        {
            float totalPrice = 0;
            foreach (DataGridViewRow row in dgv_Order.Rows)
            {
                if (row.Cells["TongTien"] != null && row.Cells["TongTien"].Value != null)
                {
                    totalPrice += Convert.ToSingle(row.Cells["TongTien"].Value);
                }
            }
            CashierInvoice.Text = totalPrice.ToString("N2"); 

            if (int.TryParse(CashierInvoiceId.Text, out int invoiceId))
            {
                UpdateInvoiceTotalPrice(invoiceId, totalPrice);
            }
        }

        private void UpdateInvoiceTotalPrice(int invoiceId, float totalPrice)
        {
            hoaDonBus.UpdateTotalAmount(invoiceId, totalPrice);
        }

        private bool isHandlingClick = false;

        private int currentInvoiceId = -1; // Biến lưu trữ ID hóa đơn hiện tại
        private float currentInvoiceTotal = 0; // Biến lưu trữ tổng tiền hiện tại của hóa đơn

        private void Button_Click(object sender, EventArgs e)
        {
            if (isHandlingClick) return;
            isHandlingClick = true;

            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                int tableId;
                if (clickedButton.Tag != null && int.TryParse(clickedButton.Tag.ToString(), out tableId))
                {
                    // Lưu trữ dữ liệu order hiện tại của bàn trước đó (nếu có)
                    if (selectedTableId != -1 && selectedTableId != tableId)
                    {
                        SaveCurrentOrder(selectedTableId);
                    }

                    // Kiểm tra và thay đổi màu sắc
                    if (selectedTableButton != null && selectedTableId != tableId)
                    {
                        selectedTableButton.BackColor = ordersByTable.ContainsKey(selectedTableId) && ordersByTable[selectedTableId].Count > 0 ? Color.Green : SystemColors.Control;
                    }

                    if (selectedTableId != tableId)
                    {
                        clickedButton.BackColor = Color.Red;
                        selectedTableButton = clickedButton;
                        selectedTableId = tableId;

                        CashierTableNumber.Text = clickedButton.Text;

                        // Xóa sạch dữ liệu trong dgv_Order và tải dữ liệu order của bàn mới (nếu có)
                        dgv_Order.Rows.Clear();
                        LoadOrderForTable(selectedTableId);

                        // Kiểm tra xem có hóa đơn nào với tổng tiền = 0 không
                        if (currentInvoiceId != -1 && currentInvoiceTotal == 0)
                        {
                            CashierInvoiceId.Text = currentInvoiceId.ToString();
                        }
                        else
                        {
                            // Kiểm tra hóa đơn hiện có của bàn
                            var hoaDon = hoaDonBus.LayHoaDonTheoBan(selectedTableId);
                            if (hoaDon != null && hoaDon.TongTien > 0)
                            {
                                // Nếu hóa đơn có tổng tiền > 0, sử dụng hóa đơn hiện tại
                                currentInvoiceId = hoaDon.IdHoaDon;
                                currentInvoiceTotal = hoaDon.TongTien;
                            }
                            else if (hoaDon == null || hoaDon.TongTien == 0)
                            {
                                // Tạo mới hóa đơn nếu không có hóa đơn nào hoặc tổng tiền = 0
                                hoaDon = new HoaDonDTO
                                {
                                    IdBan = selectedTableId,
                                    Ngay = DateTime.Now,
                                    TongTien = 0,
                                    GiamGia = 0
                                };
                                currentInvoiceId = hoaDonBus.CreateInvoice(hoaDon);
                                currentInvoiceTotal = 0; // Tổng tiền hóa đơn mới là 0
                            }

                            CashierInvoiceId.Text = currentInvoiceId.ToString();
                        }

                        CalculateAndDisplayTotalPrice();
                        MessageBox.Show("Bạn đã chọn Bàn " + selectedTableId, "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: Giá trị của Tag không hợp lệ hoặc null.", "Lỗi");
                }
            }

            isHandlingClick = false;
        }

        private void Cashierbtnpayment_Click(object sender, EventArgs e)
        {
            int maHoaDon = int.Parse(CashierInvoiceId.Text);
            float tongTien = float.Parse(CashierInvoice.Text);
            GiaoDienThanhToan thanhToan = new GiaoDienThanhToan(maHoaDon , tongTien);
            thanhToan.ShowDialog();
        }

        private void dgv_Order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_Order.Rows[e.RowIndex];
                    int idSanPham = Convert.ToInt32(selectedRow.Cells["IdSanPham"].Value);
                    int currentQuantity = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);
                    decimal price = Convert.ToDecimal(selectedRow.Cells["DonGia"].Value);
                    if (currentQuantity > 1)
                    {
                        selectedRow.Cells["SoLuong"].Value = currentQuantity - 1;
                        selectedRow.Cells["TongTien"].Value = (currentQuantity - 1) * price;
                    }
                    else
                    {
                        dgv_Order.Rows.RemoveAt(e.RowIndex);
                    }
                    sanphambus.GiamSoLuongTon(idSanPham, -1);
                    foreach (DataGridViewRow row in dgv_Prd.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["id_SanPham"].Value) == idSanPham)
                        {
                           int soLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                           if(soLuongTon > 0)
                           {
                                row.Cells["SoLuongTon"].Value = soLuongTon + 1;
                           }
                           if(soLuongTon - 1 == 0)
                            {
                                sanphambus.DeleteSanPham(idSanPham);
                                dgv_Prd.Rows.RemoveAt(row.Index);
                            }
                            break;
                        }
                    }
                    CalculateAndDisplayTotalPrice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật giỏ hàng: " + ex.Message, "Lỗi");
                }
            }
        }
        private void SaveCurrentOrder(int tableId)
        {
            var currentOrders = new List<ChiTietHoaDonDTO>();
            foreach (DataGridViewRow row in dgv_Order.Rows) {
                if (row.Cells["IdSanPham"].Value != null)
                {
                    currentOrders.Add(new ChiTietHoaDonDTO
                    {
                        IdHoaDon = selectedHoaDonId,
                        IdSanPham = Convert.ToInt32(row.Cells["IdSanPham"].Value),
                        SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        GiaBan = Convert.ToSingle(row.Cells["DonGia"].Value)
                    });
                }
            }
            if (ordersByTable.ContainsKey(tableId))
            {
                ordersByTable[tableId] = currentOrders;
            }
            else
            {
                ordersByTable.Add(tableId, currentOrders);
            }
        }
        HoaDonBus hoaDonBus = new HoaDonBus();
        private void LoadOrderForTable(int tableId)
        {
            if (ordersByTable.ContainsKey(tableId))
            {
                var currentOrders = ordersByTable[tableId];
                foreach(var chitiet in currentOrders)
                {
                    string tenSanPham = sanphambus.LayTenSanPham(chitiet.IdSanPham);
                    dgv_Order.Rows.Add(chitiet.IdSanPham, tenSanPham, chitiet.SoLuong, chitiet.GiaBan, chitiet.SoLuong * chitiet.GiaBan);
                }
            }
        }
        private int selectedHoaDonId = -1;
            private void dgv_Order_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void chuyểnĐổiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiaoDienChuyenDoiBan formChuyenDoiBan = new GiaoDienChuyenDoiBan();
            formChuyenDoiBan.Show();
        }

        private void CasherSearchPrd_Click(object sender, EventArgs e)
        {
            string tenSanPham = CashierNamePrd.Text.Trim(); 
            if (!string.IsNullOrEmpty(tenSanPham)) {
                List<SanPhamDTO> products = productBUS.GetAllSanPham(); 
                var filteredProducts = products.Where(p => p.TenSanPham.Contains(tenSanPham)).ToList();
                if (filteredProducts.Count > 0) { 
                    dgv_Prd.DataSource = filteredProducts; 
                } else { 
                    MessageBox.Show("Không tìm thấy sản phẩm nào.", "Thông báo");
                    dgv_Prd.DataSource = null;
                } 
            } else {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thông báo"); 
            }
        }

     } 
 }
