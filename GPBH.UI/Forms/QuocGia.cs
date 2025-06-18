using DevComponents.DotNetBar;
using GPBH.Business.Services;
using GPBH.UI.Helper;

namespace GPBH.UI.Forms
{
    public partial class QuocGia : Office2007Form
    {
        private readonly DMQGService _dmQGService;
        public QuocGia(DMQGService dmQGService)
        {
            InitializeComponent();
            _dmQGService = dmQGService;
            LoadData();
        }
        private void LoadData()
        {
            var quocgiList = _dmQGService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, quocgiList);
        }
    }
}
