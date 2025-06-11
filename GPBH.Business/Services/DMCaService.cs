using GPBH.Business.DTO;
using GPBH.Data;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.Services
{
    public class DMcaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DMcaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DMcaDto> GetAllCa()
        {
            return _unitOfWork.Repository<DMca>().GetAll()
                .Select(z => new DMcaDto
                {
                    Ma_ca = z.Ma_ca,
                    Ten_ca = z.Ten_ca,
                    Gio_bd = z.Gio_bd,
                    Gio_kt = z.Gio_kt
                }).ToList();
        }
        public void AddCa(DMcaDto dto)
        {
            if(dto == null)
                throw new ArgumentNullException(nameof(dto));
            var entity = new DMca
            {
                Ma_ca = dto.Ma_ca,
                Ten_ca = dto.Ten_ca,
                Gio_bd = dto.Gio_bd,
                Gio_kt = dto.Gio_kt
            };
            _unitOfWork.Repository<DMca>().Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void EditCa(DMcaDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = _unitOfWork.Repository<DMca>().GetById(dto.Ma_ca);
            if (entity == null)
                throw new ArgumentException("Không tim thấy mã ca cần sửa.");

            entity.Ten_ca = dto.Ten_ca;
            entity.Gio_bd = dto.Gio_bd;
            entity.Gio_kt = dto.Gio_kt;

            _unitOfWork.Repository<DMca>().Update(entity);
            _unitOfWork.SaveChanges();

        }

        public void DeleteCa(DMcaDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = _unitOfWork.Repository<DMca>().GetById(dto.Ma_ca);
            if (entity == null)
                throw new ArgumentException("Không tìm thấy mã ca cần xóa.");

            _unitOfWork.Repository<DMca>().Remove(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
