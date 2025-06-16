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

namespace GPBH.UI.Forms
{
    public partial class HangHoa : Form
    {
        private readonly DMHHService _dmHHService;
        public HangHoa(DMHHService dmHHService)
        {
            InitializeComponent();
            _dmHHService = dmHHService;
            LoadData();
        }

        private void LoadData()
        {
            var hhList = _dmHHService.GetAllGrid();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, hhList);
        }
    }
}
