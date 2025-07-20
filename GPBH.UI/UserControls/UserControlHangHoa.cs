using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlHangHoa : UserControl
    {
        private readonly DMHHService _dmHHService;
        public UserControlHangHoa(DMHHService dmHHService)
        {
            InitializeComponent();
            _dmHHService = dmHHService;
            dataGridViewX1.AutoGenerateColumns = false;
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
