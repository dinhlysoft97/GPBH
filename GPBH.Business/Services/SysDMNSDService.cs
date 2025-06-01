using GPBH.Business.DTO;
using GPBH.Data;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GPBH.Business
{
    public class SysDMNSDService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SysDMNSDService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Đăng nhập hệ thống với mật khẩu đã mã hóa (SHA-256)
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <param name="matKhau">Mật khẩu plain text</param>
        /// <returns>SysDMNSD nếu thành công, null nếu thất bại</returns>
        public SysDMNSDDto DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            string matKhauHash = HashPassword(matKhau);

            var user = _unitOfWork.Repository<SysDMNSD>()
                .Find(u => u.TenDangNhap == tenDangNhap && u.MatKhau == matKhauHash && u.Ksd).FirstOrDefault();
            AppDbContext.CurrentUserName = tenDangNhap;
            return new SysDMNSDDto
            {
                Id = user?.Id ?? 0,
                TenDangNhap = user?.TenDangNhap,
                TenDayDu = user?.TenDayDu,
                MatKhau = user?.MatKhau,
                IsAdmin = user?.IsAdmin ?? false,
                Ksd = user?.Ksd ?? false
            };
        }

        /// <summary>
        /// Tạo mới tài khoản, tự động mã hóa mật khẩu trước khi lưu
        /// </summary>
        public void TaoMoi(SysDMNSD entity, string nguoiTao)
        {
            entity.MatKhau = HashPassword(entity.MatKhau);
            _unitOfWork.Repository<SysDMNSD>().Add(entity);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Đổi mật khẩu cho user
        /// </summary>
        public void DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            var user = _unitOfWork.Repository<SysDMNSD>().Find(u => u.TenDangNhap == tenDangNhap).FirstOrDefault();
            if (user != null)
            {
                user.MatKhau = HashPassword(matKhauMoi);
                _unitOfWork.Repository<SysDMNSD>().Update(user);
                _unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Hàm mã hóa mật khẩu sử dụng SHA-256
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}