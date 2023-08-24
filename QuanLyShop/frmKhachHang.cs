using QuanLyShop.BUS;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShop
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
           
           
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            List<KhachHang> khs = new KhachHangBUS().GetAll();
            dgvKhachHang.DataSource = khs;

        }
        // Kiểm tra thông tin nhập
        public bool Check()
        {
            if (string.IsNullOrEmpty(txtMaKH.Text) ||
                string.IsNullOrEmpty(txtHoTen.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtSDT.Text) ||
                string.IsNullOrEmpty(dtpNgaySinh.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == true)
                {
                    KhachHang newKhachHang = new KhachHang()
                    {
                        MaKH = int.Parse(txtMaKH.Text.Trim()),
                        HoTen = txtHoTen.Text.Trim(),
                        DiaChi = txtDiaChi.Text.Trim(),
                        GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                        SoDienThoai = txtSDT.Text.Trim(),
                        NgaySinh = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString())
                    };
                    bool result = new KhachHangBUS().AddNew(newKhachHang);
                    if (result)
                    {
                        List<KhachHang> khs = new KhachHangBUS().GetAll();
                        dgvKhachHang.DataSource = khs;
                    }
                    else { MessageBox.Show("Hong be oi!"); }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đủ tất cả các trường dữ liệu nhé.!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ???");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int MaKH = int.Parse(txtMaKH.Text);
                bool result = new KhachHangBUS().Delete(MaKH);
                if (result)
                {
                    List<KhachHang> khs = new KhachHangBUS().GetAll();
                    dgvKhachHang.DataSource = khs;
                }
                else { MessageBox.Show("Hong be oi!"); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == true)
                {
                    KhachHang newKhachHang = new KhachHang()
                    {
                        MaKH = int.Parse(txtMaKH.Text.Trim()),
                        HoTen = txtHoTen.Text.Trim(),
                        DiaChi = txtDiaChi.Text.Trim(),
                        GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                        SoDienThoai = txtSDT.Text.Trim(),
                        NgaySinh = dtpNgaySinh.Value
                    };
                    bool result = new KhachHangBUS().Update(newKhachHang);
                    if (result)
                    {
                        List<KhachHang> khs = new KhachHangBUS().GetAll();
                        dgvKhachHang.DataSource = khs;
                    }
                    else { MessageBox.Show("Hong be oi!"); }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đủ tất cả các trường dữ liệu nhé.!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ???");
            }

        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            rdNam.Checked = true;
            dtpNgaySinh.ResetText();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            var frmMain = new frmMain();
            frmMain.Show();
            Hide();
        }

        private void dgvKhachHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaKH.Text = dgvKhachHang.Rows[index].Cells[0].Value.ToString();
                txtHoTen.Text = dgvKhachHang.Rows[index].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[index].Cells[2].Value.ToString();
                rdNam.Checked = dgvKhachHang.Rows[index].Cells[3].Value.ToString() == "Nam";
                rdNu.Checked = dgvKhachHang.Rows[index].Cells[3].Value.ToString() == "Nữ";
                txtSDT.Text = dgvKhachHang.Rows[index].Cells[4].Value.ToString();
                dtpNgaySinh.Text = dgvKhachHang.Rows[index].Cells[5].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String keyword = txtTimKiem.Text.Trim();
            List<KhachHang> khs = new KhachHangBUS().Search(keyword);
            dgvKhachHang.DataSource = khs;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            List<KhachHang> khs = new KhachHangBUS().GetAll();
            dgvKhachHang.DataSource = khs;
        }
    }
}
