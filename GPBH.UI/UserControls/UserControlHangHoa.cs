using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlHangHoa : UserControl
    {
        private readonly DMHHService _dmHHService;
        private List<GirdSysDinhDangFormDto> SysDinhDangs;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;
        public UserControlHangHoa
            (
            DMHHService dmHHService,
            SysDinh_dang_formService sysDinh_Dang_FormService
            )
        {
            InitializeComponent();
            _dmHHService = dmHHService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            SysDinhDangs = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            SetUpUI();
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                dataGridViewX1.SetGirdReadOnly();
            };
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetUpUI()
        {
            // Format cột
            //dataGridViewX1.SetFormat("Chieu_dai", GetFormat("Format_so_luong"));
            //dataGridViewX1.SetFormat("Trong_luong", GetFormat("Format_so_luong"));
            //dataGridViewX1.SetFormat("Chieu_cao", GetFormat("Format_so_luong"));
        }

        private void LoadData()
        {
            var hhList = _dmHHService.GetAllGrid();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, hhList);
        }

        private string GetFormat(string column)
        {
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }

        private void dataGridViewX1_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, System.EventArgs e)
        {
            string menuName = "HangHoa";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, menuName).data.Where(z => !z.Field_hide).OrderBy(z => z.Field_order).ToList();
            var data = dataGridViewX1.DataSource as BindingList<GridHangHoa>;
            ExportHelper.ExportToExcel(data, fields, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), isIgnoreRowFirst: true);
        }
    }
}
