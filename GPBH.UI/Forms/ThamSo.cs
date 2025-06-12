using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class ThamSo : Form
    {
        #region Fields & Constructor

        private readonly SysDMCuaHangService _sysDMCuaHangService;

        public ThamSo(SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            _sysDMCuaHangService = sysDMCuaHangService;
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
            LoadData();
            RegisterEvents();
        }

        /// <summary>
        /// Đăng ký các sự kiện cho control.
        /// </summary>
        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click;
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;
        }

        #endregion

        #region Data Loading & Binding

        /// <summary>
        /// Load dữ liệu tham số hệ thống lên lưới.
        /// </summary>
        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            dataGridViewX1.BindData(_sysDMCuaHangService.GetThamSo(cbbCuaHang.SelectedValue.ToString()));
        }

        #endregion

        #region UI Setup

        /// <summary>
        /// Cài đặt hiển thị, định dạng và thứ tự các cột trên DataGridView.
        /// </summary>
        private void SetUpUI()
        {
            if (dataGridViewX1.Columns.Count == 0) return;

            // Canh giữa header cho cột STT
            dataGridViewX1.SetHeaderAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);

            // Sắp xếp vị trí các cột
            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("Key", 1);
            dataGridViewX1.SetDisplayIndex("Ten", 2);
            dataGridViewX1.SetDisplayIndex("GiaTri", 3);
            dataGridViewX1.SetDisplayIndex("Mota", 4);

            // Căn chỉnh dữ liệu trong cột STT
            dataGridViewX1.SetCellAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Lưu dữ liệu tham số khi click nút Lưu.
        /// </summary>
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var data = dataGridViewX1.GetData<GirdSystemSettingDto>();
            _sysDMCuaHangService.LuuThamSo(data, AppGlobals.MaCH);
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewX1.BindData(_sysDMCuaHangService.GetThamSo(cbbCuaHang.SelectedValue.ToString()));
        }

        #endregion
    }
}
