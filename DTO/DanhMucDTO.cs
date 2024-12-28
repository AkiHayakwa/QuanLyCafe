using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class DanhMucDTO
    {
        public int Id_danhMuc {  get; set; }

        public string TenDanhMuc { get; set; }

        public DanhMucDTO() { }

        public DanhMucDTO(int Id_danhMuc, string TenDanhMuc)
        {
            this.Id_danhMuc= Id_danhMuc;
            this.TenDanhMuc = TenDanhMuc;
        }
    }
}
