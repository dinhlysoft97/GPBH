using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;


namespace GPBH.UI.UserControls
{
    public partial class UserControlCa : UserControl
    {
        private readonly DMCaService _dmCaService;
        private List<DMca> caList;
        public UserControlCa()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _dmCaService = new DMCaService();
            LoadData();
        }

        private void LoadData()
        {
            caList = _dmCaService.GetAll();
            dataGridViewX1.DataSource = caList;
            DataGridViewFilterHelper.ApplyFillter(dataGridViewX1, caList);
        }

    }
}
