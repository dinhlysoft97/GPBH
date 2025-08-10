using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class QuetMaVach : Office2007Form
    {
        private DMHHService _dMHHService;
        private List<GirdSysDinhDangFormDto> SysDinhDangs;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;

        public string MaHH { get; set; }
        public double SoLuong { get; set; }
        public QuetMaVach(DMHHService dMHHService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            _dMHHService = dMHHService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            SysDinhDangs = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            InitializeComponent();
            this.KeyPreview = true;
            lbThongBao.Visible = false;
            KeyDown += QuetMaVach_KeyDown;

            txtSL.DisplayFormat(GetFormat("Format_so_luong"));
        }

        private void QuetMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.ShowForm<HuongDanSuDung>();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                var maVach = this.txtMaVach.Text.Trim();
                var hh = _dMHHService.GetByMaHH(maVach);
                // tìm mã vạch
                if (hh == null)
                {
                    lbThongBao.Text = "Không tìm thấy mã vạch: " + maVach;
                    lbThongBao.Visible = true;
                }
                else
                {
                    lbThongBao.Visible = false;
                    MaHH = maVach;
                    SoLuong = txtSL.Value == 0 ? 1 : txtSL.Value;
                    Close();
                }
            }
        }
        private string GetFormat(string column)
        {
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }
    }
}
