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
    public partial class NgoaiTe : Form
    {
        private readonly DMNTService _dmNTService;
        public NgoaiTe(DMNTService dMNTService)
        {
            InitializeComponent();
            _dmNTService = dMNTService;
            LoadData();
        }

        private void LoadData()
        {
            var ngoaiteList = _dmNTService.GetAllGrid();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, ngoaiteList);
        }
    }
}
