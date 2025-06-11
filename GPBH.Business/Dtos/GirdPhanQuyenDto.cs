namespace GPBH.Business.Dtos
{
    public class GirdPhanQuyenDto
    {
        public int Stt { get; set; }

        // ID menu (PK)
        public string MenuId { get; set; }

        public string MenuName { get; set; }

        // Được xem
        public bool? Xem { get; set; }

        // Được thêm mới
        public bool? Them { get; set; }

        // Được sửa
        public bool? Sua { get; set; }

        // Được xóa
        public bool? Xoa { get; set; }

        // Được in
        public bool? In { get; set; }

        // Được xuất excel
        public bool? Excel { get; set; }
    }
}
