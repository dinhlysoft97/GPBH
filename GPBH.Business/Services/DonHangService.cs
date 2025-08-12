using GPBH.Business.Dtos;
using GPBH.Business.Exceptions;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.Business.Services
{
    public class DonHangService
    {
        private readonly IServiceProvider _serviceProvider;

        public DonHangService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Tìm kiếm đơn hàng theo khoảng thời gian
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public List<GirdDonHangDto> TiemKiem(DateTime tuNgay, DateTime denNgay, string maCH)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<XPH5>()
                    .Find(x => x.Ngay_chung_tu >= tuNgay && x.Ngay_chung_tu <= denNgay && x.Ma_cua_hang == maCH)
                    .OrderByDescending(z => z.Ngay_chung_tu)
                    .OrderByDescending(z => z.So_chung_tu)
                    .Select(x => x.Adapt<GirdDonHangDto>())
                    .ToList();
            }
        }

        /// <summary>
        /// Lấy chi tiết đơn hàng theo mã phiếu
        /// </summary>
        /// <param name="ma_phieu"></param>
        /// <returns></returns>
        public List<GirdDonHangChiTietDto> GetDonHangChiTiet(string ma_phieu)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<XCT5>()
                    .Find(x => x.Ma_phieu == ma_phieu)
                    .Select(x => x.Adapt<GirdDonHangChiTietDto>())
                    .ToList();
            }
        }

        /// <summary>
        /// Lấy đơn hàng theo mã phiếu
        /// </summary>
        /// <param name="maPhieu"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public XPH5Dto GetDonHang(string maPhieu)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var entity = unitOfWork.Repository<XPH5>()
                    .Find(x => x.Ma_phieu == maPhieu)
                    .FirstOrDefault();
                if (entity == null)
                    throw new BadRequestException($"Không tìm thấy đơn hàng với mã phiếu: {maPhieu}");
                return entity.Adapt<XPH5Dto>();
            }
        }

        /// <summary>
        /// Tạo đơn hàng mới từ DTO, sinh số chứng từ và mã phiếu tự động
        /// </summary>
        /// <param name="donhang"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public (XPH5Dto, bool) TaoDonHang(XPH5Dto donhang)
        {
            XPH5 entity;
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                try
                {
                    unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
                    donhang.Ma_phieu = GenerateMaPhieu(unitOfWork, donhang.Ma_cua_hang, donhang.Ma_chung_tu);
                    entity = donhang.Adapt<XPH5>();
                    foreach (var item in entity.XCT5s)
                    {
                        item.So_to_khai = string.Empty;
                    }

                    if (donhang.Trang_thai == TrangThaiDonHang.Confirmed)
                    {
                        var soPhieuGenerator = scope.ServiceProvider.GetRequiredService<SoPhieuGeneratorService>();
                        string soChungTuMoi;
                        bool daTonTai;
                        int soLanLap = 0;
                        do
                        {
                            soChungTuMoi = soPhieuGenerator.GenerateSoPhieu(donhang.Ma_cua_hang, donhang.Ma_chung_tu, donhang.Ngay_chung_tu);
                            // Kiểm tra đã tồn tại chưa
                            daTonTai = unitOfWork.Repository<XPH5>()
                                .Any(x => x.Ma_cua_hang == donhang.Ma_cua_hang
                                       && x.Ma_chung_tu == donhang.Ma_chung_tu
                                       && x.So_chung_tu == soChungTuMoi);
                            soLanLap++;
                            if (soLanLap > 10)
                                throw new BadRequestException("Không thể tạo số chứng từ không trùng sau nhiều lần thử!");
                        }
                        while (daTonTai);

                        entity.So_chung_tu = soChungTuMoi;
                        TinhTonKho(unitOfWork, entity);
                    }

                    // Lưu đơn hàng
                    unitOfWork.Repository<XPH5>().Add(entity);
                    unitOfWork.SaveChanges();
                    unitOfWork.Commit();

                    return (entity.Adapt<XPH5Dto>(), true);
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw new BadRequestException("Lỗi khi tạo đơn hàng: " + ex.Message);
                }
            }
        }

        public (XPH5Dto, bool) UpdateSoChungTuTinhTonKho(XPH5Dto donhang)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                try
                {
                    unitOfWork.BeginTransaction();

                    var entityCu = unitOfWork.Repository<XPH5>()
                        .Find(x => x.Ma_phieu == donhang.Ma_phieu)
                        .FirstOrDefault() ?? throw new BadRequestException("Không tìm thấy đơn hàng để cập nhật!");

                    // Clone entity cũ để giữ dữ liệu chi tiết trước update (nên dùng phương thức clone sâu, hoặc map sang DTO rồi lại sang entity)
                    var entityCuClone = CloneXPH5(entityCu);

                    // Update đơn hàng
                    UpdatDonHang(entityCu, donhang);

                    // Update chi tiết
                    UpdateChiTietDonHang(entityCu, donhang);

                    if (entityCuClone.Trang_thai == TrangThaiDonHang.Draft && donhang.Trang_thai == TrangThaiDonHang.Confirmed)
                    {
                        var soPhieuGenerator = scope.ServiceProvider.GetRequiredService<SoPhieuGeneratorService>();
                        string soChungTuMoi;
                        bool daTonTai;
                        int soLanLap = 0;
                        do
                        {
                            soChungTuMoi = soPhieuGenerator.GenerateSoPhieu(donhang.Ma_cua_hang, donhang.Ma_chung_tu, donhang.Ngay_chung_tu);
                            // Kiểm tra đã tồn tại chưa
                            daTonTai = unitOfWork.Repository<XPH5>()
                                .Any(x => x.Ma_cua_hang == donhang.Ma_cua_hang
                                       && x.Ma_chung_tu == donhang.Ma_chung_tu
                                       && x.So_chung_tu == soChungTuMoi);
                            soLanLap++;
                            if (soLanLap > 10)
                                throw new BadRequestException("Không thể tạo số chứng từ không trùng sau nhiều lần thử!");
                        }
                        while (daTonTai);

                        entityCu.So_chung_tu = soChungTuMoi;
                        entityCu.Trang_thai = TrangThaiDonHang.Confirmed;
                        TinhTonKho(unitOfWork, entityCu);
                    }
                    else if (donhang.Trang_thai == TrangThaiDonHang.Confirmed)
                    {

                        // **Gọi hàm cập nhật lại tồn kho khi update**
                        // entityCu: đơn hàng đã được update theo dữ liệu mới
                        // entityCuClone: đơn hàng cũ trước khi update
                        UpsertXuatKho(unitOfWork, entityCu, entityCuClone);
                    }

                    // Update đơn hàng
                    unitOfWork.Repository<XPH5>().Update(entityCu);
                    unitOfWork.SaveChanges();
                    unitOfWork.Commit();

                    return (entityCu.Adapt<XPH5Dto>(), true);
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw new BadRequestException("Lỗi khi tạo đơn hàng: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin đơn hàng từ DTO vào entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="donhang"></param>
        private void UpdatDonHang(XPH5 entity, XPH5Dto donhang)
        {
            entity.Ma_cua_hang = donhang.Ma_cua_hang;
            entity.Ma_phieu = donhang.Ma_phieu;
            entity.Ma_chung_tu = donhang.Ma_chung_tu;
            //entity.So_chung_tu = donhang.So_chung_tu;
            //entity.Ngay_chung_tu = donhang.Ngay_chung_tu;
            entity.Ma_nt = donhang.Ma_nt;
            entity.Ty_gia = donhang.Ty_gia;
            entity.Ma_quay = donhang.Ma_quay;
            entity.Ma_cqt = donhang.Ma_cqt;
            entity.Xuat_hddt = donhang.Xuat_hddt;
            entity.So_hddt = donhang.So_hddt;
            entity.Xuat_hq = donhang.Xuat_hq;
            entity.Ma_kho = donhang.Ma_kho;
            entity.Passport = donhang.Passport;
            entity.Ten_khach = donhang.Ten_khach;
            entity.Tt1_loai = donhang.Tt1_loai;
            entity.Tt1_ma_nt = donhang.Tt1_ma_nt;
            entity.Tt1_tien_tt = donhang.Tt1_tien_tt;
            entity.Tt1_tien_nt = donhang.Tt1_tien_nt;
            entity.Tt2_loai = donhang.Tt2_loai;
            entity.Tt2_ma_nt = donhang.Tt2_ma_nt;
            entity.Tt2_tien_tt = donhang.Tt2_tien_tt;
            entity.Tt2_tien_nt = donhang.Tt2_tien_nt;
            entity.Tt3_loai = donhang.Tt3_loai;
            entity.Tt3_ma_nt = donhang.Tt3_ma_nt;
            entity.Tt3_tien_tt = donhang.Tt3_tien_tt;
            entity.Tt3_tien_nt = donhang.Tt3_tien_nt;
            entity.Tt_tong = donhang.Tt_tong;
            entity.Tong_nhan = donhang.Tong_nhan;
            entity.Tra_lai = donhang.Tra_lai;
            entity.Ma_tra_lai = donhang.Ma_tra_lai;
            entity.Tra_lai_nt = donhang.Tra_lai_nt;
            entity.Tong_tien_hang = donhang.Tong_tien_hang;
            entity.Tong_tien_hang_nt = donhang.Tong_tien_hang_nt;
            entity.Tong_giam_gia = donhang.Tong_giam_gia;
            entity.Tong_giam_gia_nt = donhang.Tong_giam_gia_nt;
            entity.Tong_thu = donhang.Tong_thu;
            entity.Tong_thu_nt = donhang.Tong_thu_nt;
            entity.Tong_so_luong = donhang.Tong_so_luong;
            entity.Xnc_ngay_cap = donhang.Xnc_ngay_cap;
            entity.Xnc_ngay_hh = donhang.Xnc_ngay_hh;
            entity.So_hieu = donhang.So_hieu;
            entity.Ten_tau_bay = donhang.Ten_tau_bay;
            entity.Han_muc = donhang.Han_muc;
            entity.Ma_nhom_kh = donhang.Ma_nhom_kh;
            entity.Ma_loai_hinh = donhang.Ma_loai_hinh;
            entity.Ma_doi_tuong = donhang.Ma_doi_tuong;
        }

        /// <summary>
        /// Sao chép một đối tượng XPH5 để tạo đơn hàng mới
        /// </summary>
        /// <param name="entityCu"></param>
        /// <returns></returns>
        public static XPH5 CloneXPH5(XPH5 entityCu)
        {
            if (entityCu == null) return null;

            var clone = new XPH5
            {
                Ma_cua_hang = entityCu.Ma_cua_hang,
                Ma_phieu = entityCu.Ma_phieu,
                Ma_chung_tu = entityCu.Ma_chung_tu,
                So_chung_tu = entityCu.So_chung_tu,
                Ngay_chung_tu = entityCu.Ngay_chung_tu,
                Ma_nt = entityCu.Ma_nt,
                Ty_gia = entityCu.Ty_gia,
                Ma_quay = entityCu.Ma_quay,
                Ma_cqt = entityCu.Ma_cqt,
                Xuat_hddt = entityCu.Xuat_hddt,
                So_hddt = entityCu.So_hddt,
                Xuat_hq = entityCu.Xuat_hq,
                Ma_kho = entityCu.Ma_kho,
                Passport = entityCu.Passport,
                Ten_khach = entityCu.Ten_khach,
                Tt1_loai = entityCu.Tt1_loai,
                Tt1_ma_nt = entityCu.Tt1_ma_nt,
                Tt1_tien_tt = entityCu.Tt1_tien_tt,
                Tt1_tien_nt = entityCu.Tt1_tien_nt,
                Tt2_loai = entityCu.Tt2_loai,
                Tt2_ma_nt = entityCu.Tt2_ma_nt,
                Tt2_tien_tt = entityCu.Tt2_tien_tt,
                Tt2_tien_nt = entityCu.Tt2_tien_nt,
                Tt3_loai = entityCu.Tt3_loai,
                Tt3_ma_nt = entityCu.Tt3_ma_nt,
                Tt3_tien_tt = entityCu.Tt3_tien_tt,
                Tt3_tien_nt = entityCu.Tt3_tien_nt,
                Tt_tong = entityCu.Tt_tong,
                Tong_nhan = entityCu.Tong_nhan,
                Tra_lai = entityCu.Tra_lai,
                Ma_tra_lai = entityCu.Ma_tra_lai,
                Tra_lai_nt = entityCu.Tra_lai_nt,
                Tong_tien_hang = entityCu.Tong_tien_hang,
                Tong_tien_hang_nt = entityCu.Tong_tien_hang_nt,
                Tong_giam_gia = entityCu.Tong_giam_gia,
                Tong_giam_gia_nt = entityCu.Tong_giam_gia_nt,
                Tong_thu = entityCu.Tong_thu,
                Tong_thu_nt = entityCu.Tong_thu_nt,
                Tong_so_luong = entityCu.Tong_so_luong,
                Xnc_ngay_cap = entityCu.Xnc_ngay_cap,
                Xnc_ngay_hh = entityCu.Xnc_ngay_hh,
                So_hieu = entityCu.So_hieu,
                Ten_tau_bay = entityCu.Ten_tau_bay,
                Han_muc = entityCu.Han_muc,
                Ma_nhom_kh = entityCu.Ma_nhom_kh,
                Ma_loai_hinh = entityCu.Ma_loai_hinh,
                Ma_doi_tuong = entityCu.Ma_doi_tuong,
                Trang_thai = entityCu.Trang_thai,
                // Không map các property kiểu navigation, virtual (SysDMCuaHang, DMNT, ...)
                XCT5s = entityCu.XCT5s?.Select(x => new XCT5
                {
                    Ma_phieu = x.Ma_phieu,
                    Stt = x.Stt,
                    Ma_hh = x.Ma_hh,
                    Ten_hh = x.Ten_hh,
                    Dvt = x.Dvt,
                    So_luong = x.So_luong,
                    Gia_ban = x.Gia_ban,
                    Gia_ban_nt = x.Gia_ban_nt,
                    Gg_ty_le = x.Gg_ty_le,
                    Gg_tien = x.Gg_tien,
                    Gg_tien_nt = x.Gg_tien_nt,
                    Tien_ban = x.Tien_ban,
                    Tien_ban_nt = x.Tien_ban_nt,
                    Gg_ly_do = x.Gg_ly_do,
                    So_to_khai = x.So_to_khai,
                    // Không map XPH5, DMHH
                }).ToList()
            };

            return clone;
        }

        /// <summary>
        /// Sinh mã phiếu mới theo định dạng: ma_dv + ma_chung_tu + 12 số tăng dần
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="ma_dv"></param>
        /// <param name="ma_chung_tu"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string GenerateMaPhieu(IUnitOfWork unitOfWork, string ma_dv, string ma_chung_tu)
        {
            int soLanLap = 0;
            string maPhieuMoi;
            bool daTonTai;

            long nextNumber = 1;

            // Lấy mã lớn nhất hiện có
            var last = unitOfWork.Repository<XPH5>()
                .Find(x => x.Ma_cua_hang == ma_dv && x.Ma_chung_tu == ma_chung_tu)
                .OrderByDescending(x => x.Ma_phieu)
                .Select(x => x.Ma_phieu)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(last) && last.Length >= (ma_dv.Length + ma_chung_tu.Length + 12))
            {
                string soCuoi = last.Substring(ma_dv.Length + ma_chung_tu.Length, 12);
                if (long.TryParse(soCuoi, out long lastNum))
                {
                    nextNumber = lastNum + 1;
                }
            }

            do
            {
                string soTangDan = nextNumber.ToString().PadLeft(12, '0');
                maPhieuMoi = $"{ma_dv}{ma_chung_tu}{soTangDan}";

                // Kiểm tra đã tồn tại trong db chưa
                daTonTai = unitOfWork.Repository<XPH5>()
                    .Any(x => x.Ma_cua_hang == ma_dv
                           && x.Ma_chung_tu == ma_chung_tu
                           && x.Ma_phieu == maPhieuMoi);

                nextNumber++;
                soLanLap++;

                if (soLanLap > 10)
                    throw new BadRequestException("Không thể tạo mã phiếu không trùng sau nhiều lần thử!");
            }
            while (daTonTai);

            return maPhieuMoi;
        }

        /// <summary>
        /// Cập nhật chi tiết đơn hàng
        /// </summary>
        /// <param name="entity"></param>
        public static void UpdateChiTietDonHang(XPH5 entity, XPH5Dto dto)
        {
            // 1. Thêm các dòng mới (trong dto nhưng chưa có trong entity)
            var addDtos = dto.XCT5s
                .Where(d => d.Stt > 0
                    && !entity.XCT5s.Any(e => e.Ma_hh == d.Ma_hh && e.So_to_khai == d.So_to_khai))
                .ToList();
            if (addDtos.Any())
                entity.XCT5s.AddRange(addDtos.Adapt<List<XCT5>>());

            // 2. Xoá các dòng (trong entity nhưng không còn trong dto)
            var removeEntities = entity.XCT5s
                .Where(e => !dto.XCT5s.Any(d => d.Ma_hh == e.Ma_hh && d.So_to_khai == e.So_to_khai))
                .ToList();
            foreach (var removeEntity in removeEntities)
            {
                entity.XCT5s.Remove(removeEntity);
            }

            // 3. Update các dòng có Ma_hh trùng (nếu cần cập nhật các trường khác)
            foreach (var entityItem in entity.XCT5s)
            {
                var dtoItem = dto.XCT5s.FirstOrDefault(d => d.Ma_hh == entityItem.Ma_hh && !string.IsNullOrWhiteSpace(entityItem.So_to_khai) && d.So_to_khai == entityItem.So_to_khai);
                if (dtoItem != null)
                {
                    entityItem.Stt = dtoItem.Stt;
                    entityItem.Ma_hh = dtoItem.Ma_hh;
                    entityItem.Ten_hh = dtoItem.Ten_hh;
                    entityItem.Dvt = dtoItem.Dvt;
                    entityItem.So_luong = dtoItem.So_luong;
                    entityItem.Gia_ban = dtoItem.Gia_ban;
                    entityItem.Gia_ban_nt = dtoItem.Gia_ban_nt;
                    entityItem.Gg_ty_le = dtoItem.Gg_ty_le;
                    entityItem.Gg_tien = dtoItem.Gg_tien;
                    entityItem.Gg_tien_nt = dtoItem.Gg_tien_nt;
                    entityItem.Tien_ban = dtoItem.Tien_ban;
                    entityItem.Tien_ban_nt = dtoItem.Tien_ban_nt;
                    entityItem.Gg_ly_do = dtoItem.Gg_ly_do;
                    entityItem.So_to_khai = dtoItem.So_to_khai;
                }
                else
                {
                    dtoItem = dto.XCT5s.FirstOrDefault(d => d.Ma_hh == entityItem.Ma_hh);
                    if (dtoItem != null)
                    {
                        entityItem.Stt = dtoItem.Stt;
                        entityItem.Ma_hh = dtoItem.Ma_hh;
                        entityItem.Ten_hh = dtoItem.Ten_hh;
                        entityItem.Dvt = dtoItem.Dvt;
                        entityItem.So_luong = dtoItem.So_luong;
                        entityItem.Gia_ban = dtoItem.Gia_ban;
                        entityItem.Gia_ban_nt = dtoItem.Gia_ban_nt;
                        entityItem.Gg_ty_le = dtoItem.Gg_ty_le;
                        entityItem.Gg_tien = dtoItem.Gg_tien;
                        entityItem.Gg_tien_nt = dtoItem.Gg_tien_nt;
                        entityItem.Tien_ban = dtoItem.Tien_ban;
                        entityItem.Tien_ban_nt = dtoItem.Tien_ban_nt;
                        entityItem.Gg_ly_do = dtoItem.Gg_ly_do;
                        entityItem.So_to_khai = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Tính tồn kho sau khi tạo đơn hàng (xuất FIFO, tạo nhiều dòng XCT5, mỗi dòng 1 tờ khai, 1 số lượng thực tế)
        /// </summary>
        private static void TinhTonKho(IUnitOfWork unitOfWork, XPH5 donhang)
        {
            var newXCT5s = new List<XCT5>();

            foreach (var item in donhang.XCT5s.ToList()) // ToList để duyệt an toàn khi xóa/gộp dòng
            {
                var soLuongCanXuat = item.So_luong ?? 0;
                if (soLuongCanXuat <= 0) continue;

                // Lấy các lô tồn kho theo FIFO
                var khoList = unitOfWork.Repository<TokhaiHH>()
                    .Find(x => x.Ma_cua_hang == donhang.Ma_cua_hang
                            && x.Ma_kho == donhang.Ma_kho
                            && x.Ma_hh == item.Ma_hh
                            && x.Con_lai > 0)
                    .OrderBy(x => x.Ngay_nhap)
                    .ToList();

                var tongTonKho = khoList.Sum(x => x.Con_lai ?? 0);
                if (tongTonKho < soLuongCanXuat)
                    throw new BadRequestException($"Không đủ hàng trong kho {donhang.Ma_kho} cho mặt hàng {item.Ma_hh}. Số lượng tồn kho hiện tại: {tongTonKho}");

                foreach (var kho in khoList)
                {
                    if (soLuongCanXuat <= 0) break;
                    var soLuongXuat = Math.Min(kho.Con_lai ?? 0, soLuongCanXuat);

                    kho.Da_xuat += soLuongXuat;
                    kho.Con_lai -= soLuongXuat;
                    unitOfWork.Repository<TokhaiHH>().Update(kho);

                    // Tạo 1 dòng XCT5 mới cho mỗi lô/tờ khai
                    var newItem = new XCT5
                    {
                        Ma_phieu = item.Ma_phieu,
                        Stt = item.Stt,
                        Ma_hh = item.Ma_hh,
                        Ten_hh = item.Ten_hh,
                        Dvt = item.Dvt,
                        Gia_ban = item.Gia_ban,
                        Gia_ban_nt = item.Gia_ban_nt,
                        Gg_ty_le = item.Gg_ty_le,
                        Gg_tien = item.Gg_tien,
                        Gg_tien_nt = item.Gg_tien_nt,
                        Tien_ban = item.Tien_ban,
                        Tien_ban_nt = item.Tien_ban_nt,
                        Gg_ly_do = item.Gg_ly_do,
                        So_luong = soLuongXuat,
                        So_to_khai = kho.So_to_khai,
                    };
                    newXCT5s.Add(newItem);
                    soLuongCanXuat -= soLuongXuat;
                }
            }
            donhang.XCT5s.Clear();
            donhang.XCT5s.AddRange(newXCT5s);
        }

        public static void UpsertXuatKho(IUnitOfWork unitOfWork, XPH5 donhangMoi, XPH5 donhangCu)
        {
            // 1. Hoàn toàn ignore chi tiết "dạng nhập tay" đầu vào, sẽ xử lý lại toàn bộ từ kho thực tế
            // Dictionary để giữ thông tin nghiệp vụ từng mã hàng từ đơn cũ (để copy vào chi tiết mới)
            var infoTemplate = donhangCu.XCT5s
                .GroupBy(x => x.Ma_hh)
                .ToDictionary(g => g.Key, g => g.First());

            // 2. Tổng hợp số lượng từng mã hàng user muốn xuất
            var tongXuatMoi = donhangMoi.XCT5s
                .GroupBy(x => x.Ma_hh)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.So_luong ?? 0));

            // 3. Đầu tiên: hoàn trả lại toàn bộ các lô đã xuất trong đơn cũ vào kho (reset trạng thái kho)
            foreach (var itemCu in donhangCu.XCT5s)
            {
                var kho = unitOfWork.Repository<TokhaiHH>().Find(x =>
                    x.Ma_cua_hang == donhangCu.Ma_cua_hang &&
                    x.Ma_kho == donhangCu.Ma_kho &&
                    x.Ma_hh == itemCu.Ma_hh &&
                    x.So_to_khai == itemCu.So_to_khai).FirstOrDefault();
                if (kho != null)
                {
                    kho.Da_xuat -= (itemCu.So_luong ?? 0);
                    kho.Con_lai += (itemCu.So_luong ?? 0);
                    if (kho.Da_xuat < 0) kho.Da_xuat = 0;
                    unitOfWork.Repository<TokhaiHH>().Update(kho);
                }
            }
            unitOfWork.SaveChanges();

            // 4. Xây lại chi tiết đơn hàng mới từ đầu, dựa trên tổng số lượng từng mã hàng, xuất kho theo FIFO từng lô
            var newXCT5s = new List<XCT5>();
            foreach (var pair in tongXuatMoi)
            {
                string maHH = pair.Key;
                decimal slCanXuat = pair.Value;
                if (slCanXuat <= 0) continue;

                // Lấy lô tồn thực tế theo FIFO
                var khoList = unitOfWork.Repository<TokhaiHH>().Find(x =>
                    x.Ma_cua_hang == donhangMoi.Ma_cua_hang &&
                    x.Ma_kho == donhangMoi.Ma_kho &&
                    x.Ma_hh == maHH &&
                    x.Con_lai > 0)
                    .OrderBy(x => x.Ngay_nhap)
                    .ToList();

                decimal slTon = khoList.Sum(x => x.Con_lai ?? 0);
                if (slTon < slCanXuat)
                    throw new BadRequestException($"Không đủ tồn kho cho mã hàng {maHH}, chỉ còn {slTon}");

                // Dùng để copy các trường nghiệp vụ vào dòng mới
                var template = donhangMoi.XCT5s.FirstOrDefault(x => x.Ma_hh == maHH);

                foreach (var kho in khoList)
                {
                    if (slCanXuat <= 0) break;
                    decimal xuat = Math.Min(kho.Con_lai ?? 0, slCanXuat);

                    // Trừ kho thực tế
                    kho.Da_xuat += xuat;
                    kho.Con_lai -= xuat;
                    unitOfWork.Repository<TokhaiHH>().Update(kho);

                    // Add dòng chi tiết cho từng tờ khai/lô
                    var xct5 = new XCT5
                    {
                        Ma_phieu = template.Ma_phieu,
                        Stt = template.Stt,
                        Ma_hh = template.Ma_hh,
                        Ten_hh = template.Ten_hh,
                        Dvt = template.Dvt,
                        Gia_ban = template.Gia_ban,
                        Gia_ban_nt = template.Gia_ban_nt,
                        Gg_ty_le = template.Gg_ty_le,
                        Gg_tien = template.Gg_tien,
                        Gg_tien_nt = template.Gg_tien_nt,
                        Tien_ban = template.Tien_ban,
                        Tien_ban_nt = template.Tien_ban_nt,
                        Gg_ly_do = template.Gg_ly_do,
                        So_luong = xuat,
                        So_to_khai = kho.So_to_khai,
                    };

                    // tính lại tiền
                    if (xct5.So_luong.HasValue && xct5.Gia_ban.HasValue && xct5.Gia_ban_nt.HasValue && xct5.Gg_ty_le.HasValue)
                    {
                        decimal giaNT = xct5.Gia_ban_nt ?? 0;
                        //giaVND = item.Gia_ban ?? 0;
                        decimal giaVND = giaNT * donhangMoi?.Ty_gia ?? 0;
                        var tienGiamNT = (decimal)Math.Round((double)(xct5.So_luong * giaNT * xct5.Gg_ty_le / 100), 2);
                        var tienGiamVND = (decimal)Math.Round((double)(xct5.So_luong * giaVND * xct5.Gg_ty_le / 100), 0);

                        xct5.Gg_tien_nt = tienGiamNT;
                        xct5.Gg_tien = tienGiamVND;

                        var thanhTienNT = xct5.So_luong * xct5.Gia_ban_nt - tienGiamNT;
                        xct5.Tien_ban_nt = thanhTienNT;
                        xct5.Tien_ban = thanhTienNT * donhangMoi?.Ty_gia ?? 0;
                    }

                    newXCT5s.Add(xct5);
                    slCanXuat -= xuat;
                }
            }

            // 5. Thay toàn bộ chi tiết đơn hàng bằng danh sách mới đã tách lô/tờ khai chính xác
            donhangMoi.XCT5s.Clear();
            donhangMoi.XCT5s.AddRange(newXCT5s);

            // tính lại tổng cộng 
            TinhTongCong(donhangMoi, newXCT5s);
        }

        /// <summary>
        /// Tính toán tổng tiền hàng, giảm giá và thu tiền.
        /// </summary>
        private static void TinhTongCong(XPH5 donhangMoi, List<XCT5> xCT5s)
        {
            decimal tongTienHang = 0;
            decimal tienGiam = 0;
            decimal tongThu = 0;
            foreach (var xCT5 in xCT5s)
            {
                if (xCT5.Gia_ban_nt.HasValue && xCT5.So_luong.HasValue && xCT5.Gg_tien_nt.HasValue)
                {
                    tongTienHang += xCT5.Gia_ban_nt.Value * xCT5.So_luong.Value;
                    tienGiam += xCT5.Gg_tien_nt.Value;
                }
            }

            tongThu += tongTienHang - tienGiam;
            donhangMoi.Tong_tien_hang_nt = tongTienHang;
            donhangMoi.Tong_giam_gia_nt = tienGiam;
            donhangMoi.Tong_thu_nt = tongThu;
        }

        /// <summary>
        /// Xoá đơn hàng theo mã phiếu
        /// </summary>
        /// <param name="maPhieu"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public (bool result, string message) XoaDonHang(string maPhieu)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                try
                {
                    unitOfWork.BeginTransaction();
                    // Kiểm tra tồn tại đơn hàng
                    var donHang = unitOfWork.Repository<XPH5>()
                        .Find(x => x.Ma_phieu == maPhieu)
                        .FirstOrDefault();
                    if (donHang == null)
                        throw new BadRequestException($"Không tìm thấy đơn hàng với mã phiếu: {maPhieu}");

                    if (donHang.Trang_thai == TrangThaiDonHang.Confirmed)
                        throw new BadRequestException("Đơn hàng đã phát sinh số đơn hàng không thể xóa được.");
                    // Xoá chi tiết đơn hàng
                    var chiTietList = unitOfWork.Repository<XCT5>()
                        .Find(x => x.Ma_phieu == maPhieu)
                        .ToList();
                    foreach (var chiTiet in chiTietList)
                    {
                        unitOfWork.Repository<XCT5>().Remove(chiTiet);
                    }
                    // Xoá đơn hàng
                    unitOfWork.Repository<XPH5>().Remove(donHang);
                    unitOfWork.SaveChanges();
                    unitOfWork.Commit();
                    return (true, "Xoá đơn hàng thành công");
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    return (false, "Lỗi khi xoá đơn hàng: " + ex.Message);
                }
            }
        }
    }
}