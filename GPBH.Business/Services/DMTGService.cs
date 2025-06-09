using GPBH.Business.Dtos;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GPBH.Business.Services
{
    public class DMTGService
    {
        private readonly IServiceProvider _serviceProvider;

        public DMTGService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TyGiaNT GetTyGiaByMaNT(string maNT)
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var today = DateTime.Today;

                // Get tỷ giá ngoại tệ nhỏ hơn hoặc bằng ngày hiện tại và order by theo ngày gần nhất.
                if (!string.IsNullOrEmpty(maNT))
                {
                    var tyGiaNT = unitOfWork.Repository<DMTG>().Find(z => z.Ma_nt == maNT && z.Ngay_ap_dung <= today)
                        .OrderByDescending(z => z.Ngay_ap_dung)
                        .Select(z => new TyGiaNT
                        {
                            Ma_nt = z.Ma_nt,
                            Ngay_ap_dung = z.Ngay_ap_dung,
                            Ty_gia = z.Ty_gia
                        })
                        .FirstOrDefault();

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
