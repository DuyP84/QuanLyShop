using QuanLyShop.BUS;
using QuanLyShop.DTO;
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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            List<HoaDon> hds = new HoaDonBUS().GetAll();
            dgvHoaDon.DataSource = hds;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HoaDon newHoaDon = new HoaDon()
            {         
                MaHD = int.Parse(txtMaHD.Text.Trim()),
                MaNV = int.Parse(txtMaNV.Text.Trim()),
                MaKH = int.Parse(txtMaKH.Text.Trim()),
                NgayBan = txtNgayBan.Text.Trim(),
                TongTien = txtTongTien.Text.Trim()
            };
            bool result = new HoaDonBUS().AddNew(newHoaDon);
            if (result)
            {
                List<HoaDon> hds = new HoaDonBUS().GetAll();
                dgvHoaDon.DataSource = hds;
            }
            else { MessageBox.Show("Hong be oi!"); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            HoaDon newHoaDon = new HoaDon()
            {
                MaHD = int.Parse(txtMaHD.Text.Trim()),
                MaNV = int.Parse(txtMaNV.Text.Trim()),
                MaKH = int.Parse(txtMaKH.Text.Trim()),
                NgayBan = txtNgayBan.Text.Trim(),
                TongTien = txtTongTien.Text.Trim()
            };
            bool result = new HoaDonBUS().Update(newHoaDon);
            if (result)
            {
                List<HoaDon> hds = new HoaDonBUS().GetAll();
                dgvHoaDon.DataSource = hds;
            }
            else { MessageBox.Show("Hong be oi!"); }
        }
    

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int MaHD = int.Parse(txtMaHD.Text);
                bool result = new HoaDonBUS().Delete(MaHD);
                if (result)
                {
                    List<HoaDon> hds = new HoaDonBUS().GetAll();
                    dgvHoaDon.DataSource = hds;
                }
                else { MessageBox.Show("Hong be oi!"); }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<HoaDon> hds = new HoaDonBUS().Search(keyword);
            dgvHoaDon.DataSource = hds;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaHD.Text = dgvHoaDon.Rows[index].Cells[0].Value.ToString();
                txtMaNV.Text = dgvHoaDon.Rows[index].Cells[1].Value.ToString();
                txtMaKH.Text = dgvHoaDon.Rows[index].Cells[2].Value.ToString();
                txtNgayBan.Text = dgvHoaDon.Rows[index].Cells[3].Value.ToString();
                txtTongTien.Text = dgvHoaDon.Rows[index].Cells[4].Value.ToString();
                
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            List<HoaDon> hds = new HoaDonBUS().GetAll();
            dgvHoaDon.DataSource = hds;
        }
    }
}
