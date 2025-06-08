using GPBH.Business.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class FormAddCa : Form
    {
        public DMcaDTO NewCa { get; private set; }

        public FormAddCa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCa = new DMcaDTO
            {
                Ma_ca = txtMaCa.Text.Trim(),
                Ten_ca = txtTenCa.Text.Trim(),
                Gio_bd = txtGioBD.Text.Trim(),
                Gio_kt = txtGioKT.Text.Trim()
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Constructor nhận DMCaDTO (sửa)
        public FormAddCa(DMcaDTO dto) : this()
        {
            if (dto != null)
            {
                // Gán dữ liệu lên các textbox
                txtMaCa.Text = dto.Ma_ca;
                txtTenCa.Text = dto.Ten_ca;
                txtGioBD.Text = dto.Gio_bd;
                txtGioKT.Text = dto.Gio_kt;

                // Nếu không cho sửa mã ca, có thể disable textbox này
                txtMaCa.Enabled = false;
            }
        }
    }
}
