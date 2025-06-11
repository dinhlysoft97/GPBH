using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GPBH.UI.Forms
{
    public partial class FormCa : Form
    {
        private bool _isEdit = false;
        private DMca _data;
        private readonly DMcaService _dMcaService;
        public FormCa(DMcaService dMcaService, DMca data = null)
        {
            InitializeComponent();
            _dMcaService = dMcaService;
            _data = data;
            _isEdit = data != null;
            if (_isEdit)
                LoadDataEdit();
            _data = data;
        }

        private void LoadDataEdit()
        {
            txtMaCa.Enabled = false;

            txtMaCa.Text = _data.Ma_ca;
            txtTenCa.Text = _data.Ten_ca;
            txtGioBD.Text = _data.Gio_bd;
            txtGioKT.Text = _data.Gio_kt;

            this.Text = "Cập nhật ca: " + _data.Ten_ca;
        }
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            var validator = ValidatorData();
            if (validator)
            {
                lbError.Text = "";
                lbError.BackColor = System.Drawing.Color.Transparent;
                var ca = new DMca
                {
                    Ma_ca = txtMaCa.Text.Trim(),
                    Ten_ca = txtTenCa.Text.Trim(),
                    Gio_bd = txtGioBD.Text.Trim(),
                    Gio_kt = txtGioKT.Text.Trim(),

                };

                if (_isEdit)
                {
                    _dMcaService.Update(ca);
                    MessageBoxEx.Show("Cập nhật ca thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    var existingCa = _dMcaService.CheckTrungTenCa(ca.Ten_ca);
                    if (existingCa)
                    {
                        txtTenCa.Focus();
                        MessageBoxEx.Show("Tên Ca đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _dMcaService.Add(ca);
                    MessageBoxEx.Show("Tạo ca thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private bool ValidatorData()
        {
            var result = true;
            string message = string.Empty;
            if (string.IsNullOrWhiteSpace(txtMaCa.Text))
            {
                txtMaCa.Focus();
                message = "Mã ca không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtTenCa.Text))
            {
                txtTenCa.Focus();
                message = "Tên ca không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtGioBD.Text))
            {
                txtGioBD.Focus();
                message = "Giờ bắt đầu không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtGioKT.Text))
            {
                txtGioKT.Focus();
                message = "Giờ kết thúc xác nhận không được để trống.";
                result = false;
            }
            if (!result)
            {
                lbError.Text = message;
                lbError.BackColor = System.Drawing.Color.Red;
                result = false;
            }

            return result;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.ColseForm();
        }
    }
}
