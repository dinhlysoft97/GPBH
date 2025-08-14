using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlCa : UserControl
    {
        private readonly DMcaService _dMcaService;
        public UserControlCa(DMcaService dMcaService)
        {
            InitializeComponent();
            _dMcaService = dMcaService;
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                dataGridViewX1.SetGirdReadOnly();
            };
        }

        private void LoadData()
        {
            var caList = _dMcaService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, caList);
        }

        private void dataGridViewX1_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportGridToExcel(dataGridViewX1, "Ca_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}
