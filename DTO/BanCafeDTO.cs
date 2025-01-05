using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BanCafeDTO
    {
        public int Id_Ban { get; set; }
        public string TenBan { get; set; }
        public string TrangThai { get; set; }

        public BanCafeDTO() { }

        public BanCafeDTO(int idBan, string tenBan, string trangThai)
        {
            Id_Ban = idBan;
            TenBan = tenBan;
            TrangThai = trangThai;
        }
    }
}
