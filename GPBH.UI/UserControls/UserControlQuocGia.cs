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
    public partial class UserControlQuocGia : UserControl
    {
        private readonly DMQGService _dmQGService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;
        private List<GirdSysDinhDangFormDto> _girdSysDinhDangForms;
        public UserControlQuocGia(DMQGService dmQGService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _dmQGService = dmQGService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            _girdSysDinhDangForms = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "QuocGia").data.ToList();
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
            var quocgiList = _dmQGService.GetAll();
            var dataSort = quocgiList.ApplySortSystemDinhDang(_girdSysDinhDangForms);
            DataGridViewFilterHelperV2.ApplyFilter(dataGridViewX1, dataSort, _girdSysDinhDangForms);
        }

        private void dataGridViewX1_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, System.EventArgs e)
        {
            string menuName = "QuocGia";
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
