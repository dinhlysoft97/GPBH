using GPBH.Business.Dtos;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.Linq;
using GPBH.Data.Entities;

namespace GPBH.UI.UserControls
{
    public partial class UserControlNgoaiTe : UserControl
    {
        private readonly DMNTService _dmNTService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;
        public UserControlNgoaiTe(DMNTService dMNTService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _dmNTService = dMNTService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            SetUpUI();
            LoadData(); 
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                dataGridViewX1.SetGirdReadOnly();
            };
        }
        private void SetUpUI()
        {
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "NgoaiTe").data.ToList();
            dataGridViewX1.ApplyColumnConfig(fields);
        }

        private void LoadData()
        {
            var ngoaiteList = _dmNTService.GetAllGrid();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, ngoaiteList);
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
