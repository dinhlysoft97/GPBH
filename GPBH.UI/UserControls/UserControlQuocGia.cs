using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlQuocGia : UserControl
    {
        private readonly DMQGService _dmQGService;
        public UserControlQuocGia(DMQGService dmQGService)
        {
            InitializeComponent();
            _dmQGService = dmQGService;
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
    }
}
