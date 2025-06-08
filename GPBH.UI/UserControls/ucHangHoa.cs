using DevComponents.DotNetBar.Controls;
using GPBH.Business.DTO;
using GPBH.UI.Helper;
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
        private Panel sPanel = new Panel();
        private DataGridViewX dgv = new DataGridViewX();
        private ToolStripDropDown tsDropDown = new ToolStripDropDown();
        private TextBox tb = new TextBox();
        private Button Button1 = new Button();

        // Dữ liệu mẫu
        private List<DMHHDto> dsHangHoa = new List<DMHHDto>();

        public TextBox Tb { get => tb; set => tb = value; }
        public ToolStripDropDown TsDropDown { get => tsDropDown; set => tsDropDown = value; }

        public ucHangHoa()
        {
            dsHangHoa = new List<DMHHDto>() {
                new DMHHDto { Ma_hh = "HH01", Ten_hh = "Hàng hóa 01", Dvt = "KG" },
                new DMHHDto { Ma_hh = "HH02", Ten_hh = "Hàng hóa 02", Dvt = "KG" },
                new DMHHDto { Ma_hh = "HH03", Ten_hh = "Hàng hóa 03", Dvt = "KG" },
            };

            InitializeComponent();

            this.Load += ucTextGrid2_Load;
            Tb.Location = new Point(0, 0);
            Tb.Size = new Size(150, 20);
            Button1.Text = "Close";
            Button1.Location = new Point(Tb.Right + 5, Tb.Top);
            Button1.Size = new Size(60, 23);
            this.Controls.Add(Tb);
            //this.Controls.Add(Button1);
            this.Size = new Size(600, 50); // Tăng kích thước UserControl

            Tb.TextChanged += tb_TextChanged;
            Button1.Click += Button1_Click;
            LoadDataCombox();

            // Thêm sự kiện click row
            dgv.CellClick += dgv_CellClick;
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

        public class HangHoaSelectedEventArgs : EventArgs
        {
            public string MaHH { get; set; }
            public string TenHH { get; set; }
            public string Dvt { get; set; }
        }

        public event EventHandler<HangHoaSelectedEventArgs> HangHoaSelected;
    }
}