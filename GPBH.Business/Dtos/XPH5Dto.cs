using GPBH.Data.Entities;
using System;
using System.Collections.Generic;

namespace GPBH.Business.Dtos
{
    public class XPH5Dto
    { // Mã cửa hàng
        public string Ma_cua_hang { get; set; }

        // Mã phiếu (PK)
        public string Ma_phieu { get; set; }

        // Mã chứng từ
        public string Ma_chung_tu { get; set; }

        // Số chứng từ
        public string So_chung_tu { get; set; }

        // Ngày lập chứng từ (mặc định ngày hiện tại)
        public DateTime Ngay_chung_tu { get; set; }

        // Mã ngoại tệ (mặc định = SysDMDV.ma_nt)
        public string Ma_nt { get; set; }

        // Tỷ giá (lấy từ danh mục tỷ giá theo ma_nt và ngày áp dụng gần nhất)
        public decimal? Ty_gia { get; set; }

        // Mã quầy
        public string Ma_quay { get; set; }

        // Mã cơ quan thuế (SysDMDV.ma_cqt)
        public string Ma_cqt { get; set; }

        // Đã xuất hóa đơn điện tử
        public bool Xuat_hddt { get; set; }

        // Số hóa đơn điện tử
        public string So_hddt { get; set; }

        // Đã xuất HQ
        public bool Xuat_hq { get; set; }

        // Mã kho
        public string Ma_kho { get; set; }

        // Passport
        public string Passport { get; set; }

        // Tên khách
        public string Ten_khach { get; set; }

        // Thanh toán 1, loại thanh toán
        public string Tt1_loai { get; set; }

        // Thanh toán 1, mã ngoại tệ
        public string Tt1_ma_nt { get; set; }

        // Thanh toán 1, tiền thanh toán
        public decimal? Tt1_tien_tt { get; set; }

        // Thanh toán 1, tỷ giá
        public decimal? Tt1_ty_gia { get; set; }

        // Thanh toán 1, tiền ngoại tệ
        public decimal? Tt1_tien_nt { get; set; }

        // Thanh toán 2, loại thanh toán
        public string Tt2_loai { get; set; }

        // Thanh toán 2, mã ngoại tệ
        public string Tt2_ma_nt { get; set; }

        // Thanh toán 2, tiền thanh toán
        public decimal? Tt2_tien_tt { get; set; }

        // Thanh toán 2, tỷ giá
        public decimal? Tt2_ty_gia { get; set; }

        // Thanh toán 2, tiền ngoại tệ
        public decimal? Tt2_tien_nt { get; set; }

        // Thanh toán 3, loại thanh toán
        public string Tt3_loai { get; set; }

        // Thanh toán 3, mã ngoại tệ
        public string Tt3_ma_nt { get; set; }

        // Thanh toán 3, tiền thanh toán
        public decimal? Tt3_tien_tt { get; set; }

        // Thanh toán 3, tỷ giá
        public decimal? Tt3_ty_gia { get; set; }

        // Thanh toán 3, tiền ngoại tệ
        public decimal? Tt3_tien_nt { get; set; }

        // Tổng thanh toán
        public decimal? Tt_tong { get; set; }

        // Tổng nhận
        public decimal? Tong_nhan { get; set; }

        // mã cb Trả lại
        public string Ma_tra_lai { get; set; }

        // Trả lại = Tổng thu - Tổng nhận
        public decimal? Tra_lai { get; set; }

        // Trả lại * tỷ giá
        public decimal? Tra_lai_nt { get; set; }

        // Tổng tiền hàng
        public decimal? Tong_tien_hang { get; set; }

        // Tổng tiền hàng ngoại tệ
        public decimal? Tong_tien_hang_nt { get; set; }

        // Tổng giảm giá
        public decimal? Tong_giam_gia { get; set; }

        // Tổng giảm giá ngoại tệ
        public decimal? Tong_giam_gia_nt { get; set; }

        // Tổng tiền thu
        public decimal? Tong_thu { get; set; }

        // Tổng quy đổi
        public decimal? Tong_thu_nt { get; set; }

        // Tổng số lượng
        public decimal? Tong_so_luong { get; set; }

        // Ngày cấp (xuất nhập cảnh)
        public DateTime? Xnc_ngay_cap { get; set; }

        // Ngày hết hạn (xuất nhập cảnh)
        public DateTime? Xnc_ngay_hh { get; set; }

        // Số hiệu
        public string So_hieu { get; set; }

        // Tên tàu bay
        public string Ten_tau_bay { get; set; }

        // Hạn mức
        public decimal? Han_muc { get; set; }

        // Mã nhóm khách hàng (sysdmdv)
        public string Ma_nhom_kh { get; set; }

        // Mã loại hình (sysdmdv)
        public string Ma_loai_hinh { get; set; }

        // Mã đối tượng (sysdmdv)
        public string Ma_doi_tuong { get; set; }

        // Mã đối tượng (sysdmdv)
        public TrangThaiDonHang Trang_thai { get; set; }

        public string Nguoi_tao { get; set; }        // Người tạo
        public DateTime? Ngay_tao { get; set; }      // Ngày tạo
        public string Nguoi_sua { get; set; }        // Người sửa
        public DateTime? Ngay_sua { get; set; }      // Ngày sửa

        public List<XCT5Dto> XCT5s { get; set; } = new List<XCT5Dto>();
    }
}
