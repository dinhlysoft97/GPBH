using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlNguoiSuDung : UserControl
    {
        private readonly SysDMNSDService _sysDMNSDService;

        public UserControlNguoiSuDung(SysDMNSDService sysDMNSDService)
        {
            _sysDMNSDService = sysDMNSDService;
            InitializeComponent();
            SetUpUI();
            LoadData();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            dataGridViewX1.CellDoubleClick += dataGridViewX1_CellDoubleClick;
            dataGridViewX1.CellClick += dataGridViewX1_CellClick;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTim.Click += BtnTim_Click; ;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            
            var users = _sysDMNSDService.TiemKiem(txtSearch.Text);
            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "banhang.png"));
            foreach (var user in users)
            {
                user.PhanQuyen = img;
            }

            users.Insert(0, new GirdNguoiSuDungDto());
            dataGridViewX1.DataSource = new BindingList<GirdNguoiSuDungDto>(users);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            this.ShowForm<NguoiSuDung>();
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 1 && e.ColumnIndex >= 0)
            {
                var row = dataGridViewX1.Rows[e.RowIndex];
                var tenDangNhap = row.Cells["TenDangNhap"].Value;
                var data = _sysDMNSDService.GetByTenDangNhap(tenDangNhap.ToString());
                this.ShowForm<NguoiSuDung>(data);
            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex: chỉ số dòng vừa click
            // e.ColumnIndex: chỉ số cột vừa click
            if (e.RowIndex >= 1 && e.ColumnIndex >= 1)
            {
                // click vào phân quyền
                if (dataGridViewX1.Columns[e.ColumnIndex].Name == "PhanQuyen")
                {
                    var tenDangNhap = dataGridViewX1.Rows[e.RowIndex].Cells["TenDangNhap"].Value;
                    var row = dataGridViewX1.Rows[e.RowIndex];
                    var data = _sysDMNSDService.GetByTenDangNhap(tenDangNhap.ToString());
                    this.ShowForm<NguoiSuDung>(data);
                }
            }
        }
        private void LoadData()
        {
            var users = _sysDMNSDService.GellAll();
            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "banhang.png"));
            foreach (var user in users)
            {
                user.PhanQuyen = img;
            }
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, users);
        }

        private void SetUpUI()
        {
            // Canh giữa header
            dataGridViewX1.Columns["Stt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["PhanQuyen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Ksd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["CapLaiQuyen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Số thứ tự các cột
            dataGridViewX1.Columns["Stt"].DisplayIndex = 0;
            dataGridViewX1.Columns["TenDangNhap"].DisplayIndex = 2;
            dataGridViewX1.Columns["TenDayDu"].DisplayIndex = 3;
            dataGridViewX1.Columns["Ksd"].DisplayIndex = 4;
            dataGridViewX1.Columns["CapLaiQuyen"].DisplayIndex = 5;
            dataGridViewX1.Columns["Ngay_sua"].DisplayIndex = 6;
            dataGridViewX1.Columns["Nguoi_sua"].DisplayIndex = 7;
            dataGridViewX1.Columns["Ngay_tao"].DisplayIndex = 8;
            dataGridViewX1.Columns["Nguoi_tao"].DisplayIndex = 9;

            // Foramt columns
            dataGridViewX1.Columns["Stt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Ksd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["CapLaiQuyen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns["Ngay_sua"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewX1.Columns["Ngay_tao"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }
}
