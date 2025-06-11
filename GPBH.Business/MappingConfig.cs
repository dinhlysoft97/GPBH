using GPBH.Business.Dtos;
using GPBH.Data.Entities;
using Mapster;

namespace GPBH.Business
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<SysPhanQuyen, GirdPhanQuyenDto>()
            //    .Map(dest => dest.Ten_dang_nhap, src => src.Ten_dang_nhap);

            config.NewConfig<SysPhanQuyen, GirdPhanQuyenDto>()
                .Map(dest => dest.MenuName, src => src.SysMenu.MenuName);
            
        }
    }
}
