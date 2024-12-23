using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class BanCafeDTO
    {
        public int IdBan { get; set; }
        public string TenBan { get; set; }
        public string TrangThai { get; set; }

        public BanCafeDTO() { }

        public BanCafeDTO(int idBan, string tenBan, string trangThai)
        {
            IdBan = idBan;
            TenBan = tenBan;
            TrangThai = trangThai;
        }
    }
}
