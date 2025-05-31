using GPBH.Business;
using GPBH.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class MainForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductService _productService;
        public MainForm(IUnitOfWork unitOfWork, ProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;

            InitializeComponent();
            var products = _productService.GetAll();
            dataGridView1.DataSource = products;

            // call form con
            var form1 = ActivatorUtilities.CreateInstance<Form1>(Program.ServiceProvider, "123");
        }
    }
}