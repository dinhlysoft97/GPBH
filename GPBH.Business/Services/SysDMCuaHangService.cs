using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using GPBH.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using GPBH.Business.Dtos;
using GPBH.Data.Configurations;
using System.Collections.Generic;
using Mapster;
using GPBH.Business.Exceptions;

namespace GPBH.Business.Services
{
    public class SysDMCuaHangService
    {
        private readonly IServiceProvider _serviceProvider;

        public SysDMCuaHangService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<SysDMCuaHang> GetAll()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<SysDMCuaHang>()
                .GetAll().ToList();
            }
        }


        public SysDMCuaHang GetByMaCuaHang(string maCH)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<SysDMCuaHang>()
                .Find(u => u.Ma_cua_hang == maCH).FirstOrDefault();
            }
        }

        public TyGiaNT GetTyGiaByMaCuaHang(string maCuaHang)
        {
            // Tạo scope mới, lấy UnitOfWork mới mỗi lần gọi
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var cuaHang = unitOfWork.Repository<SysDMCuaHang>()
                    .Find(z => z.Ma_cua_hang == maCuaHang)
                    .FirstOrDefault();
                if (cuaHang == null) return null;

                // Get tỷ giá ngoại tệ nhỏ hơn hoặc bằng ngày hiện tại và order by theo ngày gần nhất.
                if (!string.IsNullOrEmpty(cuaHang.Ma_nt))
                {
                    var dmtgService = scope.ServiceProvider.GetRequiredService<DMTGService>();
                    var tyGiaNT = dmtgService.GetTyGiaByMaNT(cuaHang.Ma_nt);
                    if (tyGiaNT != null)
                    {
                        return tyGiaNT;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách tham số hệ thống theo mã cửa hàng.
        /// </summary>
        /// <param name="maCH"></param>
        /// <returns></returns>
        public List<GirdSystemSettingDto> GetThamSo(string maCH)
        {
            var listKey = new string[]
            {
               nameof(SysDMCuaHang.Han_muc_tm),
               nameof(SysDMCuaHang.Ma_cqt),
               nameof(SysDMCuaHang.Ma_nt),

            };
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var systemSettings = unitOfWork.Repository<SystemSetting>()
                    .Find(s => s.Ma_cua_hang == maCH && listKey.Contains(s.Key))
                    .ToList();
                if (systemSettings.Any())
                {
                    return systemSettings.Adapt<List<GirdSystemSettingDto>>();
                }
                else
                {
                    return new List<GirdSystemSettingDto>()
                    {
                        new GirdSystemSettingDto
                        {
                            Key = nameof(SysDMCuaHang.Han_muc_tm),
                            Ten = "Hạn mức giao dịch tiền mặt",
                            GiaTri = "15000000",
                            Mota = "Là hạn mức áp dụng khi khách hàng thanh toán tiền mặt, quy đổi ra VND",
                        },
                        new GirdSystemSettingDto
                        {
                            Key = nameof(SysDMCuaHang.Ma_cqt),
                            Ten = "Mã cơ quan thuế",
                            GiaTri = "",
                            Mota = "Mã cơ quan thuế",
                        },
                        new GirdSystemSettingDto
                        {
                            Key = nameof(SysDMCuaHang.Ma_nt),
                            Ten = "Loại tiền áp dụng khi bán hàng",
                            GiaTri = "USD",
                            Mota = "Là mã tiền tệ được áp dụng quy đổi chuẩn khi bán hàng, các loại tiền thanh toán sẽ được quy đổi theo tỷ giá về loại tiền này",
                        }
                    };
                }
            }
        }

        /// <summary>
        /// Lưu các tham số hệ thống cho cửa hàng.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="maCH"></param>
        public void LuuThamSo(List<GirdSystemSettingDto> data, string maCH)
        {
            var entities = data.Adapt<List<SystemSetting>>();
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var repo = unitOfWork.Repository<SystemSetting>();
                try
                {
                    unitOfWork.BeginTransaction();

                    foreach (var entity in entities)
                    {
                        entity.Ma_cua_hang = maCH; // Đảm bảo mã cửa hàng được gán
                        var existing = repo.Find(x => x.Ma_cua_hang == entity.Ma_cua_hang && x.Key == entity.Key).FirstOrDefault();
                        if (existing != null)
                        {
                            existing.GiaTri = entity.GiaTri;
                            existing.Mota = entity.Mota;
                            repo.Update(existing);
                        }
                        else
                        {
                            repo.Add(entity);
                        }
                    }

                    // Update qua đối tượng SysDMCuaHang
                    var cuaHang = unitOfWork.Repository<SysDMCuaHang>()
                        .Find(u => u.Ma_cua_hang == maCH).FirstOrDefault();
                    if (cuaHang != null)
                    {
                        decimal.TryParse(entities.FirstOrDefault(x => x.Key == nameof(SysDMCuaHang.Han_muc_tm)).GiaTri, out decimal hanMucTm);
                        cuaHang.Han_muc_tm = hanMucTm;
                        cuaHang.Ma_cqt = entities.FirstOrDefault(x => x.Key == nameof(SysDMCuaHang.Ma_cqt))?.GiaTri ?? cuaHang.Ma_cqt;
                        cuaHang.Ma_nt = entities.FirstOrDefault(x => x.Key == nameof(SysDMCuaHang.Ma_nt))?.GiaTri ?? cuaHang.Ma_nt;
                        unitOfWork.Repository<SysDMCuaHang>().Update(cuaHang);

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
