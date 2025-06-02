namespace GPBH.Business.DTO
{
    public class SysDMNSDDto
    {
        // Tên đăng nhập (Primary Key)
        public string TenDangNhap { get; set; }

        // Tên đầy đủ
        public string TenDayDu { get; set; }

        // Mật khẩu
        public string MatKhau { get; set; }

        // Là admin
        public bool IsAdmin { get; set; }

        // =1 mới cho đăng nhập
        public bool Ksd { get; set; }
    }
}
