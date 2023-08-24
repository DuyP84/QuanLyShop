using QuanLyShop.BUS;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyShop
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            lstNhanVien.Columns[0].Width = (int)(lstNhanVien.Width * 0.15);
            lstNhanVien.Columns[1].Width = (int)(lstNhanVien.Width * 0.20);
            lstNhanVien.Columns[2].Width = (int)(lstNhanVien.Width * 0.15);
            lstNhanVien.Columns[3].Width = (int)(lstNhanVien.Width * 0.20);
            lstNhanVien.Columns[4].Width = (int)(lstNhanVien.Width * 0.15);
            lstNhanVien.Columns[5].Width = (int)(lstNhanVien.Width * 0.12);
            lstNhanVien.View = View.Details;
            lstNhanVien.GridLines = true;
            lstNhanVien.FullRowSelect = true;


            NhanVienBUS nvBus = new NhanVienBUS();
            List<NhanVien> nvList = nvBus.GetAll();
            int i = 0;
            foreach (NhanVien n in nvList)
            {
                ListViewItem item = new ListViewItem(n.HoTen);
                item.ImageIndex = i;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                subItem1.Name = "MaNV";
                subItem1.Text = n.MaNV.ToString();
                item.SubItems.Add(subItem1);

                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                subItem2.Name = "GioiTinh";
                subItem2.Text = n.GioiTinh.ToString();
                item.SubItems.Add(subItem2);

                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                subItem3.Name = "DiaChi";
                subItem3.Text = n.DiaChi.ToString();
                item.SubItems.Add(subItem3);

                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                subItem4.Name = "SoDienThoai";
                subItem4.Text = n.SoDienThoai.ToString();
                item.SubItems.Add(subItem4);

                ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                subItem5.Name = "NgaySinh";
                subItem5.Text = n.NgaySinh.ToString();
                item.SubItems.Add(subItem5);

                ListViewItem.ListViewSubItem subItem6 = new ListViewItem.ListViewSubItem();
                subItem6.Name = "MaPhong";
                subItem6.Text = n.MaPhong.ToString();
                item.SubItems.Add(subItem6);

                lstNhanVien.Items.Add(item);
                i++;
            }
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text) ||
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
                    NhanVien newNhanVien = new NhanVien()
                    {
                        MaNV = int.Parse(txtMaNV.Text.Trim()),
                        HoTen = txtHoTen.Text.Trim(),
                        DiaChi = txtDiaChi.Text.Trim(),
                        GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                        SoDienThoai = txtSDT.Text.Trim(),
                        NgaySinh = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString())
                    };
                    bool result = new NhanVienBUS().AddNew(newNhanVien);
                    if (result)
                    {
                        lstNhanVien.Items.Clear();
                        NhanVienBUS nvBus = new NhanVienBUS();
                        List<NhanVien> nvList = nvBus.GetAll();
                        int i = 0;
                        foreach (NhanVien n in nvList)
                        {
                            ListViewItem item = new ListViewItem(n.HoTen);
                            item.ImageIndex = i;

                            ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                            subItem1.Name = "MaNV";
                            subItem1.Text = n.MaNV.ToString();
                            item.SubItems.Add(subItem1);

                            ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                            subItem2.Name = "GioiTinh";
                            subItem2.Text = n.GioiTinh.ToString();
                            item.SubItems.Add(subItem2);

                            ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                            subItem3.Name = "DiaChi";
                            subItem3.Text = n.DiaChi.ToString();
                            item.SubItems.Add(subItem3);

                            ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                            subItem4.Name = "SoDienThoai";
                            subItem4.Text = n.SoDienThoai.ToString();
                            item.SubItems.Add(subItem4);

                            ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                            subItem5.Name = "NgaySinh";
                            subItem5.Text = n.NgaySinh.ToString();
                            item.SubItems.Add(subItem5);

                            lstNhanVien.Items.Add(item);
                            i++;
                        }
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
                int MaNV = int.Parse(txtMaNV.Text);
                bool result = new NhanVienBUS().Delete(MaNV);
                if (result)
                {
                    lstNhanVien.Items.Clear();
                    NhanVienBUS nvBus = new NhanVienBUS();
                    List<NhanVien> nvList = nvBus.GetAll();
                    int i = 0;
                    foreach (NhanVien n in nvList)
                    {
                        ListViewItem item = new ListViewItem(n.HoTen);
                        item.ImageIndex = i;

                        ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                        subItem1.Name = "MaNV";
                        subItem1.Text = n.MaNV.ToString();
                        item.SubItems.Add(subItem1);

                        ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                        subItem2.Name = "GioiTinh";
                        subItem2.Text = n.GioiTinh.ToString();
                        item.SubItems.Add(subItem2);

                        ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                        subItem3.Name = "DiaChi";
                        subItem3.Text = n.DiaChi.ToString();
                        item.SubItems.Add(subItem3);

                        ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                        subItem4.Name = "SoDienThoai";
                        subItem4.Text = n.SoDienThoai.ToString();
                        item.SubItems.Add(subItem4);

                        ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                        subItem5.Name = "NgaySinh";
                        subItem5.Text = n.NgaySinh.ToString();
                        item.SubItems.Add(subItem5);

                        lstNhanVien.Items.Add(item);
                        i++;
                    }
                }
                else { MessageBox.Show("Hong be oi!"); }
            }
        }

        private void lstNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNhanVien.SelectedItems.Count > 0)
            {     
                txtHoTen.Text = lstNhanVien.SelectedItems[0].SubItems[0].Text;
                txtMaNV.Text = lstNhanVien.SelectedItems[0].SubItems[1].Text;
                rdNam.Checked = lstNhanVien.SelectedItems[0].SubItems[2].Text == "Nam";
                rdNu.Checked = lstNhanVien.SelectedItems[0].SubItems[2].Text == "Nữ";     
                txtDiaChi.Text = lstNhanVien.SelectedItems[0].SubItems[3].Text;
                txtSDT.Text = lstNhanVien.SelectedItems[0].SubItems[4].Text;
                dtpNgaySinh.Text = lstNhanVien.SelectedItems[0].SubItems[5].Text;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == true)
                {
                    NhanVien newNhanVien = new NhanVien()
                    {
                        MaNV = int.Parse(txtMaNV.Text.Trim()),
                        HoTen = txtHoTen.Text.Trim(),
                        DiaChi = txtDiaChi.Text.Trim(),
                        GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                        SoDienThoai = txtSDT.Text.Trim(),
                        NgaySinh = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString())
                    };
                    bool result = new NhanVienBUS().Update(newNhanVien);
                    if (result)
                    {
                        lstNhanVien.Items.Clear();
                        NhanVienBUS nvBus = new NhanVienBUS();
                        List<NhanVien> nvList = nvBus.GetAll();
                        int i = 0;
                        foreach (NhanVien n in nvList)
                        {
                            ListViewItem item = new ListViewItem(n.HoTen);
                            item.ImageIndex = i;

                            ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                            subItem1.Name = "MaNV";
                            subItem1.Text = n.MaNV.ToString();
                            item.SubItems.Add(subItem1);

                            ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                            subItem2.Name = "GioiTinh";
                            subItem2.Text = n.GioiTinh.ToString();
                            item.SubItems.Add(subItem2);

                            ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                            subItem3.Name = "DiaChi";
                            subItem3.Text = n.DiaChi.ToString();
                            item.SubItems.Add(subItem3);

                            ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                            subItem4.Name = "SoDienThoai";
                            subItem4.Text = n.SoDienThoai.ToString();
                            item.SubItems.Add(subItem4);

                            ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                            subItem5.Name = "NgaySinh";
                            subItem5.Text = n.NgaySinh.ToString();
                            item.SubItems.Add(subItem5);

                            lstNhanVien.Items.Add(item);
                            i++;
                        }
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
            txtMaNV.Clear();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String keyword = txtTimKiem.Text.Trim();
            lstNhanVien.Items.Clear();
            NhanVienBUS nvBus = new NhanVienBUS();
            List<NhanVien> nvList = nvBus.Search(keyword);
            int i = 0;
            foreach (NhanVien n in nvList)
            {
                ListViewItem item = new ListViewItem(n.HoTen);
                item.ImageIndex = i;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                subItem1.Name = "MaNV";
                subItem1.Text = n.MaNV.ToString();
                item.SubItems.Add(subItem1);

                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                subItem2.Name = "GioiTinh";
                subItem2.Text = n.GioiTinh.ToString();
                item.SubItems.Add(subItem2);

                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                subItem3.Name = "DiaChi";
                subItem3.Text = n.DiaChi.ToString();
                item.SubItems.Add(subItem3);

                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                subItem4.Name = "SoDienThoai";
                subItem4.Text = n.SoDienThoai.ToString();
                item.SubItems.Add(subItem4);

                ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                subItem5.Name = "NgaySinh";
                subItem5.Text = n.NgaySinh.ToString();
                item.SubItems.Add(subItem5);

                lstNhanVien.Items.Add(item);
                i++;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            lstNhanVien.Items.Clear();
            NhanVienBUS nvBus = new NhanVienBUS();
            List<NhanVien> nvList = nvBus.GetAll();
            int i = 0;
            foreach (NhanVien n in nvList)
            {
                ListViewItem item = new ListViewItem(n.HoTen);
                item.ImageIndex = i;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                subItem1.Name = "MaNV";
                subItem1.Text = n.MaNV.ToString();
                item.SubItems.Add(subItem1);

                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                subItem2.Name = "GioiTinh";
                subItem2.Text = n.GioiTinh.ToString();
                item.SubItems.Add(subItem2);

                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem();
                subItem3.Name = "DiaChi";
                subItem3.Text = n.DiaChi.ToString();
                item.SubItems.Add(subItem3);

                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem();
                subItem4.Name = "SoDienThoai";
                subItem4.Text = n.SoDienThoai.ToString();
                item.SubItems.Add(subItem4);

                ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem();
                subItem5.Name = "NgaySinh";
                subItem5.Text = n.NgaySinh.ToString();
                item.SubItems.Add(subItem5);

                ListViewItem.ListViewSubItem subItem6 = new ListViewItem.ListViewSubItem();
                subItem6.Name = "MaPhong";
                subItem6.Text = n.MaPhong.ToString();
                item.SubItems.Add(subItem6);


                lstNhanVien.Items.Add(item);
                i++;
            }
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

