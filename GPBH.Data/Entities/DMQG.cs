using System.Collections.Generic;

namespace GPBH.Data.Entities
{
    public class DMQG
    {
        public string Quoc_gia { get; set; } // Mã quốc gia 
        public bool Ksd { get; set; } // Sử dụng
        public virtual List<DMKH> DMKhs { get; set; } // Danh sách khách hàng liên kết
    }
}
