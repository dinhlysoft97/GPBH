using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.Services
{
    public static class ReportBanHangService
    {
        public static DataTable GetBaoCaoBanTheoKhachHang(string passport, string maHang, string maNgoaiTe, string maKhachHang, DateTime tuNgay, DateTime denNgay)
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
                ORDER BY Ma_hang ASC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Passport", string.IsNullOrEmpty(passport) ? (object)DBNull.Value : passport);
                    cmd.Parameters.AddWithValue("@Ma_hang", string.IsNullOrEmpty(maHang) ? (object)DBNull.Value : maHang);
                    cmd.Parameters.AddWithValue("@Ten_khachhang", string.IsNullOrEmpty(maKhachHang) ? (object)DBNull.Value : maKhachHang);
                    cmd.Parameters.AddWithValue("@Ma_ngoaite", string.IsNullOrEmpty(maNgoaiTe) ? (object)DBNull.Value : maNgoaiTe);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay == DateTime.MinValue ? (object)DBNull.Value : denNgay.Date);
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay == DateTime.MinValue ? (object)DBNull.Value : tuNgay.Date);
                    
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    foreach (DataColumn col in dt.Columns)
                    {
                        System.Diagnostics.Debug.WriteLine(col.ColumnName);
                    }
                }
            }
            return dt;
        }
    }
}
