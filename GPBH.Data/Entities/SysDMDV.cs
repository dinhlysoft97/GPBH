using System.Collections.Generic;

namespace GPBH.Data.Entities
{
    public class SysDMDV
    {
        public string Ma_dv { get; set; }                // Mã đơn vị
        public string Ten_dv { get; set; }               // Tên đơn vị
        public string Dia_chi { get; set; }              // Địa chỉ
        public string Ma_so_thue { get; set; }           // Mã số thuế
        public string Ma_hqcq { get; set; }              // Mã HQ chủ quản
        public string So_dien_thoai { get; set; }        // Số điện thoại
        public string So_fax { get; set; }               // Số fax
        public string Email { get; set; }                // Email
        public string Nlh_ho_ten { get; set; }           // Họ tên người liên hệ
        public string Nlh_chuc_vu { get; set; }          // Chức vụ người liên hệ
        public string Nlh_Sdt { get; set; }              // Số điện thoại người liên hệ

        public virtual List<SysDMCuaHang> SysDMCuaHangs { get; set; } // Danh sách cửa hàng liên kết
    }
}
