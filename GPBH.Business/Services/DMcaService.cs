using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPBH.Business.Services
{
    public class DMcaService
    {
        private readonly IServiceProvider _serviceProvider;

        public DMcaService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<DMca> GetAll()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<DMca>().GetAll().ToList();
            }
        }

        public DMca GetByMaCa(string maCa)
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<DMca>()
                .Find(u => u.Ma_ca == maCa).FirstOrDefault();
            }
        }

        public void Add(DMca entity)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                unitOfWork.Repository<DMca>().Add(entity);
                unitOfWork.SaveChanges();
            }
        }

        public void Update(DMca entity)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var existing = unitOfWork.Repository<DMca>().Find(x => x.Ma_ca == entity.Ma_ca).FirstOrDefault();
                if (existing != null)
                {
                    existing.Ten_ca = entity.Ten_ca;
                    existing.Gio_bd = entity.Gio_bd;
                    existing.Gio_kt = entity.Gio_kt;
                    unitOfWork.Repository<DMca>().Update(existing);
                    unitOfWork.SaveChanges();
                }
            }
        }

        public void Delete(string maCa)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var entity = unitOfWork.Repository<DMca>().Find(x => x.Ma_ca == maCa).FirstOrDefault();
                if (entity != null)
                {
                    unitOfWork.Repository<DMca>().Remove(entity);
                    unitOfWork.SaveChanges();
                }
            }
        }

        public bool CheckTrungTenCa(string tenCa)
        {
            if (string.IsNullOrWhiteSpace(tenCa))
                return false;

            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var exists = unitOfWork.Repository<DMca>()
                    .Find(u => u.Ten_ca == tenCa)
                    .Any();
                return exists;
            }
        }
    }
}
