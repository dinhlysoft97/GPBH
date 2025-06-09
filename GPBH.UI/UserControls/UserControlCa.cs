using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using GPBH.Business.DTO;
using GPBH.Business.Services;
using GPBH.UI.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;


namespace GPBH.UI.UserControls
{
    public partial class UserControlCa : UserControl
    {
        private readonly DMcaService _dmCaService;

        public UserControlCa(DMcaService dMCaService)
        {
            InitializeComponent();
            _dmCaService = dMCaService;
            LoadData();
        }

        private void LoadData()
        {
            var caList = _dmCaService.GetAllCa();
            dataGridViewX1.DataSource = caList;
            DataGridViewFilterHelper.ApplyFillter(dataGridViewX1, caList);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormAddCa())
            {
                if (form.ShowDialog() == DialogResult.OK && form.NewCa != null)
                {
                    _dmCaService.AddCa(form.NewCa);

                    LoadData();
                }
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc ngoài dòng dữ liệu
            if (e.RowIndex < 0) return;

            // Lấy dữ liệu dòng được chọn
            var row = dataGridViewX1.Rows[e.RowIndex];
            var dto = new DMcaDto
            {
                Ma_ca = row.Cells["Ma_ca"].Value?.ToString(),
                Ten_ca = row.Cells["Ten_ca"].Value?.ToString(),
                Gio_bd = row.Cells["Gio_bd"].Value?.ToString(),
                Gio_kt = row.Cells["Gio_kt"].Value?.ToString()
            };

            // Mở form sửa (giả sử FormAddCa hỗ trợ truyền DMCaDTO vào constructor)
            using (var form = new FormAddCa(dto))
            {
                if (form.ShowDialog() == DialogResult.OK && form.NewCa != null)
                {
                    _dmCaService.EditCa(form.NewCa);
                    LoadData();
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow == null || dataGridViewX1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một ca để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maCa = dataGridViewX1.CurrentRow.Cells["Ma_ca"].Value?.ToString();
            var tenCa = dataGridViewX1.CurrentRow.Cells["Ten_ca"].Value?.ToString();

            if (string.IsNullOrEmpty(maCa))
            {
                MessageBox.Show("Không xác định được mã ca.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa ca '{tenCa}' (Mã: {maCa}) không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var dto = new DMcaDto { Ma_ca = maCa };
            _dmCaService.DeleteCa(dto);

            LoadData();
        }

    }
}
