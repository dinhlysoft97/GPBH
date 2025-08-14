using GPBH.Business.Dtos;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

namespace GPBH.UI.UserControls
{
    public partial class UserControlQuocGia : UserControl
    {
        private readonly DMQGService _dmQGService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;
        public UserControlQuocGia(DMQGService dmQGService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _dmQGService = dmQGService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                dataGridViewX1.SetGirdReadOnly();
            };
        }
        private void LoadData()
        {
            var quocgiList = _dmQGService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, quocgiList);
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

            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, menuName).data.Where(z => !z.Field_hide).OrderBy(z => z.Field_order).ToList();
            var data = dataGridViewX1.DataSource as BindingList<GridQuocGia>;
            ExportHelper.ExportToExcel(data, fields, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}
