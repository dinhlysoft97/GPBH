using GPBH.Business.DTO;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GPBH.Business.Services
{
    public class DMKHService
    {
        private readonly IServiceProvider _serviceProvider;

        public DMKHService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public DMKHDto GetCustomerByPassport(string passport)
        {
            if (string.IsNullOrWhiteSpace(passport))
                return null;
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var result = unitOfWork.Repository<DMKH>().Find(DMKHDto => DMKHDto.Passport == passport).FirstOrDefault();
                return DMKHToDto(result);
            }
        }

        public DMKHDto AddCustomer(DMKHDto customer)
        {
            var entity = new DMKH
            {
                Passport = customer.Passport,
                Ho = customer.Ho,
                Ten_dem = customer.Ten_dem,
                Ten = customer.Ten,
                Ngay_cap = customer.Ngay_cap,
                Ngay_hh = customer.Ngay_hh,
                Quoc_gia = customer.Quoc_gia,
                Gioi_tinh = customer.Gioi_tinh,
                Ngay_sinh = customer.Ngay_sinh,
                Dia_chi = customer.Dia_chi,
                Dien_thoai = customer.Dien_thoai,
                Email = customer.Email,
                Xnc_ngay_cap = customer.Xnc_ngay_cap,
                Xnc_ngay_hh = customer.Xnc_ngay_hh,
                So_hieu = customer.So_hieu,
                Ten_tau_bay = customer.Ten_tau_bay,
                Han_muc = customer.Han_muc
            };
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                unitOfWork.Repository<DMKH>().Add(entity);
                unitOfWork.SaveChanges();
                return DMKHToDto(entity); ;
            }
        }

        private DMKHDto DMKHToDto(DMKH entity)
        {
            var dto = new DMKHDto();
            if (entity != null)
            {
                // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
                using (var scope = _serviceProvider.CreateScope())
                {
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var quocGia = unitOfWork.Repository<DMQG>().Find(z => z.Quoc_gia == entity.Quoc_gia).FirstOrDefault();
                    dto.Passport = entity.Passport;
                    dto.Ho = entity.Ho;
                    dto.Ten_dem = entity.Ten_dem;
                    dto.Ten = entity.Ten;
                    dto.Ngay_cap = entity.Ngay_cap;
                    dto.Ngay_hh = entity.Ngay_hh;
                    dto.Quoc_gia = entity.Quoc_gia;
                    dto.Ten_Quoc_Gia = quocGia.Ten_Quoc_gia;
                    dto.Gioi_tinh = entity.Gioi_tinh;
                    dto.Ngay_sinh = entity.Ngay_sinh;
                    dto.Dia_chi = entity.Dia_chi;
                    dto.Dien_thoai = entity.Dien_thoai;
                    dto.Email = entity.Email;
                    dto.Xnc_ngay_cap = entity.Xnc_ngay_cap;
                    dto.Xnc_ngay_hh = entity.Xnc_ngay_hh;
                    dto.So_hieu = entity.So_hieu;
                    dto.Ten_tau_bay = entity.Ten_tau_bay;
                    dto.Han_muc = entity.Han_muc;

                    return dto;
                }
            }
            return null;
        }
    }
}
