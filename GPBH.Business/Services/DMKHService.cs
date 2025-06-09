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
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                unitOfWork.Repository<DMKH>().Add(entity);
                unitOfWork.SaveChanges();
                return entity;
            }
        }
    }
}
