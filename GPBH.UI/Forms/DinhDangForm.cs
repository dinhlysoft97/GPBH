using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class DinhDangForm : Form
    {
        private readonly SysDinh_dang_formService _sysDinh_dang_formService;
        private readonly SysDMCuaHangService _sysDMCuaHangService;
        public DinhDangForm(SysDinh_dang_formService sysDinh_Dang_FormService, SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            _sysDinh_dang_formService = sysDinh_Dang_FormService;
            _sysDMCuaHangService = sysDMCuaHangService;
            SetUpUI();
            LoadData();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click;
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;
            dataGridViewX1.CellClick += dataGridViewX1_CellClick;
        }

        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewX1.BindData(_sysDinh_dang_formService.GetDinhDang(cbbCuaHang.SelectedValue.ToString()));
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var data = dataGridViewX1.GetData<GirdSysDinhDangFormDto>();
            _sysDinh_dang_formService.LuuDinhDang(data, AppGlobals.MaCH);
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            dataGridViewX1.BindData(_sysDinh_dang_formService.GetDinhDang(cbbCuaHang.SelectedValue.ToString()));

            // Tìm cột ComboBox trong DataGridViewX (tên do bạn đặt trong Designer)
            var col = dataGridViewX1.Columns["Default_sort"] as DataGridViewComboBoxExColumn;
            if (col != null)
            {
                var data = Enum.GetValues(typeof(Sort))
                 .Cast<Sort>()
                 .Select(e => new { Key = (int)e, Name = e.ToString() })
                 .ToList();

                col.DataSource = data;
                col.DisplayMember = "Name"; // Cột hiển thị trên lưới
                col.ValueMember = "Key";     // Cột lưu vào DataSource
            }
        }

        private void SetUpUI()
        {
            if (dataGridViewX1.Columns.Count == 0) return;

            // Canh giữa header cho cột STT
            dataGridViewX1.SetHeaderAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.Columns["MenuId"].Visible = false;

            // Sắp xếp vị trí các cột
            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("Code_name", 1);
            dataGridViewX1.SetDisplayIndex("MenuName", 2);
            dataGridViewX1.SetDisplayIndex("Field_name", 3);
            dataGridViewX1.SetDisplayIndex("Field_type", 4);
            dataGridViewX1.SetDisplayIndex("Field_title", 5);
            dataGridViewX1.SetDisplayIndex("Field_order", 6);
            dataGridViewX1.SetDisplayIndex("Field_hide", 7);
            dataGridViewX1.SetDisplayIndex("Field_width", 8);
            dataGridViewX1.SetDisplayIndex("Field_format", 9);
            dataGridViewX1.SetDisplayIndex("Default_sort", 10);
            dataGridViewX1.SetDisplayIndex("Ten_ban", 11);

            // Căn chỉnh dữ liệu trong cột STT
            dataGridViewX1.SetCellAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetCellAlignment("Field_order", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Field_hide", DataGridViewContentAlignment.MiddleCenter);
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
    }
}
