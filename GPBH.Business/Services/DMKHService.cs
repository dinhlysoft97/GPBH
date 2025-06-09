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
    public class DMKHService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DMKHService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DMKHDto> GetAllKhachHang()
        {
            return _unitOfWork.Repository<DMKH>().GetAll()
                .Select(z => new DMKHDto
                {
                    Passport = z.Passport,
                    Ho = z.Ho,
                    Ten_dem = z.Ten_dem,
                    Ten = z.Ten,
                    Ngay_cap = z.Ngay_cap,
                    Ngay_hh = z.Ngay_hh,
                    Quoc_gia = z.Quoc_gia,
                    Gioi_tinh = z.Gioi_tinh,
                    Ngay_sinh = z.Ngay_sinh,
                    Dia_chi = z.Dia_chi,
                    Dien_thoai = z.Dien_thoai,
                    Di_dong = z.Di_dong,
                    Email = z.Email,
                    DMQG = z.DMQG
                }).ToList();
        }

        public void AddKH(DMKHDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // Kiểm tra bắt buộc nhập
            if (string.IsNullOrWhiteSpace(dto.Passport))
                throw new ArgumentException("Vui lòng nhập số Passport.");
            if (string.IsNullOrWhiteSpace(dto.Ho) && string.IsNullOrWhiteSpace(dto.Ten) && string.IsNullOrWhiteSpace(dto.Ten_dem))
                throw new ArgumentException("Vui lòng nhập tên khách hàng.");
            if (string.IsNullOrWhiteSpace(dto.Dien_thoai))
                throw new ArgumentException("Vui lòng nhập số điện thoại.");

            // Kiểm tra trùng Passport
            var existed = _unitOfWork.Repository<DMKH>().GetById(dto.Passport);
            if (existed != null)
                throw new ArgumentException("Passport đã tồn tại trong hệ thống.");

            // Tạo entity mới
            var entity = new DMKH
            {
                Passport = dto.Passport,
                Ho = dto.Ho,
                Ten_dem = dto.Ten_dem,
                Ten = dto.Ten,
                Ngay_cap = dto.Ngay_cap,
                Ngay_hh = dto.Ngay_hh,
                Quoc_gia = dto.Quoc_gia,
                Gioi_tinh = dto.Gioi_tinh,
                Ngay_sinh = dto.Ngay_sinh,
                Dia_chi = dto.Dia_chi,
                Dien_thoai = dto.Dien_thoai,
                Di_dong = dto.Di_dong,
                Email = dto.Email
            };

            _unitOfWork.Repository<DMKH>().Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void EditKH(string oldPassport, DMKHDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(oldPassport))
                throw new ArgumentException("Không xác định được khách hàng cần sửa.");

            var entity = _unitOfWork.Repository<DMKH>().GetById(oldPassport);
            if (entity == null)
                throw new ArgumentException("Không tìm thấy khách hàng cần sửa.");

            // Nếu đổi passport, kiểm tra trùng
            if (!string.Equals(oldPassport, dto.Passport, StringComparison.OrdinalIgnoreCase))
            {
                var existed = _unitOfWork.Repository<DMKH>().GetById(dto.Passport);
                if (existed != null)
                    throw new ArgumentException("Passport mới đã tồn tại trong hệ thống.");
                // Xóa bản ghi cũ, thêm bản ghi mới (nếu ORM không hỗ trợ đổi PK)
                _unitOfWork.Repository<DMKH>().Remove(entity);
                var newEntity = new DMKH
                {
                    Passport = dto.Passport,
                    Ho = dto.Ho,
                    Ten_dem = dto.Ten_dem,
                    Ten = dto.Ten,
                    Ngay_cap = dto.Ngay_cap,
                    Ngay_hh = dto.Ngay_hh,
                    Quoc_gia = dto.Quoc_gia,
                    Gioi_tinh = dto.Gioi_tinh,
                    Ngay_sinh = dto.Ngay_sinh,
                    Dia_chi = dto.Dia_chi,
                    Dien_thoai = dto.Dien_thoai,
                    Di_dong = dto.Di_dong,
                    Email = dto.Email
                };
                _unitOfWork.Repository<DMKH>().Add(newEntity);
            }
            else
            {
                entity.Ho = dto.Ho;
                entity.Ten_dem = dto.Ten_dem;
                entity.Ten = dto.Ten;
                entity.Ngay_cap = dto.Ngay_cap;
                entity.Ngay_hh = dto.Ngay_hh;
                entity.Quoc_gia = dto.Quoc_gia;
                entity.Gioi_tinh = dto.Gioi_tinh;
                entity.Ngay_sinh = dto.Ngay_sinh;
                entity.Dia_chi = dto.Dia_chi;
                entity.Dien_thoai = dto.Dien_thoai;
                entity.Di_dong = dto.Di_dong;
                entity.Email = dto.Email;
                _unitOfWork.Repository<DMKH>().Update(entity);
            }
            _unitOfWork.SaveChanges();
        }

        public void DeleteKH(string passport)
        {
            if (string.IsNullOrWhiteSpace(passport))
                throw new ArgumentNullException(nameof(passport));

            var entity = _unitOfWork.Repository<DMKH>().GetById(passport);
            if (entity == null)
                throw new ArgumentException("Không tìm thấy khách hàng cần xóa.");

            //// Kiểm tra ràng buộc với đơn hàng
            //var hasOrder = _unitOfWork.Repository<DonHang>()
            //    .Find(x => x.Passport == passport)
            //    .Any();
            //if (hasOrder)
            //    throw new InvalidOperationException("Khách hàng đã có dữ liệu trong đơn hàng, không thể xóa.");

            _unitOfWork.Repository<DMKH>().Remove(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
