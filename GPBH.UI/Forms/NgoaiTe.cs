using DevComponents.DotNetBar;
using GPBH.Business.Services;
using GPBH.UI.Helper;

namespace GPBH.UI.Forms
{
    public partial class NgoaiTe : Office2007Form
    {
        private readonly DMNTService _dmNTService;
        public NgoaiTe(DMNTService dMNTService)
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
    }
}
