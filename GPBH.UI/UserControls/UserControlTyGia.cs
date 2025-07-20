using DevComponents.DotNetBar.Controls;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlTyGia : UserControl
    {
        private readonly DMTGService _dmTGService;
        public UserControlTyGia(DMTGService dMTGService)
        {
            InitializeComponent();
            _dmTGService = dMTGService;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            LoadData();
        }
        private void LoadData()
        {
            var tygiaList = _dmTGService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, tygiaList);

            // Định dạng ngày cho cột Ngay_ap_dung
            if (dataGridViewX1.Columns.Contains("Ngay_ap_dung"))
            {
                var colNgayApDung = dataGridViewX1.Columns["Ngay_ap_dung"];
                colNgayApDung.DefaultCellStyle.Format = "dd/MM/yy";
                colNgayApDung.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colNgayApDung.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Định dạng ngày cho cột Ty_gia
            if (dataGridViewX1.Columns.Contains("Ty_gia"))
            {
                var colNgayApDung = dataGridViewX1.Columns["Ty_gia"];
                colNgayApDung.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colNgayApDung.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void dataGridViewX1_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }
    }
}
