namespace GPBH.Data.Entities
{
    public class SysMenu
    {
        public int Id { get; set; }

        // Khóa định danh của menu, có thể là mã hoặc tên duy nhất
        public string Key { get; set; }

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
    }

    public enum SysMenuType
    {
        Document = 1, // Chứng từ
        Report = 2,   // Báo cáo
        Category = 3, // Danh mục
    }
}
