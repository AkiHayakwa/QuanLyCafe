    using BUS;
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
    public partial class GiaoDienChuyenDoiBan : Form
    {
        private ChiTietHoaDonBus chiTietHoaDonBus = new ChiTietHoaDonBus();
        private HoaDonBus hoaDonBus = new HoaDonBus();
        private SanPhamBUS sanPhamBus = new SanPhamBUS();
        private BanCafeBus banCafebus = new BanCafeBus();
        public GiaoDienChuyenDoiBan()
        {
            InitializeComponent();
            InitializeDgvOrder1();
            InitializeDgvOrder2();
            LoadComboboxBanDaCoOrder();
            LoadComboboxBanChuaCoOrder();
        }

        private void GiaoDienChuyenDoiBan_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDgvOrder1()
        {
            if (dgv_Order1.Columns.Count == 0)
            {
                dgv_Order1.Columns.Add("IdSanPham", "ID Sản phẩm");
                dgv_Order1.Columns.Add("TenSanPham", "Tên Sản phẩm");
                dgv_Order1.Columns.Add("SoLuong", "Số lượng");
                dgv_Order1.Columns.Add("DonGia", "Đơn giá");
                dgv_Order1.Columns.Add("TongTien", "Tổng Tiền");
            }
        }

        private void InitializeDgvOrder2()
        {
            if (dgv_Order2.Columns.Count == 0)
            {
                dgv_Order2.Columns.Add("IdSanPham", "ID Sản phẩm");
                dgv_Order2.Columns.Add("TenSanPham", "Tên Sản phẩm");
                dgv_Order2.Columns.Add("SoLuong", "Số lượng");
                dgv_Order2.Columns.Add("DonGia", "Đơn giá");
                dgv_Order2.Columns.Add("TongTien", "Tổng Tiền");
            }
        }

        private void LoadComboboxBanDaCoOrder()
        {
            var hoaDonList = hoaDonBus.LayTatCaHoaDonCoChiTiet();
            foreach (var hoaDon in hoaDonList)
            {
                comboBoxTable.Items.Add($"Bàn {hoaDon.IdBan}");
            }
        }
        private void LoadComboboxBanChuaCoOrder()
        {
            {
                var danhSachBanChuaCoOrder = banCafebus.LayBanChuaCoHoaDon();
                foreach (var ban in danhSachBanChuaCoOrder)
                {
                    ComboBoxTable2.Items.Add($"Bàn {ban.Id_Ban}");
                }
            }
        }
        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTable.SelectedIndex >= 0)
            {
                var selectedTable = comboBoxTable.SelectedItem.ToString().Split(' ')[1];
                var hoaDon = hoaDonBus.LayHoaDonTheoBan(Convert.ToInt32(selectedTable));

                if (hoaDon != null)
                {
                    dgv_Order1.Rows.Clear();
                    textBoxInvoiceId.Text = hoaDon.IdHoaDon.ToString();
                    LoadChiTietHoaDon(hoaDon.IdHoaDon);
                }
                else
                {
                    textBoxInvoiceId.Text = string.Empty;
                    dgv_Order1.Rows.Clear();
                }
            }
        }

        private void LoadChiTietHoaDon(int id_HoaDon)
        {
            var chiTietHoaDonList = chiTietHoaDonBus.GetInvoiceDetails(id_HoaDon);
            dgv_Order1.Rows.Clear(); // Làm rỗng DataGridView trước khi thêm dữ liệu mới
            foreach (var chiTiet in chiTietHoaDonList)
            {
                string tenSanPham = sanPhamBus.LayTenSanPham(chiTiet.IdSanPham); // Lấy tên sản phẩm từ IdSanPham
                dgv_Order1.Rows.Add(chiTiet.IdSanPham, tenSanPham, chiTiet.SoLuong, chiTiet.GiaBan, chiTiet.TongTien);
            }
        }

        private void btnswitchright_Click(object sender, EventArgs e)
        {
            if (dgv_Order1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_Order1.SelectedRows[0];

                DataGridViewRow newRow = new DataGridViewRow(); 
                newRow.CreateCells(dgv_Order2);

                for (int i = 0; i < selectedRow.Cells.Count; i++) {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value; 
                }
                dgv_Order1.Rows.Remove(selectedRow);
                dgv_Order2.Rows.Add(newRow);

                int idHoaDon = int.Parse(textBoxInvoiceId.Text);
                var hoaDon = hoaDonBus.LayHoaDonTheoBan(idHoaDon);
                if (hoaDon != null)
                {
                    var selectedBanChuaCoOrder = ComboBoxTable2.SelectedItem.ToString().Split(' ')[1];
                    hoaDon.IdBan = Convert.ToInt32(selectedBanChuaCoOrder);
                    hoaDonBus.UpdateBanChoHoaDon(hoaDon);
                    MessageBox.Show("Chuyển bàn thành công!");
                    LoadComboboxBanDaCoOrder();
                    LoadComboboxBanChuaCoOrder();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng để chuyển!");
            }
        }
    }
}
