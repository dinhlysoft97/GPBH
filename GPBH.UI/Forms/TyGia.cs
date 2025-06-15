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
    public partial class TyGia : Form
    {
        private readonly DMTGService _dmTGService;
        public TyGia(DMTGService dMTGService)
        {
            InitializeComponent();
            _dmTGService = dMTGService;
            LoadData();
        }

        private void LoadData()
        {
            var tygiaList = _dmTGService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, tygiaList);
        }
    }
}
