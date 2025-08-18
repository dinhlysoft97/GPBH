using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlDinhDangForm : UserControl
    {
        private readonly SysDinh_dang_formService _sysDinh_dang_formService;
        private readonly SysDMCuaHangService _sysDMCuaHangService;

        sealed class DropDown
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        private readonly List<DropDown> _thanhToans = new List<DropDown>
        {
            new DropDown() { Key = "X05", Value = "Đơn hàng" },
            new DropDown() { Key = "BanHangTheoKhachHang", Value = "Báo cáo khách hàng" },
            new DropDown() { Key = "Ca", Value = "Quốc gia" },
            new DropDown() { Key = "QuocGia", Value = "Danh mục ca" },
            new DropDown() { Key = "KhachHang", Value = "Khách hàng" },
            new DropDown() { Key = "NgoaiTe", Value = "Ngoại tệ" },
            new DropDown() { Key = "TyGia", Value = "Tỷ giá" },
            new DropDown() { Key = "HangHoa", Value = "Hành hóa" },
            new DropDown() { Key = "GiaBan", Value = "Giá bán" },
            new DropDown() { Key = "DinhDangForm", Value = "Định dạng form" },
            new DropDown() { Key = "ThamSo", Value = "Tham số" },
            new DropDown() { Key = "NguoiDung", Value = "Người dùng" },
        };

        public UserControlDinhDangForm(SysDinh_dang_formService sysDinh_Dang_FormService, SysDMCuaHangService sysDMCuaHangService)
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
            cbbCode.SelectedIndexChanged += CbbCode_SelectedIndexChanged;
            dataGridViewX1.CellClick += dataGridViewX1_CellClick;
        }

        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resuft = _sysDinh_dang_formService.GetDinhDang(cbbCuaHang.SelectedValue.ToString(), cbbCode.SelectedValue.ToString());
            if (resuft.hasSave)
            {
                lbWarning.Visible = false;
            }
            else
            {
                lbWarning.Visible = true;
            }

            dataGridViewX1.BindData(resuft.data);
        }

        private void CbbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCuaHang.SelectedValue is null || cbbCode.SelectedValue is null) return;
            var resuft = _sysDinh_dang_formService.GetDinhDang(cbbCuaHang.SelectedValue.ToString(), cbbCode.SelectedValue.ToString());
            if (resuft.hasSave)
            {
                lbWarning.Visible = false;
            }
            else
            {
                lbWarning.Visible = true;
            }

            dataGridViewX1.BindData(resuft.data);
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("DinhDangForm", GPBHConstant.Action.Sua);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var data = dataGridViewX1.GetData<GirdSysDinhDangFormDto>();
            _sysDinh_dang_formService.LuuDinhDang(data, cbbCuaHang.SelectedValue.ToString());
            lbWarning.Visible = false;
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCode, _thanhToans, "Value", "Key");
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            cbbCuaHang.SelectedValue = AppGlobals.MaCH;
            cbbCode.SelectedValue = _thanhToans[0].Key;
            var result = _sysDinh_dang_formService.GetDinhDang(cbbCuaHang.SelectedValue.ToString(), cbbCode.SelectedValue.ToString());
            dataGridViewX1.BindData(result.data);
            if (result.hasSave)
            {
                lbWarning.Visible = false;
            }
            else
            {
                lbWarning.Visible = true;
            }

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

            // Canh giữa header
            dataGridViewX1.Columns["MenuId"].Visible = false;

            // Sắp xếp vị trí các cột
            dataGridViewX1.SetDisplayIndex("Code_name", 0);
            dataGridViewX1.SetDisplayIndex("MenuName", 1);
            dataGridViewX1.SetDisplayIndex("Field_name", 2);
            dataGridViewX1.SetDisplayIndex("Field_type", 3);
            dataGridViewX1.SetDisplayIndex("Field_title", 4);
            dataGridViewX1.SetDisplayIndex("Field_order", 5);
            dataGridViewX1.SetDisplayIndex("Field_hide", 6);
            dataGridViewX1.SetDisplayIndex("Field_width", 7);
            dataGridViewX1.SetDisplayIndex("Field_format", 8);
            dataGridViewX1.SetDisplayIndex("Default_sort", 9);
            dataGridViewX1.SetDisplayIndex("Ten_ban", 10);

            // Căn chỉnh dữ liệu
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

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string menuName = "DinhDangForm";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var fields = _sysDinh_dang_formService.GetDinhDang(AppGlobals.MaCH, menuName).data.Where(z => !z.Field_hide).OrderBy(z => z.Field_order).ToList();
            var data = dataGridViewX1.DataSource as BindingList<GirdSysDinhDangFormDto>;
            ExportHelper.ExportToExcel(data, fields, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), isIgnoreRowFirst: true);
        }
    }
}
