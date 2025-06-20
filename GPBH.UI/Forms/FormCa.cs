using DevComponents.DotNetBar;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Helper;

namespace GPBH.UI.Forms
{
    public partial class FormCa : Office2007Form
    {
        private readonly DMcaService _dMcaService;
        public FormCa(DMcaService dMcaService)
        {
            InitializeComponent();
            _dMcaService = dMcaService;
            LoadData();
        }
        private void LoadData()
        {
            var caList = _dMcaService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, caList);
        }

    }
}
