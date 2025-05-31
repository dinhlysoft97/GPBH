using GPBH.Business;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class Form1 : Form
    {
        public Form1(ProductService _productService, string id)
        {
            InitializeComponent();
            var a = _productService.GetAll();
        }
    }
}
