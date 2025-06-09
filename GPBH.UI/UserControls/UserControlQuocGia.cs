using GPBH.Business.Services;
using GPBH.UI.Helper;
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
        public UserControlQuocGia(DMQGService dmQGService)
        {
            InitializeComponent();
            _dmQGService = dmQGService;
            LoadData();
        }

        public void LoadData()
        {
            var quocGiaList = _dmQGService.GetAllQuocGia();
            dataGridViewX1.DataSource = quocGiaList;
            DataGridViewFilterHelper.ApplyFillter(dataGridViewX1, quocGiaList);
        }
    }
}
