using GPBH.Business.DTO;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.Services
{
    public class DMQGService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DMQGService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }
        public List<DMQGDto> GetAllQuocGia()
        {
            return _unitOfWork.Repository<DMQG>().GetAll()
                .Select(x => new DMQGDto
                {
                    Quoc_gia = x.Quoc_gia,
                    Ksd = x.Ksd,
                }).ToList();
        }
    }
}
