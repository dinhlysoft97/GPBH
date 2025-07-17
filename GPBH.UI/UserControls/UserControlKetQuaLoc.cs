using DevComponents.DotNetBar.Controls;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Report;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;


namespace GPBH.UI.UserControls
{
    public partial class UserControlKetQuaLoc : UserControl
    {
        private DataTable _data;
        private DateTime _tuNgay;
        private DateTime _denNgay;
        private string _maNgoaiTe;
        private List<GirdSysDinhDangFormDto> SysDinhDangs = new List<GirdSysDinhDangFormDto>();

        public UserControlKetQuaLoc(DataTable data, DateTime tuNgay, DateTime denNgay, string maNgoaiTe)
        {
            InitializeComponent();
            _data = data;
            _tuNgay = tuNgay;
            _denNgay = denNgay;
            _maNgoaiTe = maNgoaiTe;
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.DataSource = _data;
            SetUpUI();
            dataGridViewX1.DataBindingComplete += DataGridViewX1_DataBindingComplete;

        }

        private void DataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                var row = dataGridViewX1.Rows[i];
                if (row.IsNewRow) continue;

                row.Cells["Stt"].Value = i + 1;          
                row.Cells["Stt"].ReadOnly = true;        
            }
        }

        private void btnIn_Click(object sender, System.EventArgs e)
        {
            var frm = new ReportBanHang(_data, _tuNgay, _denNgay, _maNgoaiTe);
            frm.ShowDialog();
        }
        private string GetFormat(string column)
        {
            if (SysDinhDangs == null)
                return string.Empty;
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }


        private void SetUpUI()
        {
            var colStt = dataGridViewX1.Columns["Stt"];
            colStt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Stt"].Visible = false;

            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("So_don_hang", 1);
            dataGridViewX1.SetDisplayIndex("Ngay_ban", 2);
            dataGridViewX1.SetDisplayIndex("Passport", 3);
            dataGridViewX1.SetDisplayIndex("Ten_khachhang", 4);
            dataGridViewX1.SetDisplayIndex("Tong_nhan", 5);
            dataGridViewX1.SetDisplayIndex("Tra_lai_nt", 6);
            dataGridViewX1.SetDisplayIndex("Thanh_tien", 7);
            dataGridViewX1.SetDisplayIndex("Thanh_tien_vn", 8);

            // Format các cột tiền
            dataGridViewX1.SetFormat("Ty_gia", GetFormat("Format_gia"));
            dataGridViewX1.SetFormat("Tra_lai_nt", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Tong_nha", GetFormat("Format_gia"));
            dataGridViewX1.SetFormat("Thanh_tien", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Thanh_tien_vn", GetFormat("Format_gia"));

        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }
    }
}
