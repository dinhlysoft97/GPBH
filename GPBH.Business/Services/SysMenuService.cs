using GPBH.Business.DTO;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace GPBH.Business.Services
{
    public class SysMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SysMenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<SystemMenuDto> GetAllMenus()
        {
            return _unitOfWork.Repository<SysMenu>().GetAll()
                .Select(z => new SystemMenuDto
                {
                    Id = z.Id,
                    Key = z.Key,
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
