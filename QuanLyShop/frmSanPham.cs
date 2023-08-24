using QuanLyShop.BUS;
using QuanLyShop.DTO;
using QuanLyShop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShop
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            List<SanPham> sps = new SanPhamBUS().GetAll();
            dgvSanPham.DataSource = sps;
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txtMaSP.Text) ||
                string.IsNullOrEmpty(txtTenSP.Text) ||
                string.IsNullOrEmpty(txtGia.Text) ||
                string.IsNullOrEmpty(cbTinhTrang.Text) ||
                string.IsNullOrEmpty(dtpNgayNhap.Text)||
                string.IsNullOrEmpty(txtSoLuongNhap.Text)||
                string.IsNullOrEmpty(txtDaBan.Text))/*||*/
                //string.IsNullOrEmpty(pbAnhSanPham.Text))
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
                    SanPham newSanPham = new SanPham()
                    {
                        MaSP = int.Parse(txtMaSP.Text.Trim()),
                        TenSP = txtTenSP.Text.Trim(),
                        Gia = int.Parse(txtGia.Text.Trim()),
                        TinhTrang = cbTinhTrang.Text.Trim(),
                        NgayNhap = DateTime.Parse(dtpNgayNhap.Value.ToShortDateString()),
                        SoLuongNhap = int.Parse(txtSoLuongNhap.Text.Trim()),
                        DaBan = int.Parse(txtDaBan.Text.Trim()),
                        AnhSanPham = pbAnhSanPham.Text.Trim()

                    };
                    bool result = new SanPhamBUS().AddNew(newSanPham);
                    if (result)
                    {
                        List<SanPham> sps = new SanPhamBUS().GetAll();
                        dgvSanPham.DataSource = sps;
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

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaSP.Text = dgvSanPham.Rows[index].Cells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.Rows[index].Cells[1].Value.ToString();
                txtGia.Text = dgvSanPham.Rows[index].Cells[2].Value.ToString();      
                cbTinhTrang.Text = dgvSanPham.Rows[index].Cells[3].Value.ToString();
                dtpNgayNhap.Text = dgvSanPham.Rows[index].Cells[4].Value.ToString();
                txtSoLuongNhap.Text = dgvSanPham.Rows[index].Cells[5].Value.ToString();
                txtDaBan.Text = dgvSanPham.Rows[index].Cells[6].Value.ToString();
                pbAnhSanPham.Text = dgvSanPham.Rows[index].Cells[7].Value.ToString();

                if (dgvSanPham.Rows[index].Cells[7].Value.ToString() != "")
                    pbAnhSanPham.Image = Image.FromFile(dgvSanPham.Rows[index].Cells[7].Value.ToString());
                else
                    pbAnhSanPham.Image = Resources.noimage;//ảnh mặc định
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == true)
                {
                    SanPham newSanPham = new SanPham()
                    {
                        MaSP = int.Parse(txtMaSP.Text.Trim()),
                        TenSP = txtTenSP.Text.Trim(),
                        Gia = int.Parse(txtGia.Text.Trim()),
                        TinhTrang = cbTinhTrang.Text.Trim(),
                        NgayNhap = DateTime.Parse(dtpNgayNhap.Value.ToShortDateString()),
                        SoLuongNhap = int.Parse(txtSoLuongNhap.Text.Trim()),
                        DaBan = int.Parse(txtDaBan.Text.Trim()),
                        AnhSanPham = pbAnhSanPham.Text.Trim()
                    };
                    bool result = new SanPhamBUS().Update(newSanPham);
                    if (result)
                    {
                        List<SanPham> sps = new SanPhamBUS().GetAll();
                        dgvSanPham.DataSource = sps;
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
                int MaSP = int.Parse(txtMaSP.Text);
                bool result = new SanPhamBUS().Delete(MaSP);
                if (result)
                {
                    List<SanPham> sps = new SanPhamBUS().GetAll();
                    dgvSanPham.DataSource = sps;
                }
                else { MessageBox.Show("Hong be oi!"); }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGia.Clear();
            cbTinhTrang.SelectedIndex = -1;
            dtpNgayNhap.ResetText();
            txtSoLuongNhap.Clear();
            txtDaBan.Clear();
            pbAnhSanPham.Refresh();
            pbAnhSanPham.Image = null;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            var frmMain = new frmMain();
            frmMain.Show();
            Hide();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Choose Image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp;|All Files|*.*";
            ofd.ShowDialog();
            pbAnhSanPham.Text = ofd.FileName;
            if (pbAnhSanPham.Text != "")
            pbAnhSanPham.Image = Image.FromFile(pbAnhSanPham.Text);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String keyword = txtTimKiem.Text.Trim();
            List<SanPham> sps = new SanPhamBUS().Search(keyword);
            dgvSanPham.DataSource = sps;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            List<SanPham> sps = new SanPhamBUS().GetAll();
            dgvSanPham.DataSource = sps;
        }
    }
}
