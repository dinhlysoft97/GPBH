using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using GPBH.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using GPBH.Business.Dtos;
using GPBH.Data.Configurations;

namespace GPBH.Business.Services
{
    public class SysDMCuaHangService
    {
        private readonly IServiceProvider _serviceProvider;

        public SysDMCuaHangService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public SysDMCuaHang GetByMaCuaHang(string maCH)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<SysDMCuaHang>()
                .Find(u => u.Ma_cua_hang == maCH).FirstOrDefault();
            }
        }

        public TyGiaNT GetTyGiaByMaCuaHang(string maCuaHang)
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var cuaHang = unitOfWork.Repository<SysDMCuaHang>()
                    .Find(z => z.Ma_cua_hang == maCuaHang)
                    .FirstOrDefault();
                if (cuaHang == null) return null;

                // Get tỷ giá ngoại tệ nhỏ hơn hoặc bằng ngày hiện tại và order by theo ngày gần nhất.
                if (!string.IsNullOrEmpty(cuaHang.Ma_nt))
                {
                    var dmtgService = scope.ServiceProvider.GetRequiredService<DMTGService>();
                    var tyGiaNT = dmtgService.GetTyGiaByMaNT(cuaHang.Ma_nt);
                    if (tyGiaNT != null)
                    {
                        return tyGiaNT;
                    }
                }
                return null;
            }
        }
    }
}
