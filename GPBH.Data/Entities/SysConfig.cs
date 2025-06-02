namespace GPBH.Data.Entities
{
    public class SysConfig
    {
        // Hạn mức giao dịch tiền mặt
        public int Id { get; set; }

        public decimal Han_muc_giao_dich_tien_mat { get; set; }

        // Loại tiền áp dụng khi bán hàng
        public string Loai_tien_ap_dung_khi_ban_hang { get; set; }

        // Mã cơ quan thuế
        public string Ma_co_quan_thue { get; set; }
    }
}
