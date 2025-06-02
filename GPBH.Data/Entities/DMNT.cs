using GPBH.Data.Audit;
using System.Collections.Generic;

namespace GPBH.Data.Entities
{
    public class DMNT : BaseAuditableEntity
    {
        public string Ma_nt { get; set; }           // Mã ngoại tệ
        public bool Ksd { get; set; }               // Không sử dụng
        public virtual List<DMTG> DMTGs { get; set; } // Danh sách tỷ giá liên kết
        public virtual List<XPH5> XPH5s { get; set; } // Danh sách phiếu xuất hàng liên kết
    }
}
