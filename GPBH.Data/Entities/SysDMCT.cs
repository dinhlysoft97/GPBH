namespace GPBH.Data.Entities
{
    public class SysDMCT
    {
        // Mã cửa hàng
        public string Ma_cua_hang { get; set; }

        // Mã chứng từ
        public string Ma_chung_tu { get; set; }

        // Mã ngoại tệ
        public string Ma_nt { get; set; }

        // Số liên
        public int? So_lien { get; set; }

        // Store xử lý khi sau lưu
        public string Sp_xu_ly { get; set; }

        // Tên bảng PH
        public string Ph { get; set; }

        // Tên bảng CT
        public string Ct { get; set; }

        // Phần đầu số phiếu
        public string Dau_so { get; set; }

        // Độ rộng số phiếu tự tăng
        public int? So_phieu { get; set; }

        // Phần cuối số phiếu
        public string Cuoi_so { get; set; }

        // Cách đánh số (0: theo năm, 1: theo tháng)
        public string Cach_danh_so { get; set; }

        // Chuỗi các cột ở bảng PH đưa lên mẫu in
        public string PhFieldlist2IN { get; set; }

        // Chuỗi các cột ở bảng CT đưa lên mẫu in
        public string CtFieldlist2IN { get; set; }
    }
}
