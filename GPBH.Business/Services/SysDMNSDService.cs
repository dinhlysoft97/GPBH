using GPBH.Business.Dtos;
using GPBH.Business.Exceptions;
using GPBH.Data;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GPBH.Business
{
    public class SysDMNSDService
    {
        private readonly IServiceProvider _serviceProvider;

        public SysDMNSDService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Lấy tất cả người dùng trong hệ thống
        /// </summary>
        /// <returns></returns>
        public List<GirdNguoiSuDungDto> GellAll()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var users = unitOfWork.Repository<SysDMNSD>().GetAll();
                var dtos = users.Adapt<List<GirdNguoiSuDungDto>>();

                int stt = 1;
                dtos.ForEach(dto =>
                {
                    dto.Stt = stt++;
                });

                return dtos;
            }
        }

        /// <summary>
        /// Đăng nhập hệ thống với mật khẩu đã mã hóa (SHA-256)
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <param name="matKhau">Mật khẩu plain text</param>
        /// <returns>SysDMNSD nếu thành công, null nếu thất bại</returns>
        public SysDMNSD DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            string matKhauHash = HashPassword(matKhau);
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var user = unitOfWork.Repository<SysDMNSD>()
                .Find(u => u.TenDangNhap == tenDangNhap && u.MatKhau == matKhauHash && !u.Ksd).FirstOrDefault();
                AppDbContext.CurrentUserName = tenDangNhap;
                return user;
            }
        }



        /// <summary>
        /// Tạo mới tài khoản, tự động mã hóa mật khẩu trước khi lưu
        /// </summary>
        public SysDMNSD TaoMoi(SysDMNSD entity)
        {
            entity.MatKhau = HashPassword(entity.MatKhau);
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                unitOfWork.Repository<SysDMNSD>().Add(entity);
                unitOfWork.SaveChanges();

                return entity;
            }
        }

        public void Sua(SysDMNSD entity)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var existingUser = unitOfWork.Repository<SysDMNSD>().Find(u => u.TenDangNhap == entity.TenDangNhap).FirstOrDefault();
                if (existingUser != null)
                {
                    existingUser.TenDayDu = entity.TenDayDu;
                    existingUser.IsAdmin = entity.IsAdmin;
                    existingUser.Ksd = entity.Ksd;
                    existingUser.CapLaiQuyen = entity.CapLaiQuyen;
                    unitOfWork.Repository<SysDMNSD>().Update(existingUser);
                    unitOfWork.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Đổi mật khẩu cho user
        /// </summary>
        public void DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var user = unitOfWork.Repository<SysDMNSD>().Find(u => u.TenDangNhap == tenDangNhap).FirstOrDefault();
                if (user != null)
                {
                    user.MatKhau = HashPassword(matKhauMoi);
                    unitOfWork.Repository<SysDMNSD>().Update(user);
                    unitOfWork.SaveChanges();
                }
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

        /// <summary>
        /// Tìm kiếm người dùng theo từ khóa, lọc tất cả các trường trong entity
        /// </summary>
        /// <param name="value">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách GirdNguoiSuDungDto phù hợp</returns>
        public List<GirdNguoiSuDungDto> TiemKiem(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return GellAll();

            value = value.ToLowerInvariant();

            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var users = unitOfWork.Repository<SysDMNSD>().GetAll()
                    .Where(u =>
                        (u.TenDangNhap != null && u.TenDangNhap.ToLower().Contains(value)) ||
                        (u.TenDayDu != null && u.TenDayDu.ToLower().Contains(value)) ||
                        u.IsAdmin.ToString().ToLower().Contains(value) ||
                        u.Ksd.ToString().ToLower().Contains(value) ||
                        u.CapLaiQuyen.ToString().ToLower().Contains(value) ||
                        (u.Nguoi_tao != null && u.Nguoi_tao.ToLower().Contains(value)) ||
                        (u.Nguoi_sua != null && u.Nguoi_sua.ToLower().Contains(value)) ||
                        (u.Ngay_tao.HasValue && u.Ngay_tao.Value.ToString("yyyy-MM-dd HH:mm:ss").Contains(value)) ||
                        (u.Ngay_sua.HasValue && u.Ngay_sua.Value.ToString("yyyy-MM-dd HH:mm:ss").Contains(value))
                    )
                    .ToList();

                var dtos = users.Adapt<List<GirdNguoiSuDungDto>>();
                return dtos;
            }
        }

        /// <summary>
        /// Kiểm tra tên đăng nhập đã tồn tại trong hệ thống hay chưa
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập cần kiểm tra</param>
        /// <returns>True nếu đã tồn tại, False nếu chưa</returns>
        public bool CheckTrungTenDangNhap(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                return false;

            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var exists = unitOfWork.Repository<SysDMNSD>()
                    .Find(u => u.TenDangNhap == tenDangNhap)
                    .Any();
                return exists;
            }
        }
        /// <summary>
        /// Lấy thông tin người dùng theo tên đăng nhập
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <returns>SysDMNSD nếu tìm thấy, null nếu không</returns>
        public SysDMNSD GetByTenDangNhap(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                return null;

            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var user = unitOfWork.Repository<SysDMNSD>()
                    .Find(u => u.TenDangNhap == tenDangNhap)
                    .FirstOrDefault();
                return user;
            }
        }

        public List<GirdPhanQuyenDto> GetDataPhanQuyen(string tenDangNhap)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var phanQuyens = unitOfWork.Repository<SysPhanQuyen>().Find(z => z.Ten_dang_nhap == tenDangNhap).ToList();
                if (phanQuyens.Count > 0)
                {
                    var data = phanQuyens.Adapt<List<GirdPhanQuyenDto>>();
                    data.ForEach(dto => dto.MenuName = phanQuyens.Find(z => z.MenuId == dto.MenuId).SysMenu.MenuName);
                    return data;
                }
                else
                {
                    var menus = unitOfWork.Repository<SysMenu>().GetAll().ToList();
                    var data = menus.Adapt<List<GirdPhanQuyenDto>>();
                    return data;
                }
            }
        }

        /// <summary>
        /// Phân quyền cho người dùng
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tenDangNhap"></param>
        /// <exception cref="BadRequestException"></exception>
        public void PhanQuyen(IList<GirdPhanQuyenDto> data, string tenDangNhap)
        {
            var entitys = data.Adapt<List<SysPhanQuyen>>();
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                try
                {
                    unitOfWork.BeginTransaction();

                    foreach (var item in entitys)
                    {
                        item.Ten_dang_nhap = tenDangNhap;
                        var repo = unitOfWork.Repository<SysPhanQuyen>();
                        var existing = repo.Find(x => x.MenuId == item.MenuId && x.Ten_dang_nhap == tenDangNhap).FirstOrDefault();
                        if (existing != null)
                        {
                            existing.Xem = item.Xem;
                            existing.Them = item.Them;
                            existing.Sua = item.Sua;
                            existing.Xoa = item.Xoa;
                            existing.In = item.In;
                            existing.Excel = item.Excel;
                            repo.Update(existing);
                        }
                        else
                        {
                            repo.Add(item);
                        }
                    }

                    unitOfWork.SaveChanges();
                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw new BadRequestException(ex.Message);
                }

            }
        }
    }
}