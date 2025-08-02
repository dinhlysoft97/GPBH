using DevComponents.DotNetBar.Controls;
using GPBH.Data.Configurations;
using GPBH.UI.Extentions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public class ucHangHoa : UserControl
    {
        private ToolStripDropDown tsDropDown = new ToolStripDropDown();
        private TextBox tb = new TextBox();
        private readonly Panel sPanel = new Panel();
        private readonly DataGridViewX dgv = new DataGridViewX();
        private readonly Button Button1 = new Button();

        // Dữ liệu mẫu
        private List<DMHH> dsHangHoa;

        public TextBox Tb { get => tb; set => tb = value; }
        public ToolStripDropDown TsDropDown { get => tsDropDown; set => tsDropDown = value; }
        public Button Button { get => Button1; set => Button = value; }
        public bool HasHangHoa { get; set; }

        public ucHangHoa()
        {
            InitializeComponent();

            this.Load += ucTextGrid2_Load;
            Tb.Location = new Point(0, 0);
            Tb.Size = new Size(150, 20);
            Button1.Text = "X";
            Button1.TextAlign = ContentAlignment.MiddleCenter;
            Button1.Location = new Point(Tb.Right + 5, Tb.Top + 2);
            Button1.Padding = new Padding(0, 0, 0, 0);
            Button1.Size = new Size(25, 20);
            this.Controls.Add(Tb);
            this.Controls.Add(Button1);
            this.Size = new Size(600, 50); // Tăng kích thước UserControl

            Tb.TextChanged += tb_TextChanged;
            Tb.KeyDown += Tb_KeyDown_DownUp;
            Button1.Click += Button1_Click;
            LoadDataCombox();

            // Thêm sự kiện click row
            dgv.CellClick += dgv_CellClick;
            dgv.KeyDown += TsDropDown_KeyDown;
            dgv.RowPostPaint += dataGridViewX1_RowPostPaint;
            TsDropDown.KeyDown += TsDropDown_KeyDown;
        }

        private void TsDropDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int rowIndex = dgv.CurrentCell?.RowIndex ?? -1;
                if (rowIndex == -1) return;
                var row = dgv.Rows[rowIndex];
                string maHH = row.Cells["Ma_hh"].Value?.ToString();
                string tenHH = row.Cells["Ten_hh"].Value?.ToString();
                string dvt = row.Cells["Dvt"].Value?.ToString();

                // Gọi event để notify ra ngoài
                HangHoaSelected?.Invoke(this, new HangHoaSelectedEventArgs
                {
                    MaHH = maHH,
                    TenHH = tenHH,
                    Dvt = dvt
                });

                // Đóng dropdown sau khi chọn
                TsDropDown.Close();
            }
            if (e.KeyCode == Keys.Down)
            {
                if (dgv.Rows.Count > 0)
                {
                    int rowIndex = dgv.CurrentCell?.RowIndex ?? -1;
                    int nextRow = Math.Min(rowIndex + 1, dgv.Rows.Count - 1);
                    dgv.CurrentCell = dgv.Rows[nextRow].Cells[0];
                    dgv.Rows[nextRow].Selected = true;

                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgv.Rows.Count > 0)
                {
                    int rowIndex = dgv.CurrentCell?.RowIndex ?? 0;
                    int prevRow = Math.Max(rowIndex - 1, 0);
                    dgv.CurrentCell = dgv.Rows[prevRow].Cells[0];
                    dgv.Rows[prevRow].Selected = true;
                }
                e.Handled = true;
            }
        }

        public void Tb_KeyDown_DownUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgv.Rows.Count > 0)
                {
                    int rowIndex = dgv.CurrentCell?.RowIndex ?? -1;
                    int nextRow = Math.Min(rowIndex + 1, dgv.Rows.Count - 1);
                    dgv.CurrentCell = dgv.Rows[nextRow].Cells[0];
                    dgv.Rows[nextRow].Selected = true;

                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgv.Rows.Count > 0)
                {
                    int rowIndex = dgv.CurrentCell?.RowIndex ?? 0;
                    int prevRow = Math.Max(rowIndex - 1, 0);
                    dgv.CurrentCell = dgv.Rows[prevRow].Cells[0];
                    dgv.Rows[prevRow].Selected = true;
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int rowIndex = dgv.CurrentCell?.RowIndex ?? -1;
                if (rowIndex == -1) return;
                var row = dgv.Rows[rowIndex];
                string maHH = row.Cells["Ma_hh"].Value?.ToString();
                string tenHH = row.Cells["Ten_hh"].Value?.ToString();
                string dvt = row.Cells["Dvt"].Value?.ToString();

                // Gọi event để notify ra ngoài
                HangHoaSelected?.Invoke(this, new HangHoaSelectedEventArgs
                {
                    MaHH = maHH,
                    TenHH = tenHH,
                    Dvt = dvt
                });

                // Đóng dropdown sau khi chọn
                TsDropDown.Close();
            }
        }

        public void Tb_KeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HasHangHoa = false;
                int rowIndex = dgv.CurrentCell?.RowIndex ?? -1;
                if (rowIndex == -1) return;
                var row = dgv.Rows[rowIndex];
                string maHH = row.Cells["Ma_hh"].Value?.ToString();
                string tenHH = row.Cells["Ten_hh"].Value?.ToString();
                string dvt = row.Cells["Dvt"].Value?.ToString();

                // Gọi event để notify ra ngoài
                HangHoaSelected?.Invoke(this, new HangHoaSelectedEventArgs
                {
                    MaHH = maHH,
                    TenHH = tenHH,
                    Dvt = dvt
                });
                HasHangHoa = true;
                // Đóng dropdown sau khi chọn
                TsDropDown.Close();

                //var hh = dsHangHoa.FirstOrDefault(x => x.Ma_hh == Tb.Text.Trim());
                //if (hh != null)
                //{
                //    HasHangHoa = true;
                //    HangHoaSelected?.Invoke(this, new HangHoaSelectedEventArgs
                //    {
                //        MaHH = hh.Ma_hh,
                //        TenHH = hh.Ten_hh,
                //        Dvt = hh.Dvt
                //    });
                //}
                //else
                //{
                //    HasHangHoa = false;
                //}
            }
        }

        private void ucTextGrid2_Load(object sender, EventArgs e)
        {
            Build_SearchControls();

            Form frm = this.FindForm();
            if (frm != null)
            {
                frm.Click += (s, ev) => TsDropDown.Close();
                frm.Move += (s, ev) => TsDropDown.Close();
            }
        }

        public void ShowDropDown()
        {
            if (!TsDropDown.Visible)
            {
                Point pts = this.PointToScreen(Tb.Location);
                TsDropDown.Show(pts.X, pts.Y + Tb.Height);
            }
            else
            {
                TsDropDown.Close();
            }
        }

        public void SetData(List<DMHH> dMHHs)
        {
            dsHangHoa = dMHHs;
            dgv.DataSource = dsHangHoa;
        }

        private void Build_SearchControls()
        {
            try
            {
                ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();

                sPanel.SuspendLayout();
                sPanel.BorderStyle = BorderStyle.FixedSingle;
                sPanel.Controls.Add(dgv);
                sPanel.Name = "sPanel";
                sPanel.Size = new Size(560, 300); // Tăng kích thước Panel

                dgv.Name = "sDGV";
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgv.Location = new Point(3, 3);
                dgv.Size = new Size(550, 260); // Tăng kích thước DataGridView
                dgv.AutoGenerateColumns = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
                sPanel.ResumeLayout(false);

                Form frm = this.FindForm();
                if (frm != null)
                {
                    dgv.BindingContext = frm.BindingContext;
                }

                ToolStripControlHost tsmiHost = new ToolStripControlHost(sPanel);
                tsmiHost.Margin = Padding.Empty;
                TsDropDown.Padding = Padding.Empty;
                TsDropDown.Items.Add(tsmiHost);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        /// <summary>
        /// Lọc tất cả các cột trên DataGridViewX khi thay đổi text trong TextBox tb
        /// </summary>
        private void tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Point pts = this.PointToScreen(Tb.Location);

                TsDropDown.AutoClose = false;
                TsDropDown.Show(pts.X, pts.Y + Tb.Height);

                string filter = Tb.Text.Trim().ToLower();

                // Gọi event để notify ra ngoài
                TbChange?.Invoke(this, new TextBoxEventArgs
                {
                    Text = filter,
                });

                // Nếu không nhập gì thì hiển thị toàn bộ
                if (string.IsNullOrEmpty(filter))
                {
                    dgv.DataSource = dsHangHoa;
                    return;
                }

                // Lọc tất cả các cột
                var filtered = dsHangHoa.Where(z =>
                    (z.Ma_hh != null && z.Ma_hh.ToLower().Contains(filter)) ||
                    (z.Ten_hh != null && z.Ten_hh.ToLower().Contains(filter)) ||
                    (z.Dvt != null && z.Dvt.ToLower().Contains(filter))
                ).ToList();

                dgv.DataSource = filtered;

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tb.Text = string.Empty;
            tb.Focus();
            TsDropDown.Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ khi click vào header hoặc dòng ngoài dữ liệu
            if (e.RowIndex < 0)
                return;

            // Lấy giá trị của dòng đang chọn
            var row = dgv.Rows[e.RowIndex];
            string maHH = row.Cells["Ma_hh"].Value?.ToString();
            string tenHH = row.Cells["Ten_hh"].Value?.ToString();
            string dvt = row.Cells["Dvt"].Value?.ToString();

            // Gọi event để notify ra ngoài
            HangHoaSelected?.Invoke(this, new HangHoaSelectedEventArgs
            {
                MaHH = maHH,
                TenHH = tenHH,
                Dvt = dvt
            });

            // Đóng dropdown sau khi chọn
            TsDropDown.Close();
        }

        private void LoadDataCombox()
        {
            DataGridViewTextBoxColumn colMa_hh = new DataGridViewTextBoxColumn();
            colMa_hh.Name = "Ma_hh";
            colMa_hh.DataPropertyName = "Ma_hh";
            colMa_hh.HeaderText = "Mã hàng";
            colMa_hh.Width = 100;
            colMa_hh.ReadOnly = true;

            DataGridViewTextBoxColumn colTen_hh = new DataGridViewTextBoxColumn();
            colTen_hh.Name = "Ten_hh";
            colTen_hh.DataPropertyName = "Ten_hh";
            colTen_hh.HeaderText = "Tên hàng";
            colTen_hh.Width = 150;
            colTen_hh.ReadOnly = true;

            DataGridViewTextBoxColumn colDvt = new DataGridViewTextBoxColumn();
            colDvt.Name = "Dvt";
            colDvt.DataPropertyName = "Dvt";
            colDvt.HeaderText = "Đơn vị tính";
            colDvt.Width = 50;
            colTen_hh.ReadOnly = true;

            // Thêm vào DataGridView nếu chưa có
            if (dgv.Columns.Count == 0)
            {
                dgv.Columns.Add(colMa_hh);
                dgv.Columns.Add(colTen_hh);
                dgv.Columns.Add(colDvt);
            }

            // Bind data
            dgv.DataSource = dsHangHoa;
            //DataGridViewFilterHelper.ApplyFillter(dgv, dsHangHoa);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ucTextGrid2
            // 
            this.Name = "ucTextGrid2";
            this.Size = new System.Drawing.Size(324, 26);
            this.ResumeLayout(false);
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.SetRowPositionPaint(e);
        }

        public class HangHoaSelectedEventArgs : EventArgs
        {
            public string MaHH { get; set; }
            public string TenHH { get; set; }
            public string Dvt { get; set; }
        }

        public class TextBoxEventArgs : EventArgs
        {
            public string Text { get; set; }
        }


        public event EventHandler<HangHoaSelectedEventArgs> HangHoaSelected;
        public event EventHandler<TextBoxEventArgs> TbChange;
    }
}