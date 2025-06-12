using System;

namespace GPBH.Data.Entities
{
    /// <summary>
    /// Định dạng hiển thị trường dữ liệu trên form theo từng chức năng.
    /// </summary>
    public class SysDinh_dang_form
    {
        /// <summary>
        /// Mã cửa hàng.
        /// </summary>
        public string Ma_cua_hang { get; set; }

        /// <summary>
        /// Mã chức năng. Đối với danh mục là tên cột mã (ví dụ: Khách hàng là Passport),
        /// đối với chứng từ là mã chứng từ (ví dụ: Đơn hàng là X05).
        /// </summary>
        public string Code_name { get; set; }

        /// <summary>
        /// Menuid. Là menuid của báo cáo.
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// Tên trường dữ liệu.
        /// </summary>
        public string Field_name { get; set; }

        /// <summary>
        /// Kiểu dữ liệu hiển thị.
        /// </summary>
        public string Field_type { get; set; }

        /// <summary>
        /// Tiêu đề trường hiển thị.
        /// </summary>
        public string Field_title { get; set; }

        /// <summary>
        /// Thứ tự sắp xếp các trường hiển thị.
        /// </summary>
        public int Field_order { get; set; }

        /// <summary>
        /// Trường không hiển thị.
        /// </summary>
        public bool Field_hide { get; set; }

        /// <summary>
        /// Độ rộng cột hiển thị.
        /// </summary>
        public int Field_width { get; set; }

        /// <summary>
        /// Định dạng hiển thị (theo tên cột Format trong sysDMCuaHang hoặc nhập đặc thù).
        /// </summary>
        public string Field_format { get; set; }

        /// <summary>
        /// Sắp xếp mặc định: 0 - không sắp xếp, 1 - tăng, 2 - giảm.
        /// </summary>
        public Sort Default_sort { get; set; }

        /// <summary>
        /// Tên bản định dạng.
        /// </summary>
        public string Ten_ban { get; set; }

        /// <summary>
        /// Số thứ tự của bản định dạng trong danh sách.
        /// </summary>
        public int Stt { get; set; }
    }

    public enum Sort
    {
        None = 0,
        Ascending = 1,
        Descending = 2
    }
}