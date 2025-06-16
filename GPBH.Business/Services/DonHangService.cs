using GPBH.Business.Dtos;
using GPBH.Business.Exceptions;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<GirdDonHangDto> TiemKiem(DateTime tuNgay, DateTime denNgay)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<XPH5>()
                    .Find(x => x.Ngay_chung_tu >= tuNgay && x.Ngay_chung_tu <= denNgay)
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

                    var entity = unitOfWork.Repository<XPH5>()
                        .Find(x => x.Ma_phieu == donhang.Ma_phieu)
                        .FirstOrDefault();

                    // Update chi tiết
                    UpdateChiTietDonHang(entity, donhang);

                    if (entity.Trang_thai == TrangThaiDonHang.Draft && donhang.Trang_thai == TrangThaiDonHang.Confirmed)
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

                    // Update đơn hàng
                    unitOfWork.Repository<XPH5>().Update(entity);
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
                .Where(d => d.Stt > 0 && !entity.XCT5s.Any(e => e.Ma_hh == d.Ma_hh))
                .ToList();
            if (addDtos.Any())
                entity.XCT5s.AddRange(addDtos.Adapt<List<XCT5>>());

            // 2. Xoá các dòng (trong entity nhưng không còn trong dto)
            var removeEntities = entity.XCT5s
                .Where(e => !dto.XCT5s.Any(d => d.Ma_hh == e.Ma_hh))
                .ToList();

            foreach (var entityItem in removeEntities)
            {
                entity.XCT5s.Remove(entityItem);
            }

            // 3. Update các dòng có Ma_hh trùng (nếu cần cập nhật các trường khác)
            foreach (var entityItem in entity.XCT5s)
            {
                var dtoItem = dto.XCT5s.FirstOrDefault(d => d.Ma_hh == entityItem.Ma_hh);
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
                }
            }
        }

        /// <summary>
        /// Tính tồn kho sau khi tạo đơn hàng (xuất FIFO nhiều lô nếu cần)
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="donhang"></param>
        private static void TinhTonKho(IUnitOfWork unitOfWork, XPH5 donhang)
        {
            foreach (var item in donhang.XCT5s)
            {
                if (item != null)
                {
                    var soLuongCanXuat = item.So_luong ?? 0;
                    if (soLuongCanXuat <= 0) continue;

                    // Lấy danh sách các lô hàng theo ngày nhập tăng dần (FIFO)
                    var khoList = unitOfWork.Repository<TokhaiHH>()
                        .Find(x => x.Ma_cua_hang == donhang.Ma_cua_hang
                                && x.Ma_kho == donhang.Ma_kho
                                && x.Ma_hh == item.Ma_hh
                                && x.Con_lai > 0)
                        .OrderBy(x => x.Ngay_nhap)
                        .ToList();

                    var tongTonKho = khoList.Sum(x => x.Con_lai);
                    if (tongTonKho < soLuongCanXuat)
                    {
                        throw new BadRequestException($"Không đủ hàng trong kho {donhang.Ma_kho} cho mặt hàng {item.Ma_hh}. Số lượng tồn kho hiện tại: {tongTonKho}");
                    }

                    // Xuất hàng theo từng lô nhập (FIFO)
                    foreach (var kho in khoList)
                    {
                        if (soLuongCanXuat <= 0) break;

                        var soLuongXuat = Math.Min(kho.Con_lai ?? 0, soLuongCanXuat);

                        kho.Da_xuat += soLuongXuat;
                        kho.Con_lai -= soLuongXuat;
                        unitOfWork.Repository<TokhaiHH>().Update(kho);

                        // Gán số tờ khai cho item, chỉ lấy tờ khai đầu tiên (nếu cần tất cả thì lưu dạng danh sách)
                        if (item.So_to_khai == null)
                            item.So_to_khai = kho.So_to_khai;

                        soLuongCanXuat -= soLuongXuat;
                    }
                }
            }
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