using GPBH.Business.DTO;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace GPBH.Business.Services
{
    public class DMQGService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DMQGService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DMQGDto> GetAll()
        {
            return _unitOfWork.Repository<DMQG>().Find(z => z.Ksd)
                .Select(z => new DMQGDto
                {
                    Quoc_gia = z.Quoc_gia,
                    Ten_Quoc_gia = z.Ten_Quoc_gia,
                }).ToList();
        }
    }
}
