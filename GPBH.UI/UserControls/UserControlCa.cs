using GPBH.Business;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.Data.UnitOfWorks;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlCa : UserControl
    {
        private readonly DMcaService _dmcaService;
        private readonly IServiceProvider _serviceProvider;
        public UserControlCa(DMcaService dMcaService, IServiceProvider serviceProvider)
        {
            _dmcaService = dMcaService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTim.Click += btnTim_Click;
            LoadData();

        }

        private void LoadData()
        {
            var caList = _dmcaService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, caList);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var ca = ActivatorUtilities.CreateInstance<FormCa>(Program.ServiceProvider);
            if (ca.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var maCa = dataGridViewX1.Rows[e.RowIndex].Cells["Ma_ca"].Value?.ToString();
                if (!string.IsNullOrEmpty(maCa))
                {
                    var caData = _dmcaService.GetByMaCa(maCa);
                    if (caData != null)
                    {
                        var form = ActivatorUtilities.CreateInstance<FormCa>(Program.ServiceProvider, caData);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow == null) return;

            var maCa = dataGridViewX1.CurrentRow.Cells["Ma_ca"].Value?.ToString();
            if (string.IsNullOrEmpty(maCa)) return;

            var caData = _dmcaService.GetByMaCa(maCa);
            if (caData == null) return;

            var form = ActivatorUtilities.CreateInstance<FormCa>(Program.ServiceProvider, caData);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow == null) return;

            var maCa = dataGridViewX1.CurrentRow.Cells["Ma_ca"].Value?.ToString();
            if (string.IsNullOrEmpty(maCa)) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa ca [{maCa}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _dmcaService.Delete(maCa);
                LoadData();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim().ToLower();
            var caList = _dmcaService.GetAll()
                .Where(x =>
                    x.Ma_ca != null && x.Ma_ca.ToLower().Contains(keyword) ||
                    x.Ten_ca != null && x.Ten_ca.ToLower().Contains(keyword) ||
                    x.Gio_bd != null && x.Gio_bd.ToLower().Contains(keyword) ||
                    x.Gio_kt != null && x.Gio_kt.ToLower().Contains(keyword)
                )
                .ToList();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, caList);
        }

        public List<DMca> SearchByKeyword(string keyword)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                return unitOfWork.Repository<DMca>()
                    .Find(x => x.Ma_ca.Contains(keyword) || x.Ten_ca.Contains(keyword))
                    .ToList();
            }
        }
    }
}
