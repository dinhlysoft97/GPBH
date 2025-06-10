using System.Collections.Generic;

namespace GPBH.Data.Entities
{
    public class SysMenu
    {
        // Khóa định danh của menu, có thể là mã hoặc tên duy nhất
        public string MenuId { get; set; }

        // Tên hiển thị trên menu
        public string MenuName { get; set; }

        // Loại menu: 1 = chứng từ, 2 = danh mục, 3 = báo cáo
        public SysMenuType Type { get; set; }

        // Có phải báo cáo không
        public bool Report { get; set; }

        // Có phải quyền cơ bản không
        public bool BasicRight { get; set; }

        // Icon (tên file hoặc mã biểu tượng)
        public string Picture { get; set; }

        // Chỉ hiển thị khi Active = 1
        public bool Active { get; set; }
        // Thứ tự sắp xếp
        public int Stt { get; set; }

        public virtual List<SysPhanQuyen> SysPhanQuyens { get; set; } // Danh sách phân quyền liên kết
    }

    public enum SysMenuType
    {
        Document = 1, // Chứng từ
        Report = 2,   // Báo cáo
        Category = 3, // Danh mục
        Setting = 4, // Cài đặt
    }
}
