using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlNguoiSuDung : UserControl
    {
        #region Fields & Constructor

        private readonly SysDMNSDService _sysDMNSDService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;

        public UserControlNguoiSuDung(SysDMNSDService sysDMNSDService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            _sysDMNSDService = sysDMNSDService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            InitializeComponent();
            InitializeUI();
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Khởi tạo UI, load dữ liệu và đăng ký sự kiện.
        /// </summary>
        private void InitializeUI()
        {
            SetUpUI();
            RegisterEvents();
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
        }

        /// <summary>
        /// Đăng ký các sự kiện cho control.
        /// </summary>
        private void RegisterEvents()
        {
            dataGridViewX1.CellDoubleClick += DataGridViewX1_CellDoubleClick;
            dataGridViewX1.CellClick += DataGridViewX1_CellClick;
            dataGridViewX1.KeyDown += DataGridViewX1_KeyDown;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTim.Click += BtnTim_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        #endregion

        #region Data Loading & Binding

        /// <summary>
        /// Load toàn bộ người dùng lên lưới và apply filter.
        /// </summary>
        private void LoadData()
        {
            var users = _sysDMNSDService.GellAll();
            SetImageForUsers(users);
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, users);
        }

        /// <summary>
        /// Gán ảnh quyền cho user.
        /// </summary>
        private static void SetImageForUsers(System.Collections.Generic.IEnumerable<GirdNguoiSuDungDto> users)
        {
            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "Shield.png"));
            foreach (var user in users)
            {
                user.PhanQuyen = img;
            }
        }

        /// <summary>
        /// Tìm kiếm theo từ khóa và bind lại dữ liệu.
        /// </summary>
        private void TimKiem()
        {
            var users = _sysDMNSDService.TiemKiem(txtSearch.Text);
            SetImageForUsers(users);
            SetUpUI();
            dataGridViewX1.BindData(users, true);
        }

        #endregion

        #region UI Setup

        /// <summary>
        /// Setup hiển thị cho DataGridView: căn giữa, format, sắp xếp cột.
        /// </summary>
        private void SetUpUI()
        {
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "NguoiDung").data.ToList();
            dataGridViewX1.ApplyColumnConfig(fields);
        }


        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý phím tắt trên DataGridView.
        /// </summary>
        private void DataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                HandleXoa();
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) => TimKiem();

        private void BtnTim_Click(object sender, EventArgs e) => TimKiem();

        private void BtnThem_Click(object sender, EventArgs e)
        {
            this.ShowForm<NguoiSuDung>();
            TimKiem(); // Sau khi thêm, load lại dữ liệu
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("NguoiDung", GPBHConstant.Action.Sua);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var item = GetSelectedUser();
            if (item != null)
            {
                var data = _sysDMNSDService.GetByTenDangNhap(item.TenDangNhap);
                if (data != null && data.TenDangNhap == GPBHConstant.SuperAdmin)
                {
                    MessageBoxEx.Show($"Không thể sửa thông tin người dùng {GPBHConstant.SuperAdmin}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.ShowForm<NguoiSuDung>(data);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e) => HandleXoa();

        /// <summary>
        /// Xử lý xóa người dùng.
        /// </summary>
        private void HandleXoa()
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("NguoiDung", GPBHConstant.Action.Xoa);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var item = GetSelectedUser();
            if (item == null) return;

            var tenDangNhap = item.TenDangNhap;

            if (tenDangNhap == GPBHConstant.SuperAdmin)
            {
                MessageBoxEx.Show($"Không thể sửa thông tin người dùng {GPBHConstant.SuperAdmin}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultDialog = MessageBoxEx.Show($"Bạn có chắc muốn xóa người dùng: {tenDangNhap}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.Yes)
            {
                var (result, message) = _sysDMNSDService.XoaNguoiDung(tenDangNhap);
                if (result)
                {
                    MessageBoxEx.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimKiem();
                }
                else
                {
                    MessageBoxEx.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Double click vào row để sửa thông tin người dùng.
        /// </summary>
        private void DataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("NguoiDung", GPBHConstant.Action.Sua);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridViewX1.Rows[e.RowIndex];
                var tenDangNhap = row.Cells["TenDangNhap"].Value?.ToString();
                if (!string.IsNullOrEmpty(tenDangNhap))
                {
                    var data = _sysDMNSDService.GetByTenDangNhap(tenDangNhap);
                    if (data != null && data.TenDangNhap == GPBHConstant.SuperAdmin)
                    {
                        MessageBoxEx.Show($"Không thể sửa thông tin người dùng {GPBHConstant.SuperAdmin}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.ShowForm<NguoiSuDung>(data, true);
                }
            }
        }

        /// <summary>
        /// Click vào cell (ví dụ cột phân quyền) để mở form phân quyền.
        /// </summary>
        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            {
                if (dataGridViewX1.Columns[e.ColumnIndex].Name != "PhanQuyen")
                {
                    return;
                }

                var tenDangNhap = dataGridViewX1.Rows[e.RowIndex].Cells["TenDangNhap"].Value?.ToString();

                if (!string.IsNullOrEmpty(tenDangNhap))
                {// check phải admin không thì không cho sửa

                    var user = _sysDMNSDService.GetByTenDangNhap(tenDangNhap);
                    if (user.IsAdmin)
                    {
                        // show admin không đc quyền
                        MessageBoxEx.Show($"Không thể phân quyền cho người dùng {user.TenDangNhap} vì đã là admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    this.ShowForm<PhanQuyen>(tenDangNhap);
                }
            }
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Lấy user đang chọn trên lưới (bỏ qua dòng filter đầu).
        /// </summary>
        /// <returns>GirdNguoiSuDungDto hoặc null</returns>
        private GirdNguoiSuDungDto GetSelectedUser()
        {
            if (dataGridViewX1.CurrentRow != null &&
                dataGridViewX1.CurrentRow.Index > 0 &&
                dataGridViewX1.CurrentRow.DataBoundItem is GirdNguoiSuDungDto item)
            {
                return item;
            }
            MessageBoxEx.Show("Vui lòng chọn dòng dữ liệu hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        #endregion

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string menuName = "NguoiDung";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            ExportHelper.ExportGridToExcel(dataGridViewX1, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), isIgnoreRowFirst: true);
        }
    }
}