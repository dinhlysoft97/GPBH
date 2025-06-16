using GPBH.Business.Dtos;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPBH.Business.Services
{
    public class DMQGService
    {
        private readonly IServiceProvider _serviceProvider;

        public DMQGService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<GridQuocGia> GetAll()
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<DMQG>().GetAll()
                    .Where(z => z.Ksd)
                    .OrderBy(z => z.Quoc_gia)
                    .Select(z => new GridQuocGia
                    {
                        Quoc_gia = z.Quoc_gia,
                        Ten_Quoc_gia = z.Ten_Quoc_gia
                    })
                    .ToList();

            }
        }

        public DMQG GetByMaQuocGia( string quoc_gia)
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<DMQG>().Find(z => z.Quoc_gia == quoc_gia && z.Ksd).FirstOrDefault();
            }
        }
    }
}
