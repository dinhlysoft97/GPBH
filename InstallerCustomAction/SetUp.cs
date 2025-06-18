using DevComponents.DotNetBar;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace InstallerCustomAction
{
    public partial class SetUp : Office2007Form
    {
        public SetUp()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                const int CS_NOCLOSE = 0x200;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuaHang.Text.Trim()))
            {
                MessageBoxEx.Show(this, "Vui lòng nhập cửa hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuaHang.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMaQuay.Text.Trim()))
            {
                MessageBoxEx.Show(this, "Vui lòng nhập mã quầy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaQuay.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMaKho.Text.Trim()))
            {
                MessageBoxEx.Show(this, "Vui lòng nhập mã kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKho.Focus();
                return;
            }

            var setting = new Setting
            {
                MaCH = txtCuaHang.Text.ToString(),
                MaQuay = txtMaQuay.Text.ToString(),
                MaKho = txtMaKho.Text.ToString()
            };

            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            string settingPath = Path.Combine(exeFolder, "setting.json");
            string dir = Path.GetDirectoryName(settingPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(settingPath, JsonConvert.SerializeObject(setting));
            ToastNotification.Show(this, "Đã lưu cấu hình!", null, 2000, eToastGlowColor.Blue, eToastPosition.MiddleCenter);

            // Hiện toast, sau 2 giây tự đóng form

            Timer timer = new Timer();
            timer.Interval = 2000; // 2 giây (đúng với thời gian toast show)
            timer.Tick += (ss, ex) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
        }
        public class Setting
        {
            public string MaCH { get; set; }
            public string MaQuay { get; set; }
            public string MaKho { get; set; }
        }
    }
}
