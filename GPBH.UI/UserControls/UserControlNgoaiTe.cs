using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlNgoaiTe : UserControl
    {
        private readonly DMNTService _dmNTService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;
        private List<GirdSysDinhDangFormDto> _girdSysDinhDangForms;
        public UserControlNgoaiTe(DMNTService dMNTService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _dmNTService = dMNTService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            _girdSysDinhDangForms = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "NgoaiTe").data.ToList();
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
            var ngoaiteList = _dmNTService.GetAllGrid();
            var dataSort = ngoaiteList.ApplySortSystemDinhDang(_girdSysDinhDangForms);
            DataGridViewFilterHelperV2.ApplyFilter(dataGridViewX1, dataSort, _girdSysDinhDangForms);
        }

        private void dataGridViewX1_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, System.EventArgs e)
        {
            string menuName = "NgoaiTe";
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
