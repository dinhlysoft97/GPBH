using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.UI.Extentions;
using System;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class PhanQuyen : Office2007Form
    {
        private readonly SysDMNSDService _sysDMNSDService;
        private readonly string _tenDangNhap;
        public PhanQuyen(SysDMNSDService sysDMNSDService, string tenDangNhap)
        {
            InitializeComponent();
            _sysDMNSDService = sysDMNSDService;
            _tenDangNhap = tenDangNhap;
            SetUpUI();
            LoadData();
            RegisterEvents();
        }
        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click; ;
            btnDong.Click += BtnDong_Click;
            dataGridViewX1.CellClick += dataGridViewX1_CellClick;
        }

        private void LoadData()
        {
            dataGridViewX1.BindData(_sysDMNSDService.GetDataPhanQuyen(_tenDangNhap));
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var data = dataGridViewX1.GetData<GirdPhanQuyenDto>();
            _sysDMNSDService.PhanQuyen(data, _tenDangNhap);
            MessageBoxEx.Show("Phân quyền người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.ColseForm();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra dòng và cột hợp lệ, và cột cần thao tác
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var col = dataGridViewX1.Columns[e.ColumnIndex];

                // Giả sử cột này là kiểu DataGridViewCheckBoxColumn hoặc tự bạn đặt tên cột
                if (col is DataGridViewCheckBoxXColumn) // đổi tên cho phù hợp
                {
                    var cell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    bool currentValue = Convert.ToBoolean(cell.Value ?? false);
                    cell.Value = !currentValue;
                }
            }
        }

        private void SetUpUI()
        {
            // Canh giữa header
            dataGridViewX1.Columns["Stt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Them"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Xem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Sua"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Xoa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["In"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Excel"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Excel"].Visible = true;

            // Số thứ tự các cột
            dataGridViewX1.Columns["Stt"].DisplayIndex = 1;
            dataGridViewX1.Columns["MenuId"].DisplayIndex = 2;
            dataGridViewX1.Columns["MenuName"].DisplayIndex = 3;
            dataGridViewX1.Columns["Xem"].DisplayIndex = 4;
            dataGridViewX1.Columns["Sua"].DisplayIndex = 5;
            dataGridViewX1.Columns["Xoa"].DisplayIndex = 6;
            dataGridViewX1.Columns["In"].DisplayIndex = 7;
            dataGridViewX1.Columns["Excel"].DisplayIndex = 8;

            // Foramt columns
            dataGridViewX1.Columns["Stt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Them"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Xem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Sua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Xoa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["In"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Excel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
