using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.Dtos
{
    public class GridQuocGia
    {
        public string Quoc_gia { get; set; } // Mã quốc gia 
        public string Ten_Quoc_gia { get; set; } // Ten quốc gia 
        public bool Ksd { get; set; } // Sử dụng
    }
}
