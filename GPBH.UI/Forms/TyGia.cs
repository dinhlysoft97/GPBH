using DevComponents.DotNetBar;
using GPBH.Business.Services;
using GPBH.UI.Helper;

namespace GPBH.UI.Forms
{
    public partial class TyGia : Office2007Form
    {
        private readonly DMTGService _dmTGService;
        public TyGia(DMTGService dMTGService)
        {
            InitializeComponent();
            _dmTGService = dMTGService;
            LoadData();
        }

        private void LoadData()
        {
            var tygiaList = _dmTGService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, tygiaList);
        }
    }
}
