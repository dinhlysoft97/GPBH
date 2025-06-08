using GPBH.Business.DTO;
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

        public List<SystemMenuDto> GetAllMenus()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<SysMenu>().GetAll()
                .Select(z => new SystemMenuDto
                {
                    MenuId = z.MenuId,
                    MenuName = z.MenuName,
                    Type = (int)z.Type,
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
