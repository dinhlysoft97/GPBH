using GPBH.Business.Dtos;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
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
        /// Tạo đơn hàng mới từ DTO, sinh số chứng từ và mã phiếu tự động
        /// </summary>
        /// <param name="donhang"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public (XPH5Dto, bool) TaoDonHang(XPH5Dto donhang)
        {
            var entity = new XPH5();
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                try
                {
                    unitOfWork.BeginTransaction();
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
                                throw new Exception("Không thể tạo số chứng từ không trùng sau nhiều lần thử!");
                        }
                        while (daTonTai);

                        entity.So_chung_tu = soChungTuMoi;

                        TinhTonKho(entity);
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
                    throw new Exception("Lỗi khi tạo đơn hàng: " + ex.Message);
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
                                throw new Exception("Không thể tạo số chứng từ không trùng sau nhiều lần thử!");
                        }
                        while (daTonTai);

                        entity.So_chung_tu = soChungTuMoi;
                        TinhTonKho(entity);
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
                    throw new Exception("Lỗi khi tạo đơn hàng: " + ex.Message);
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
        private string GenerateMaPhieu(IUnitOfWork unitOfWork, string ma_dv, string ma_chung_tu)
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
                    throw new Exception("Không thể tạo mã phiếu không trùng sau nhiều lần thử!");
            }
            while (daTonTai);

            return maPhieuMoi;
        }

        /// <summary>
        /// Tính tồn kho sau khi tạo đơn hàng
        /// </summary>
        /// <param name="donhang"></param>
        private void TinhTonKho(XPH5 donhang)
        {
            // code tính tồn kho
        }
    }
}