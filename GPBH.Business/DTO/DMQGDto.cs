using GPBH.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.DTO
{
    public class DMQGDto
    {
        public string Quoc_gia { get; set; } // Mã quốc gia 
        public bool Ksd { get; set; } // Sử dụng
        public virtual List<DMKH> DMKhs { get; set; } // Danh sách khách hàng liên kết
    }
}
