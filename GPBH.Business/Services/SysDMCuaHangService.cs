using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using GPBH.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
    }
}
