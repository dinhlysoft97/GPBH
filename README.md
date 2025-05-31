# GPBH - Mẫu Dự Án .NET Framework 4.8 (WinForms, Entity Framework, Crystal Report)

## Cấu trúc dự án

- **GPBH.Data**: Quản lý DbContext, Entities, Migration.
- **GPBH.Business**: Chứa các class xử lý nghiệp vụ.
- **GPBH.UI**: WinForms, giao diện, sử dụng Crystal Report và các control (DotNetBar nếu cần).

## Hướng dẫn khởi tạo DB với Entity Framework

1. Mở Package Manager Console, chọn GPBH.Data là Startup Project.
2. Chạy lần lượt:
   ```
   Enable-Migrations
   Add-Migration InitialCreate
   Update-Database
   ```
3. Crystal Report: Add file report vào UI, kéo CrystalReportViewer lên form.

## Ghi chú
