using DevComponents.Editors;
using System;

namespace GPBH.UI.Extentions
{
    public static class DoubleInputExtention
    {
        public static void DisplayFormat(this DoubleInput value, string format = "#,##0")
        {
            value.DisplayFormat = format;
            value.Value = Math.Round(value.Value);
        }
    }
}
