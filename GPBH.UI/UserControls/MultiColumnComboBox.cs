using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class MultiColumnComboBox : UserControl
    {
      
        private Button btnDrop = new Button();
        private ListView lvDrop = new ListView();
        private ToolStripDropDown dropDown = new ToolStripDropDown();
        private ToolStripControlHost host;
        private List<object> dataSource = new List<object>();
        private int[] columnWidths = null;

        public event EventHandler SelectedValueChanged;

        private List<DisplayColumn> displayColumns = new List<DisplayColumn>();

        public List<DisplayColumn> DisplayColumns
        {
            get => displayColumns;
            set
            {
                displayColumns = value;
                RefreshList();
            }
        }

        private TextBox txtInput = new TextBox();

        public TextBox TxtInput
        {
            get => txtInput;
            set
            {
                txtInput = value;
            }
        }

        public MultiColumnComboBox()
        {
            txtInput.Dock = DockStyle.Fill;
            btnDrop.Dock = DockStyle.Right;
            btnDrop.Width = 24;
            btnDrop.Text = "▼";
            btnDrop.TabStop = false;

            Controls.Add(txtInput);
            Controls.Add(btnDrop);

            lvDrop.View = View.Details;
            lvDrop.FullRowSelect = true;
            lvDrop.MultiSelect = false;
            lvDrop.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvDrop.HideSelection = false;
            lvDrop.BackColor = Color.White;
            lvDrop.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            lvDrop.BorderStyle = BorderStyle.None;
            lvDrop.OwnerDraw = true;
            lvDrop.DrawColumnHeader += LvDrop_DrawColumnHeader;
            lvDrop.DrawSubItem += LvDrop_DrawSubItem;
            lvDrop.MouseDoubleClick += LvDrop_MouseDoubleClick;
            lvDrop.KeyDown += LvDrop_KeyDown;

            host = new ToolStripControlHost(lvDrop)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false
            };
            dropDown.Items.Add(host);

            btnDrop.Click += BtnDrop_Click;
            txtInput.KeyDown += TxtInput_KeyDown;
            txtInput.ReadOnly = false;

            // Khi dropdown đóng, trả focus lại cho textbox
            dropDown.Closed += (s, e) => txtInput.Focus();
        }

        public object SelectedItem { get; private set; }
        public object SelectedValue
        {
            get
            {
                if (SelectedItem == null || string.IsNullOrEmpty(ValueMember)) return null;
                var prop = SelectedItem.GetType().GetProperty(ValueMember);
                return prop?.GetValue(SelectedItem, null);
            }
        }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public int[] ColumnWidths
        {
            get => columnWidths;
            set
            {
                columnWidths = value;
                RefreshList();
            }
        }

        public void SetDataSource<T>(IEnumerable<T> data)
        {
            dataSource = data.Cast<object>().ToList();
            RefreshList();
        }

        private void RefreshList()
        {
            if (displayColumns == null || displayColumns.Count == 0) return;

            lvDrop.BeginUpdate();
            lvDrop.Clear();
            lvDrop.Columns.Clear();

            for (int i = 0; i < displayColumns.Count; i++)
            {
                int width = 100;
                if (columnWidths != null && i < columnWidths.Length)
                    width = columnWidths[i];
                lvDrop.Columns.Add(displayColumns[i].Header, width, HorizontalAlignment.Left);
            }

            foreach (var item in dataSource)
            {
                var values = displayColumns.Select(col =>
                {
                    var prop = item.GetType().GetProperty(col.Property);
                    return prop?.GetValue(item, null)?.ToString() ?? "";
                }).ToArray();
                var lvi = new ListViewItem(values);
                lvi.Tag = item;
                lvDrop.Items.Add(lvi);
            }
            lvDrop.EndUpdate();
        }

        private void BtnDrop_Click(object sender, EventArgs e)
        {
            ShowDropDown();
        }
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ShowDropDown();
                if (lvDrop.Items.Count > 0)
                    lvDrop.Items[0].Selected = true;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                FilterListView(txtInput.Text);
                if (!dropDown.Visible)
                    ShowDropDown();
                e.Handled = true;
            }
        }
        private void FilterListView(string search)
        {
            lvDrop.BeginUpdate();
            lvDrop.Items.Clear();
            foreach (var item in dataSource)
            {
                var values = displayColumns.Select(col =>
                {
                    var prop = item.GetType().GetProperty(col.Property);
                    return prop?.GetValue(item, null)?.ToString() ?? "";
                }).ToArray();
                if (string.IsNullOrEmpty(search) ||
                    values.Any(v => v.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    var lvi = new ListViewItem(values);
                    lvi.Tag = item;
                    lvDrop.Items.Add(lvi);
                }
            }
            lvDrop.EndUpdate();
        }

        private void ShowDropDown()
        {
            if (dataSource == null || dataSource.Count == 0) return;
            host.Size = new Size(Width, 180);
            lvDrop.Size = host.Size;
            if (!dropDown.Visible)
            {
                dropDown.Show(this, new Point(0, Height));
            }
            // KHÔNG gọi lvDrop.Focus() để tránh steal focus TextBox
        }
        private void LvDrop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvDrop.SelectedItems.Count > 0)
                SelectItem(lvDrop.SelectedItems[0]);
        }

        private void LvDrop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lvDrop.SelectedItems.Count > 0)
            {
                SelectItem(lvDrop.SelectedItems[0]);
                e.Handled = true;
            }
        }

        private void SelectItem(ListViewItem lvi)
        {
            SelectedItem = lvi.Tag;
            if (!string.IsNullOrEmpty(DisplayMember))
            {
                var prop = SelectedItem.GetType().GetProperty(DisplayMember);
                txtInput.Text = prop?.GetValue(SelectedItem, null)?.ToString() ?? "";
            }
            else
            {
                txtInput.Text = SelectedItem.ToString();
            }
            dropDown.Close();
            SelectedValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LvDrop_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var bg = new SolidBrush(Color.FromArgb(235, 235, 242)))
                e.Graphics.FillRectangle(bg, e.Bounds);
            using (var pen = new Pen(Color.LightGray))
                e.Graphics.DrawRectangle(pen, e.Bounds);
            using (var font = new Font(e.Font, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.DimGray))
                e.Graphics.DrawString(e.Header.Text, font, brush, e.Bounds);
        }

        private void LvDrop_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            bool isSelected = (e.Item.Selected && lvDrop.Focused);
            var bgColor = isSelected ? Color.FromArgb(204, 231, 255) : Color.White;
            using (var bg = new SolidBrush(bgColor))
                e.Graphics.FillRectangle(bg, e.Bounds);

            var foreColor = isSelected ? Color.Black : Color.Black;
            using (var brush = new SolidBrush(foreColor))
                e.Graphics.DrawString(e.SubItem.Text, e.Item.Font, brush, e.Bounds);
        }

        [Serializable]
        public class DisplayColumn
        {
            public string Header { get; set; }
            public string Property { get; set; }
            public int Width { get; set; }
        }
    }
}