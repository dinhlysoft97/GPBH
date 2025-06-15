using GPBH.Business.Dtos;
using GPBH.Data.Configurations;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPBH.Business.Services
{
    public class DMHHService
    {
        private readonly IServiceProvider _serviceProvider;

        public DMHHService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<DMHH> GetAll()
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<DMHH>().Find(z => z.Ksd).OrderBy(z => z.Ma_hh).ToList();
            }
        }

        public GiaBanHangHoa GiaBanHangHoa(string maHangHoa, string maNgoaiTe = null)
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var hangHoa = unitOfWork.Repository<DMHH>().Find(z => z.Ma_hh == maHangHoa && z.Ksd).FirstOrDefault();
                if (hangHoa == null) return null;

                // Get trong giá bàn ra nhỏ hơn hoặc bằng ngày hiện tại và order by theo ngày gần nhất.
                var today = DateTime.Today;
                var giaBanHangHoa = unitOfWork.Repository<DMGB>()
                    .Find(z => z.Ma_cua_hang == AppGlobals.MaCH
                           && z.Ma_hh == maHangHoa
                           && z.Ngay_ap_dung <= today)
                    .OrderByDescending(z => z.Ngay_ap_dung)
                    .FirstOrDefault();
                if (giaBanHangHoa == null) return null;
                var giaBan = new GiaBanHangHoa
                {
                    Ma_hh = hangHoa.Ma_hh,
                    Ngay_ap_dung = giaBanHangHoa.Ngay_ap_dung,
                    Ma_cua_hang = giaBanHangHoa.Ma_cua_hang,
                    Gia_ban = giaBanHangHoa.Gia_ban,
                    TyGiaNT = null
                };

                // Get tỷ giá ngoại tệ nhỏ hơn hoặc bằng ngày hiện tại và order by theo ngày gần nhất.
                if (!string.IsNullOrEmpty(maNgoaiTe))
                {
                    var dmtgService = scope.ServiceProvider.GetRequiredService<DMTGService>();
                    var tyGiaNT = dmtgService.GetTyGiaByMaNT(maNgoaiTe);

                    if (tyGiaNT != null)
                    {
                        giaBan.TyGiaNT = tyGiaNT;
                    }
                }
                return giaBan;
            }
        }
    }
}
