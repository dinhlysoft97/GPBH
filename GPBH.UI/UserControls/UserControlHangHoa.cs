using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlHangHoa : UserControl
    {
        private readonly DMHHService _dmHHService;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;
        private List<GirdSysDinhDangFormDto> _girdSysDinhDangForms;
        public UserControlHangHoa
            (
            DMHHService dmHHService,
            SysDinh_dang_formService sysDinh_Dang_FormService
            )
        {
            InitializeComponent();
            _dmHHService = dmHHService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            _girdSysDinhDangForms = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "HangHoa").data.ToList();
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetUpUI()
        {
            dataGridViewX1.ApplyColumnConfig(_girdSysDinhDangForms);
        }

        private void LoadData()
        {
            var hhList = _dmHHService.GetAllGrid();
            var dataSort = hhList.ApplySortSystemDinhDang(_girdSysDinhDangForms);
            DataGridViewFilterHelperV2.ApplyFilter(dataGridViewX1, dataSort, _girdSysDinhDangForms);
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
