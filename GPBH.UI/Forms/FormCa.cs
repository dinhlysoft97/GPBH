using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Extentions;
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
            LoadData();
        }
        private void LoadData()
        {
            var caList = _dMcaService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, caList);
        }

    }
}
