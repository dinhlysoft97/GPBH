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
    public partial class UserControlCa : UserControl
    {
        private readonly DMcaService _dMcaService;
        private readonly SysDinh_dang_formService _sysDinh_dang_formService;
        private List<GirdSysDinhDangFormDto> _girdSysDinhDangForms;
        public UserControlCa(DMcaService dMcaService, SysDinh_dang_formService sysDinh_dang_formService)
        {
            InitializeComponent();
            _dMcaService = dMcaService;
            _sysDinh_dang_formService = sysDinh_dang_formService;
            _girdSysDinhDangForms = _sysDinh_dang_formService.GetDinhDang(AppGlobals.MaCH, "Ca").data.ToList();
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
        }

        private void SetUpUI()
        {
            dataGridViewX1.ApplyColumnConfig(_girdSysDinhDangForms);
        }

        private void LoadData()
        {
            var caList = _dMcaService.GetAll();
            var dataSort = caList.ApplySortSystemDinhDang(_girdSysDinhDangForms);
            DataGridViewFilterHelperV2.ApplyFilter(dataGridViewX1, dataSort, _girdSysDinhDangForms);
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string menuName = "Ca";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            ExportHelper.ExportGridToExcel(dataGridViewX1, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), isIgnoreRowFirst: true);
        }
    }
}
