using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlNguoiSuDung : UserControl
    {
        #region Fields & Constructor

        private readonly SysDMNSDService _sysDMNSDService;

        public UserControlNguoiSuDung(SysDMNSDService sysDMNSDService)
        {
            _sysDMNSDService = sysDMNSDService;
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
            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "banhang.png"));
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
            if (dataGridViewX1.Columns.Count == 0) return;

            // Canh giữa header
            dataGridViewX1.SetHeaderAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetHeaderAlignment("PhanQuyen", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetHeaderAlignment("Ksd", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetHeaderAlignment("CapLaiQuyen", DataGridViewContentAlignment.MiddleCenter);

            // Sắp xếp vị trí các cột
            SetColumnDisplayIndex();

            // Căn chỉnh và format dữ liệu
            SetColumnFormatting();
        }

        /// <summary>
        /// Đặt lại vị trí các cột theo yêu cầu.
        /// </summary>
        private void SetColumnDisplayIndex()
        {
            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("PhanQuyen", 1);
            dataGridViewX1.SetDisplayIndex("TenDangNhap", 2);
            dataGridViewX1.SetDisplayIndex("TenDayDu", 3);
            dataGridViewX1.SetDisplayIndex("Ksd", 4);
            dataGridViewX1.SetDisplayIndex("CapLaiQuyen", 5);
            dataGridViewX1.SetDisplayIndex("Ngay_sua", 6);
            dataGridViewX1.SetDisplayIndex("Nguoi_sua", 7);
            dataGridViewX1.SetDisplayIndex("Ngay_tao", 8);
            dataGridViewX1.SetDisplayIndex("Nguoi_tao", 9);
        }

        /// <summary>
        /// Căn chỉnh và format cho các cột dữ liệu.
        /// </summary>
        private void SetColumnFormatting()
        {
            dataGridViewX1.SetCellAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetCellAlignment("Ksd", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetCellAlignment("CapLaiQuyen", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetFormat("Ngay_sua", "dd/MM/yyyy");
            dataGridViewX1.SetFormat("Ngay_tao", "dd/MM/yyyy");
        }


        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý phím tắt trên DataGridView.
        /// </summary>
        private void DataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
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
            var item = GetSelectedUser();
            if (item != null)
            {
                var data = _sysDMNSDService.GetByTenDangNhap(item.TenDangNhap);
                this.ShowForm<NguoiSuDung>(data);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e) => HandleXoa();

        /// <summary>
        /// Xử lý xóa người dùng.
        /// </summary>
        private void HandleXoa()
        {
            var item = GetSelectedUser();
            if (item == null) return;

            var tenDangNhap = item.TenDangNhap;
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
            if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridViewX1.Rows[e.RowIndex];
                var tenDangNhap = row.Cells["TenDangNhap"].Value?.ToString();
                if (!string.IsNullOrEmpty(tenDangNhap))
                {
                    var data = _sysDMNSDService.GetByTenDangNhap(tenDangNhap);
                    this.ShowForm<NguoiSuDung>(data);
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
                {
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
    }
}