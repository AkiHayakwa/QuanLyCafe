using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private int id_NhanVien;
        private string tenNhanVien;
        private string soDienThoai;
        private string email;

        public int Id_NhanVien
        {
            get { return id_NhanVien; }
            set { id_NhanVien = value; }
        }

        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set { tenNhanVien = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public NhanVienDTO() { }

        public NhanVienDTO(int id_NhanVien, string tenNhanVien, string soDienThoai, string email)
        {
            this.id_NhanVien = id_NhanVien;
            this.tenNhanVien = tenNhanVien;
            this.soDienThoai = soDienThoai;
            this.email = email;
        }
    }
}
