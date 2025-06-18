using GPBH.Business.Services;
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

namespace GPBH.UI.Forms
{
    public partial class QuocGia : Form
    {
        private readonly DMQGService _dmQGService;
        public QuocGia(DMQGService dmQGService)
        {
            InitializeComponent();
            _dmQGService = dmQGService;
            LoadData();
        }
        private void LoadData()
        {
            var quocgiList = _dmQGService.GetAll();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, quocgiList);
        }
    }
}
