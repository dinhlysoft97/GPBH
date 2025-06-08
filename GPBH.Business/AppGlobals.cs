using GPBH.Data.Entities;
using System;

namespace GPBH.Business
{
    public static class AppGlobals
    {
        public static SysDMNSD CurrentUser { get; set; }
        public static DateTime TgDangNhap { get; set; }
        public static string MaCH {  get; set; }
        public static string MaQuay {  get; set; }
        public static string MaCa {  get; set; }
        public static string MaKho {  get; set; }
        public static SysDMCuaHang DMCuaHang {  get; set; }
    }
}
