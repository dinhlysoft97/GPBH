using GPBH.Business.Dtos;
using GPBH.Business.Exceptions;
using GPBH.Data.Audit;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPBH.Business.Services
{
    public class SysDinh_dang_formService
    {
        private readonly IServiceProvider _serviceProvider;

        public SysDinh_dang_formService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public List<GirdSysDinhDangFormDto> GetDinhDang(string maCH)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var sysDinhDangs = unitOfWork.Repository<SysDinh_dang_form>().Find(s => s.Ma_cua_hang == maCH)
                    .OrderBy(z => z.Stt).ToList();

                if (sysDinhDangs != null && sysDinhDangs.Any())
                {
                    // Convert to DTO
                    return sysDinhDangs.Select(s =>
                    {
                        var menu = unitOfWork.Repository<SysMenu>().Find(z => z.MenuId == s.MenuId).FirstOrDefault();
                        return new GirdSysDinhDangFormDto
                        {
                            Code_name = s.Code_name,
                            MenuId = s.MenuId,
                            MenuName = menu.MenuName,
                            Field_name = s.Field_name,
                            Field_type = s.Field_type,
                            Field_title = s.Field_title,
                            Field_order = s.Field_order,
                            Field_hide = s.Field_hide,
                            Field_width = s.Field_width,
                            Field_format = s.Field_format,
                            Default_sort = s.Default_sort,
                        };
                    }).ToList();
                }
                else
                {
                    var result = new List<GirdSysDinhDangFormDto>();
                    var menu = unitOfWork.Repository<SysMenu>().Find(s => s.MenuId == "DonHang").FirstOrDefault();

                    result.Add(new GirdSysDinhDangFormDto
                    {
                        Code_name = "X05",
                        MenuId = menu.MenuId,
                        MenuName = menu.MenuName,
                        Field_name = "Format_so_luong",
                        Field_type = "String",
                        Field_title = "Format số lượng",
                        Field_order = 0,
                        Field_hide = false,
                        Field_width = 0,
                        Field_format = "#,##0",
                        Default_sort = Sort.None,
                    });

                    result.Add(new GirdSysDinhDangFormDto
                    {
                        Code_name = "X05",
                        MenuId = menu.MenuId,
                        MenuName = menu.MenuName,
                        Field_name = "Format_gia_nt",
                        Field_type = "String",
                        Field_title = "Format giá ngoại tệ",
                        Field_order = 0,
                        Field_hide = false,
                        Field_width = 0,
                        Field_format = "#,##0.00",
                        Default_sort = Sort.None,
                    });

                    result.Add(new GirdSysDinhDangFormDto
                    {
                        Code_name = "X05",
                        MenuId = menu.MenuId,
                        MenuName = menu.MenuName,
                        Field_name = "Format_gia",
                        Field_type = "String",
                        Field_title = "Format Giá",
                        Field_order = 0,
                        Field_hide = false,
                        Field_width = 0,
                        Field_format = "#,##0",
                        Default_sort = Sort.None,
                    });

                    result.Add(new GirdSysDinhDangFormDto
                    {
                        Code_name = "X05",
                        MenuId = menu.MenuId,
                        MenuName = menu.MenuName,
                        Field_name = "Format_tien_nt",
                        Field_type = "String",
                        Field_title = "Format tiền ngoại tệ",
                        Field_order = 0,
                        Field_hide = false,
                        Field_width = 0,
                        Field_format = "#,##0.000",
                        Default_sort = Sort.None,
                    });

                    result.Add(new GirdSysDinhDangFormDto
                    {
                        Code_name = "X05",
                        MenuId = menu.MenuId,
                        MenuName = menu.MenuName,
                        Field_name = "Format_tien",
                        Field_type = "String",
                        Field_title = "Format tiền",
                        Field_order = 0,
                        Field_hide = false,
                        Field_width = 0,
                        Field_format = "#,##0",
                        Default_sort = Sort.None,
                    });

                    return result;
                }
            }
        }

        // Mai mốt cần lấy định dạng của từng chức năng thì bỏ comment đoạn này
        //public List<GirdSysDinhDangFormDto> GetDinhDang(string maCH, string codeName)
        //{
        //    using (var scope = _serviceProvider.CreateScope())
        //    {
        //        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        //        var sysDinhDangs = unitOfWork.Repository<SysDinh_dang_form>().Find(s => s.Ma_cua_hang == maCH)
        //            .OrderBy(z => z.Stt).ToList();

        //        if (sysDinhDangs != null && sysDinhDangs.Any())
        //        {
        //            // Convert to DTO
        //            return sysDinhDangs.Select(s =>
        //            {
        //                var menu = unitOfWork.Repository<SysMenu>().Find(z => z.MenuId == s.MenuId).FirstOrDefault();
        //                return new GirdSysDinhDangFormDto
        //                {
        //                    Code_name = s.Code_name,
        //                    MenuId = s.MenuId,
        //                    MenuName = menu.MenuName,
        //                    Field_name = s.Field_name,
        //                    Field_type = s.Field_type,
        //                    Field_title = s.Field_title,
        //                    Field_order = s.Field_order,
        //                    Field_hide = s.Field_hide,
        //                    Field_width = s.Field_width,
        //                    Field_format = s.Field_format,
        //                    Default_sort = s.Default_sort,
        //                    Ten_ban = s.Ten_ban
        //                };
        //            }).ToList();
        //        }
        //        else
        //        {
        //            var result = new List<GirdSysDinhDangFormDto>();
        //            var baseAuditableProps = new HashSet<string>(
        //               typeof(BaseAuditableEntity)
        //                   .GetProperties()
        //                   .Select(p => p.Name)
        //            );

        //            var xph5Props = typeof(XPH5).GetProperties()
        //                .Where(z =>
        //                    !baseAuditableProps.Contains(z.Name) &&
        //                    !z.PropertyType.IsClass);

        //            var menu = unitOfWork.Repository<SysMenu>().Find(s => s.MenuId == "DonHang").FirstOrDefault();
        //            foreach (var prop in xph5Props)
        //            {
        //                Type type = prop.PropertyType;
        //                var type_name = string.Empty;
        //                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        //                {
        //                    // Lấy kiểu thực sự bên trong Nullable<>
        //                    var underlyingType = Nullable.GetUnderlyingType(type);
        //                    type_name = underlyingType.Name;
        //                }
        //                else
        //                {
        //                    type_name = type.Name;
        //                }

        //                result.Add(new GirdSysDinhDangFormDto
        //                {
        //                    Code_name = "X05",
        //                    MenuId = menu.MenuId,
        //                    MenuName = menu.MenuName,
        //                    Field_name = prop.Name,
        //                    Field_type = type_name,
        //                    Field_title = prop.Name,
        //                    Field_order = 0,
        //                    Field_hide = false,
        //                    Field_width = 100,
        //                    Field_format = string.Empty,
        //                    Default_sort = Sort.None,
        //                    Ten_ban = "XPH5"
        //                });
        //            }

        //            // XCT5
        //            var xct5Props = typeof(XCT5).GetProperties()
        //                .Where(z =>
        //                    !baseAuditableProps.Contains(z.Name) &&
        //                    !z.PropertyType.IsClass);

        //            foreach (var prop in xct5Props)
        //            {
        //                Type type = prop.PropertyType;
        //                var type_name = string.Empty;
        //                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        //                {
        //                    // Lấy kiểu thực sự bên trong Nullable<>
        //                    var underlyingType = Nullable.GetUnderlyingType(type);
        //                    type_name = underlyingType.Name;
        //                }
        //                else
        //                {
        //                    type_name = type.Name;
        //                }

        //                result.Add(new GirdSysDinhDangFormDto
        //                {
        //                    Code_name = "X05",
        //                    MenuId = menu.MenuId,
        //                    MenuName = menu.MenuName,
        //                    Field_name = prop.Name,
        //                    Field_type = type_name,
        //                    Field_title = prop.Name,
        //                    Field_order = 0,
        //                    Field_hide = false,
        //                    Field_width = 100,
        //                    Field_format = string.Empty,
        //                    Default_sort = Sort.None,
        //                    Ten_ban = "XCT5"
        //                });
        //            }

        //            return result;
        //        }
        //    }
        //}

        public void LuuDinhDang(List<GirdSysDinhDangFormDto> dinhDangDtos, string maCH)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var sysDinhDangRepo = unitOfWork.Repository<SysDinh_dang_form>();
                try
                {
                    unitOfWork.BeginTransaction();
                    foreach (var dto in dinhDangDtos)
                    {
                        var existing = sysDinhDangRepo
                            .Find(x => x.Ma_cua_hang == maCH
                                    && x.Code_name == dto.Code_name
                                    && x.MenuId == dto.MenuId
                                    && x.Field_name == dto.Field_name)
                            .FirstOrDefault();

                        if (existing != null)
                        {
                            // Update existing
                            existing.Field_type = dto.Field_type;
                            existing.Field_title = dto.Field_title;
                            existing.Field_order = dto.Field_order;
                            existing.Field_hide = dto.Field_hide;
                            existing.Field_width = dto.Field_width;
                            existing.Field_format = dto.Field_format;
                            existing.Default_sort = dto.Default_sort;
                            sysDinhDangRepo.Update(existing);
                        }
                        else
                        {
                            // Insert new
                            var entity = new SysDinh_dang_form
                            {
                                Stt = dto.Stt,
                                Ma_cua_hang = maCH,
                                Code_name = dto.Code_name,
                                MenuId = dto.MenuId,
                                Field_name = dto.Field_name,
                                Field_type = dto.Field_type,
                                Field_title = dto.Field_title,
                                Field_order = dto.Field_order,
                                Field_hide = dto.Field_hide,
                                Field_width = dto.Field_width,
                                Field_format = dto.Field_format,
                                Default_sort = dto.Default_sort,
                            };
                            sysDinhDangRepo.Add(entity);
                        }

                        // update thêm Format trong SysDMCuaHang
                        var sysDMCuaHangRepo = unitOfWork.Repository<SysDMCuaHang>();
                        var sysDMCuaHang = sysDMCuaHangRepo.Find(x => x.Ma_cua_hang == maCH).FirstOrDefault();
                        if (sysDMCuaHang != null)
                        {
                            switch (dto.Field_name)
                            {
                                case "Format_so_luong":
                                    sysDMCuaHang.Format_so_luong = dto.Field_format;
                                    break;
                                case "Format_gia_nt":
                                    sysDMCuaHang.Format_gia_nt = dto.Field_format;
                                    break;
                                case "Format_gia":
                                    sysDMCuaHang.Format_gia = dto.Field_format;
                                    break;
                                case "Format_tien_nt":
                                    sysDMCuaHang.Format_tien_nt = dto.Field_format;
                                    break;
                                case "Format_tien":
                                    sysDMCuaHang.Format_tien = dto.Field_format;
                                    break;
                            }
                            sysDMCuaHangRepo.Update(sysDMCuaHang);
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
