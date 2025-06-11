using DevComponents.DotNetBar;
using GPBH.Business.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace GPBH.UI.Extentions
{
    public static class FormExtention
    {
        public static T ShowForm<T>(this Form form, params object[] args) where T : Form
        {
            if (form is null)
            {
                throw new BadRequestException(nameof(form));
            }
           
            var formNew = ActivatorUtilities.CreateInstance<T>(Program.ServiceProvider, args);
            formNew.ShowDialog();
            return formNew;
        }

        public static T ShowForm<T>(this UserControl uc, params object[] args) where T : Form
        {
            if (uc is null)
            {
                throw new BadRequestException(nameof(uc));
            }

            var formNew = ActivatorUtilities.CreateInstance<T>(Program.ServiceProvider, args);
            formNew.ShowDialog();
            return formNew;
        }

        public static void ColseForm(this Form form)
        {
            var result = MessageBoxEx.Show("Bạn có chắc chắn muốn đóng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                form.Close();
            }
        }
    }
}
