using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPBH.Business.Services
{
    public class SysMenuService
    {
        private readonly IServiceProvider _serviceProvider;

        public SysMenuService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<SysMenu> GetAllMenus()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<SysMenu>().GetAll()
                .Select(z => new SysMenu
                {
                    MenuId = z.MenuId,
                    MenuName = z.MenuName,
                    Type = z.Type,
                    Report = z.Report,
                    BasicRight = z.BasicRight,
                    Picture = z.Picture,
                    Active = z.Active,
                    Stt = z.Stt
                }).ToList();
            }
        }
    }
}
