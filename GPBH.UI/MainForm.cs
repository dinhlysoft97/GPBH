using GPBH.Business;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class MainForm : Form
    {
        public MainForm(SysDMNSDService sysDMNSDService)
        {
            InitializeComponent();
            sysDMNSDService.DoiMatKhau("admin", "admin");
        }
    }
}