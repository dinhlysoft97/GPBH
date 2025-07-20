using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlNgoaiTe : UserControl
    {
        private readonly DMNTService _dmNTService;
        public UserControlNgoaiTe(DMNTService dMNTService)
        {
            InitializeComponent();
            _dmNTService = dMNTService;
            LoadData();
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
    }
}
