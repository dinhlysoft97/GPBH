using GPBH.Business.Services;
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
    public partial class UserControlQuocGia : UserControl
    {
        private readonly DMQGService _dmQGService;
        public UserControlQuocGia()
        {
            InitializeComponent();
            _dmQGService = new DMQGService(Program.ServiceProvider);
            LoadQuocGia();
        }

        private void LoadQuocGia()
        {
            try
            {
                var list = _dmQGService.GetAll();
                dataGridViewX1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
