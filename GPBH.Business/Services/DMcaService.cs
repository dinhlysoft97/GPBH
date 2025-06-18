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
                return unitOfWork.Repository<DMca>().GetAll().OrderBy(z => z.Ma_ca).ToList();
            }
        }
    }
}
