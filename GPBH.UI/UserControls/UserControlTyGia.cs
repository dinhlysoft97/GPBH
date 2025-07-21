using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlTyGia : UserControl
    {
        private readonly DMTGService _dmTGService;
        private List<GirdSysDinhDangFormDto> SysDinhDangs;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;
        private string DateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        public UserControlTyGia(DMTGService dMTGService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _dmTGService = dMTGService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            SysDinhDangs = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            SetUpUI();
            LoadData();
        }

        private void SetUpUI()
        {
            // Format cột
            dataGridViewX1.SetFormat("Ty_gia", GetFormat("Format_tien"));
            dataGridViewX1.SetFormat("Ty_gia", DateFormat);
        }

        private string GetFormat(string column)
        {
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }

        private void LoadData()
        {
            var tygiaList = _dmTGService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, tygiaList);
        }

        private void dataGridViewX1_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }
    }
}
