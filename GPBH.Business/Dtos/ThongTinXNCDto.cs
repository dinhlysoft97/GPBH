using System;

namespace GPBH.Business.Dtos
{
    public class ThongTinXNCDto
    {
        public DateTime? NgayCap { get; set; }
        public DateTime? HetHan { get; set; }
        public string SoHieu { get; set; }
        public string TauBay { get; set; }
        // Hạn mức
        public decimal? Han_muc { get; set; }
    }
}
