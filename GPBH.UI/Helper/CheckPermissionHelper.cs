using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.UI.Constant;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Helper
{
    public static class CheckPermissionHelper
    {
        public static bool HasPerrmission(string menuId, string action)
        {
            // Nếu là admin thì luôn có quyền
            if (AppGlobals.CurrentUser.IsAdmin)
            {
                return true;
            }

            // Tìm quyền theo menuId
            var permission = AppGlobals.CurrentUser.SysPhanQuyens.FirstOrDefault(z => z.MenuId == menuId);
            if (permission == null)
            {
                return false;
            }

            // Kiểm tra quyền cụ thể theo action
            switch (action)
            {
                case GPBHConstant.Action.Xem:
                    return permission.Xem == true;
                case GPBHConstant.Action.Them:
                    return permission.Them == true;
                case GPBHConstant.Action.Sua:
                    return permission.Sua == true;
                case GPBHConstant.Action.Xoa:
                    return permission.Xoa == true;
                case GPBHConstant.Action.In:
                    return permission.In == true;
                case GPBHConstant.Action.Excel:
                    return permission.Excel == true;
                default:
                    return false;
            }
        }

        public static void ShowMessage(string message = "Bạn không có quyền truy cập vào chức năng này!")
        {
            // Hiển thị thông báo cho người dùng
            MessageBoxEx.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
