using System.Collections.Generic;

namespace GPBH.Data.Entities
{
    public class SysDMCuaHang
    {
        public string Ma_dv { get; set; }             // Mã đơn vị
        public string Ma_cua_hang { get; set; }       // Mã cửa hàng
        public string Ten_cua_hang { get; set; }      // Tên cửa hàng
        public string Dia_chi { get; set; }           // Địa chỉ
        public string Ma_nhom_kh { get; set; }        // Mã nhóm khách hàng
        public string Ma_loai_hinh { get; set; }      // Mã loại hình
        public string Ma_doi_tuong { get; set; }      // Mã đối tượng
        public string Ma_nt { get; set; }             // Mã ngoại tệ
        public decimal Han_muc_tm { get; set; }       // Hạn mức tiền mặt
        public string Ma_cqt { get; set; }            // Mã CQT
        public bool Nhap_ttxnc { get; set; }          // Bắt buộc nhập thông tin xuất nhập cảnh

        public SysDMDV SysDMDV { get; set; }          // Thông tin đơn vị liên kết
        public virtual List<DMGB> DMGBs { get; set; } // Danh sách nhóm giá bán liên kết
        public virtual List<XPH5> XPH5s { get; set; } // Danh sách phiếu xuất hàng liên kết
        public virtual List<TokhaiHH> TokhaiHHs { get; set; } // Danh sách tờ khai hải quan liên kết
    }
}
