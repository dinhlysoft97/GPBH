using System.Runtime.Remoting.Proxies;

namespace GPBH.Data.Entities
{
    public class SystemSetting
    {
        public string Ma_cua_hang { get; set; }
        public string Key { get; set; }
        public string Ten { get; set; }
        public string GiaTri { get; set; }
        public string Mota { get; set; }
        public SysDMCuaHang SysDMCuaHang { get; set; } // Thông tin cửa hàng liên kết
    }
}