using GPBH.Data.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GPBH.Business.Services
{
    public class ReportBanHangService
    {
        private readonly IServiceProvider _serviceProvider;

        public ReportBanHangService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public DataTable GetBaoCaoBanTheoKhachHang(string passport, string maHang, string maNgoaiTe, string maKhachHang, DateTime tuNgay, DateTime denNgay, string noiBan)
        //{
        //    var dt = new DataTable();
        //    string connectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;

        //    using (var conn = new SqlConnection(connectionString))
        //    {
        //        string query = @"
        //        SELECT *  FROM vw_BaoCaoBanTheoKhachHang
        //        WHERE 
        //            (@Passport IS NULL OR Passport = @Passport)
        //            AND (@Ma_hang IS NULL OR Ma_hang = @Ma_hang)
        //            AND (@Ten_khachhang IS NULL OR Ten_khachhang LIKE '%' + @Ten_khachhang + '%')
        //            AND (@Ma_ngoaite IS NULL OR Ma_tra_lai = @Ma_ngoaite)
        //            AND (@TuNgay IS NULL OR Ngay_ban >= @TuNgay)
        //            AND (@DenNgay IS NULL OR Ngay_ban <= @DenNgay)
        //            AND (@Noi_ban IS NULL OR Noi_ban = @Noi_ban)
        //        ORDER BY Ma_hang ASC";

        //        using (var cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Passport", string.IsNullOrEmpty(passport) ? (object)DBNull.Value : passport);
        //            cmd.Parameters.AddWithValue("@Ma_hang", string.IsNullOrEmpty(maHang) ? (object)DBNull.Value : maHang);
        //            cmd.Parameters.AddWithValue("@Ten_khachhang", string.IsNullOrEmpty(maKhachHang) ? (object)DBNull.Value : maKhachHang);
        //            cmd.Parameters.AddWithValue("@Ma_ngoaite", string.IsNullOrEmpty(maNgoaiTe) ? (object)DBNull.Value : maNgoaiTe);
        //            cmd.Parameters.AddWithValue("@DenNgay", denNgay == DateTime.MinValue ? (object)DBNull.Value : denNgay.Date);
        //            cmd.Parameters.AddWithValue("@TuNgay", tuNgay == DateTime.MinValue ? (object)DBNull.Value : tuNgay.Date);
        //            cmd.Parameters.AddWithValue("@Noi_ban", string.IsNullOrEmpty(noiBan) ? (object)DBNull.Value : noiBan);

        //            using (var da = new SqlDataAdapter(cmd))
        //            {
        //                da.Fill(dt);
        //            }
        //        }
        //    }
        //    return dt;
        //}

        public List<ViewBaoCaoKhacHang> GetViewBaoCaoBanTheoKhachHang(string passport, string maHang, string maNgoaiTe, string maKhachHang, DateTime tuNgay, DateTime denNgay, string noiBan)
        {
            var dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT *  FROM vw_BaoCaoBanTheoKhachHang
            WHERE 
                (@Passport IS NULL OR Passport = @Passport)
                AND (@Ma_hang IS NULL OR Ma_hang = @Ma_hang)
                AND (@Ten_khachhang IS NULL OR Ten_khachhang LIKE '%' + @Ten_khachhang + '%')
                AND (@Ma_ngoaite IS NULL OR Ma_tra_lai = @Ma_ngoaite)
                AND (@TuNgay IS NULL OR Ngay_ban >= @TuNgay)
                AND (@DenNgay IS NULL OR Ngay_ban <= @DenNgay)
                AND (@Noi_ban IS NULL OR Noi_ban = @Noi_ban)
            ORDER BY Ma_hang ASC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Passport", string.IsNullOrEmpty(passport) ? (object)DBNull.Value : passport);
                    cmd.Parameters.AddWithValue("@Ma_hang", string.IsNullOrEmpty(maHang) ? (object)DBNull.Value : maHang);
                    cmd.Parameters.AddWithValue("@Ten_khachhang", string.IsNullOrEmpty(maKhachHang) ? (object)DBNull.Value : maKhachHang);
                    cmd.Parameters.AddWithValue("@Ma_ngoaite", string.IsNullOrEmpty(maNgoaiTe) ? (object)DBNull.Value : maNgoaiTe);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay == DateTime.MinValue ? (object)DBNull.Value : denNgay.Date);
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay == DateTime.MinValue ? (object)DBNull.Value : tuNgay.Date);
                    cmd.Parameters.AddWithValue("@Noi_ban", string.IsNullOrEmpty(noiBan) ? (object)DBNull.Value : noiBan);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            // Map DataTable to List<ViewBaoCaoKhacHang>
            var list = new List<ViewBaoCaoKhacHang>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ViewBaoCaoKhacHang
                {
                    Noi_ban = row["Noi_ban"]?.ToString(),
                    Ten_khachhang = row["Ten_khachhang"]?.ToString(),
                    Passport = row["Passport"]?.ToString(),
                    Ngay_ban = row["Ngay_ban"] != DBNull.Value ? Convert.ToDateTime(row["Ngay_ban"]) : DateTime.MinValue,
                    Ma_phieu = row["Ma_phieu"]?.ToString(),
                    So_don_hang = row["So_don_hang"]?.ToString(),
                    Ten_hang = row["Ten_hang"]?.ToString(),
                    Ma_hang = row["Ma_hang"]?.ToString(),
                    So_luong = row["So_luong"] != DBNull.Value ? Convert.ToDecimal(row["So_luong"]) : 0,
                    Ma_ngoaite = row["Ma_ngoaite"]?.ToString(),
                    Thanh_tien = row["Thanh_tien"] != DBNull.Value ? Convert.ToDecimal(row["Thanh_tien"]) : 0,
                    Thanh_tien_vn = row["Thanh_tien_vn"] != DBNull.Value ? Convert.ToDecimal(row["Thanh_tien_vn"]) : 0,
                    Tong_tien_hang_nt = row["Tong_tien_hang_nt"] != DBNull.Value ? Convert.ToDecimal(row["Tong_tien_hang_nt"]) : 0,
                    Tong_nhan = row["Tong_nhan"] != DBNull.Value ? Convert.ToDecimal(row["Tong_nhan"]) : 0,
                    Tra_lai_nt = row["Tra_lai_nt"] != DBNull.Value ? Convert.ToDecimal(row["Tra_lai_nt"]) : 0,
                    Ma_tra_lai = row.Table.Columns.Contains("Ma_tra_lai") ? row["Ma_tra_lai"]?.ToString() : null,
                    Ty_gia = row["Ty_gia"] != DBNull.Value ? Convert.ToDecimal(row["Ty_gia"]) : 0
                };
                list.Add(item);
            }

            return list;
        }

        public DataTable ToDataTable(List<ViewBaoCaoKhacHang> list)
        {
            var dt = new DataTable();

            // Tạo các cột
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Noi_ban), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Ten_khachhang), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Passport), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Ngay_ban), typeof(DateTime));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.So_don_hang), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Ten_hang), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Ma_hang), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.So_luong), typeof(decimal));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Ma_ngoaite), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Thanh_tien), typeof(decimal));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Thanh_tien_vn), typeof(decimal));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Tong_tien_hang_nt), typeof(decimal));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Tong_nhan), typeof(decimal));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Tra_lai_nt), typeof(decimal));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Ma_tra_lai), typeof(string));
            dt.Columns.Add(nameof(ViewBaoCaoKhacHang.Ty_gia), typeof(decimal));

            // Thêm dữ liệu
            foreach (var item in list)
            {
                dt.Rows.Add(
                    item.Noi_ban,
                    item.Ten_khachhang,
                    item.Passport,
                    item.Ngay_ban,
                    item.So_don_hang,
                    item.Ten_hang,
                    item.Ma_hang,
                    item.So_luong,
                    item.Ma_ngoaite,
                    item.Thanh_tien,
                    item.Thanh_tien_vn,
                    item.Tong_tien_hang_nt,
                    item.Tong_nhan,
                    item.Tra_lai_nt,
                    item.Ma_tra_lai,
                    item.Ty_gia
                );
            }

            return dt;
        }
    }
}
