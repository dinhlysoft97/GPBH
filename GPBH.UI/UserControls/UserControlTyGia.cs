using GPBH.Business;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlTyGia : UserControl
    {
        private readonly DMTGService _dmTGService;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;
        public UserControlTyGia(DMTGService dMTGService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _dmTGService = dMTGService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
        }

        private void SetUpUI()
        {
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "TyGia").data.ToList();
            dataGridViewX1.ApplyColumnConfig(fields);
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

        private void btnXuatExcel_Click(object sender, System.EventArgs e)
        {
            string menuName = "TyGia";
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
