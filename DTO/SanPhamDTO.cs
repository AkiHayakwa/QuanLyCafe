using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class SanPhamDTO
    {
        private int id_SanPham {  get; set; }
        private string TenSanPham { get; set; }
        
        private decimal giaMua {  get; set; }

        private int id_DanhMuc { get; set; }


        public SanPhamDTO() { }

        public SanPhamDTO(int id_SanPham, string TenSanPham, decimal giaMua, int id_DanhMuc)
        {
            this.id_SanPham = id_SanPham;
            this.TenSanPham = TenSanPham;
            this.giaMua = giaMua;
            this.id_DanhMuc = id_DanhMuc;
        }
    }
}
