using GPBH.Business.DTO;
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

        public List<DMQGDto> GetAll()
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<DMQG>().Find(z => z.Ksd)
                    .Select(z => new DMQGDto
                    {
                        Quoc_gia = z.Quoc_gia,
                        Ten_Quoc_gia = z.Ten_Quoc_gia,
                    }).ToList();
            }
        }
    }
}
