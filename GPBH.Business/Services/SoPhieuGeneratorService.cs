using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GPBH.Business.Services
{
    public class SoPhieuGeneratorService
    {
        private readonly IServiceProvider _serviceProvider;

        public SoPhieuGeneratorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string GenerateSoPhieu(string maCuaHang, string maChungTu, DateTime ngayLap)
        {
            // 1. Lấy cấu hình sysDMCT
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var dmct = unitOfWork.Repository<SysDMCT>().Find(x => x.Ma_cua_hang == maCuaHang && x.Ma_chung_tu == maChungTu).FirstOrDefault();

                if (dmct == null)
                    throw new Exception("Không tìm thấy cấu hình sysDMCT");

                // 2. Thay đổi phần đầu/cuối số phiếu theo ngày tháng năm
                string dauSo = ReplaceDateMarkers(dmct.Dau_so, ngayLap);
                string cuoiSo = ReplaceDateMarkers(dmct.Cuoi_so, ngayLap);

                // 3. Xác định cách đánh số
                int thang, nam = ngayLap.Year;
                if (dmct.Cach_danh_so == "1") // Theo tháng
                    thang = ngayLap.Month;
                else // Theo năm
                    thang = 0;

                var lastPhieu = unitOfWork.Repository<SysSoChungTu>()
                    .Find(x => x.Ma_cua_hang == maCuaHang
                                && x.Ma_chung_tu == maChungTu
                                && x.Thang == thang
                                && x.Nam == nam)
                    .OrderByDescending(x => x.So_phieu)
                    .FirstOrDefault();


                int soPhieuTiepTheo = 1;
                if (lastPhieu != null && int.TryParse(lastPhieu.So_phieu.Substring(dauSo.Length, dmct.So_phieu), out int soPhieuCu))
                {
                    soPhieuTiepTheo = soPhieuCu + 1;
                }

                // 5. Định dạng phần tự tăng
                string soPhieuStr = soPhieuTiepTheo.ToString().PadLeft(dmct.So_phieu, '0');

                // 6. Ghép số phiếu hoàn chỉnh
                string soPhieuFull = $"{dauSo}{soPhieuStr}{cuoiSo}";

                // 7. Lưu vào SysSo_chung_tu
                var newPhieu = new SysSoChungTu
                {
                    Ma_cua_hang = maCuaHang,
                    Ma_chung_tu = maChungTu,
                    Thang = thang,
                    Nam = nam,
                    Ngay_lap = ngayLap,
                    So_phieu = soPhieuFull
                };
                unitOfWork.Repository<SysSoChungTu>().Add(newPhieu);
                unitOfWork.SaveChanges();
                return soPhieuFull;
            }
        }

        private string ReplaceDateMarkers(string str, DateTime ngayLap)
        {
            if (string.IsNullOrEmpty(str)) return "";
            return str.Replace("{dd}", ngayLap.ToString("dd"))
                      .Replace("{mm}", ngayLap.ToString("MM"))
                      .Replace("{yy}", ngayLap.ToString("yy"))
                      .Replace("{yyyy}", ngayLap.ToString("yyyy"));
        }
    }
}
