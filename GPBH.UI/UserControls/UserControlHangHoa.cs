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
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetUpUI()
        {
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "HangHoa").data.ToList();
            dataGridViewX1.ApplyColumnConfig(fields);
        }

        private void LoadData()
        {
            var hhList = _dmHHService.GetAllGrid();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, hhList);
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

            ExportHelper.ExportGridToExcel(dataGridViewX1, "HangHoa_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), isIgnoreRowFirst: true);
        }
    }
}
