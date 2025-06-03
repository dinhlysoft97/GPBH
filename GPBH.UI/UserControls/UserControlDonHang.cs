using System;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlDonHang : UserControl
    {
        public UserControlDonHang()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            dataGridViewX1.AutoGenerateColumns = false; // Không tự động sinh cột
            SetData(); 
        }

        private void SetData()
        {
            dtTu.Value = DateTime.Now;
            dtDen.Value = DateTime.Now;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}
