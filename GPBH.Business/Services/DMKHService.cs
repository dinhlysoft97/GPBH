using GPBH.Business.Dtos;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

        public List<GridKhachHang> GetAll()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                return unitOfWork.Repository<DMKH>().GetAll()
                    .Select(z => new GridKhachHang
                    {
                        Passport = z.Passport,
                        Ho = z.Ho,
                        Ten_dem = z.Ten_dem,
                        Ten = z.Ten,
                        Ngay_cap = z.Ngay_cap,
                        Ngay_hh = z.Ngay_hh,
                        Quoc_gia = z.Quoc_gia,
                        Gioi_tinh = z.Gioi_tinh,
                        Ngay_sinh = z.Ngay_sinh,
                        Dia_chi = z.Dia_chi,
                        Dien_thoai = z.Dien_thoai,
                        Email = z.Email,
                        Xnc_ngay_cap = z.Xnc_ngay_cap,
                        Xnc_ngay_hh = z.Xnc_ngay_hh,
                        So_hieu = z.So_hieu,
                        Ten_tau_bay = z.Ten_tau_bay,
                        Han_muc = z.Han_muc
                    })
                    .OrderBy(z => z.Passport)
                    .ToList();
            }
        }

        public DMKH GetByPassport(string passport)
        {
            if (string.IsNullOrWhiteSpace(passport))
                return null;
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var result = unitOfWork.Repository<DMKH>().Find(DMKHDto => DMKHDto.Passport == passport).FirstOrDefault();
                return result;
            }
        }

        public DMKH AddCustomer(DMKH entity)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var exists = unitOfWork.Repository<DMKH>().Find(x => x.Passport == entity.Passport).Any();
                if (exists)
                    throw new Exception($"Khách hàng với số CCCD/Passport '{entity.Passport}' đã tồn tại!");

                unitOfWork.Repository<DMKH>().Add(entity);
                unitOfWork.SaveChanges();
                return entity;
            }
        }

        public DMKH EditCustomer(DMKH entity)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var repo = unitOfWork.Repository<DMKH>();
                var existing = repo.Find(x => x.Passport == entity.Passport).FirstOrDefault();
                if (existing == null)
                    throw new InvalidOperationException("Không tìm thấy khách hàng.");

                existing.Ho = entity.Ho;
                existing.Ten_dem = entity.Ten_dem;
                existing.Ten = entity.Ten;
                existing.Ngay_cap = entity.Ngay_cap;
                existing.Ngay_hh = entity.Ngay_hh;
                existing.Quoc_gia = entity.Quoc_gia;
                existing.Gioi_tinh = entity.Gioi_tinh;
                existing.Ngay_sinh = entity.Ngay_sinh;
                existing.Dia_chi = entity.Dia_chi;
                existing.Dien_thoai = entity.Dien_thoai;
                existing.Email = entity.Email;
                existing.Xnc_ngay_cap = entity.Xnc_ngay_cap;
                existing.Xnc_ngay_hh = entity.Xnc_ngay_hh;
                existing.So_hieu = entity.So_hieu;
                existing.Ten_tau_bay = entity.Ten_tau_bay;
                existing.Han_muc = entity.Han_muc;

                existing.Nguoi_sua = entity.Nguoi_sua;
                existing.Ngay_sua = DateTime.Now;

                repo.Update(existing);
                unitOfWork.SaveChanges();
                return existing;
            }
        }

        public void DeleteCustomer(string passport)
        {
            if (string.IsNullOrWhiteSpace(passport))
                throw new ArgumentException("Hộ chiếu không hợp lệ.");

            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var repo = unitOfWork.Repository<DMKH>();
                var existing = repo.Find(x => x.Passport == passport).FirstOrDefault();
                if (existing == null)
                    throw new InvalidOperationException("Không tìm thấy khách hàng.");

                repo.Remove(existing);
                unitOfWork.SaveChanges();
            }
        }
    }
}
