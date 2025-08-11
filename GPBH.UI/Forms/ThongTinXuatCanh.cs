using DevComponents.Editors;
using GPBH.UI.Extentions;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class ThongTinXuatCanh : Form
    {
        private string DateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        public DateTime? NgayCap { get; set; }
        public DateTime? HetHan { get; set; }
        public string SoHieu { get; set; }
        public string TauBay { get; set; }
        public bool IsValidator { get; set; }

        public ThongTinXuatCanh()
        {
            InitializeComponent();
            SetUpUI();
            this.KeyPreview = true;
            this.KeyDown += ThongTinXuatCanh_KeyDown;
        }

        private void SetUpUI()
        {
            dtNgayCap.Format = eDateTimePickerFormat.Custom;
            dtNgayCap.CustomFormat = DateFormat;

            dtHetHan.Format = eDateTimePickerFormat.Custom;
            dtHetHan.CustomFormat = DateFormat;
        }

        private void ThongTinXuatCanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.ShowForm<HuongDanSuDung>();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // validator
                if (string.IsNullOrWhiteSpace(dtNgayCap.Text))
                {
                    MessageBox.Show("Vui lòng nhập ngày cấp xuất cảnh.");
                    dtNgayCap.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(dtHetHan.Text))
                {
                    MessageBox.Show("Vui lòng nhập ngày hết hạn xuất cảnh.");
                    dtHetHan.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoHieu.Text))
                {
                    MessageBox.Show("Vui lòng nhập số hiệu phương tiện xuất cảnh.");
                    txtSoHieu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTauBay.Text))
                {
                    MessageBox.Show("Vui lòng nhập số hiệu phương tiện xuất cảnh.");
                    txtTauBay.Focus();
                    return;
                }

                IsValidator = true;
                NgayCap = dtNgayCap.Value;
                HetHan = dtHetHan.Value;
                SoHieu = txtSoHieu.Text;
                TauBay = txtTauBay.Text;
                this.Close();
            }
        }
    }
}
