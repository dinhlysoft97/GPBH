using DevComponents.DotNetBar;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;

namespace GPBH.UI.Forms
{
    public partial class HangHoa : Office2007Form
    {
        private readonly DMHHService _dmHHService;
        public HangHoa(DMHHService dmHHService)
        {
            InitializeComponent();
            _dmHHService = dmHHService;
            LoadData();
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
    }
}
