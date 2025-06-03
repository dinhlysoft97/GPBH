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
    public partial class UserControlBanHangTheoKhachHang : UserControl
    {
        public UserControlBanHangTheoKhachHang()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            superGridControl1.PrimaryGrid.EnableFiltering = true;
        }
    }
}
