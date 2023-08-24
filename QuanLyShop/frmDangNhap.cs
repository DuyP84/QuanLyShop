using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyShop.DTO;
using QuanLyShop.BUS;
using QuanLyShop.Properties;

namespace QuanLyShop
{
    public partial class frmDangNhap : Form
    {
        char passwordChar = '*';
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = passwordChar;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DangNhap user = new DangNhap();
            user.ID = txtID.Text.Trim();
            user.Password = txtPassword.Text.Trim();
            dt = new LoginBUS().Login(user);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Login Success");
                this.Hide();
                frmMain frmMain = new frmMain();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("UserName and Password Invalid!");
                
            }
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want exit ?",
                "Notification",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void sanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXemMatKhau_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar.Equals(passwordChar))
            {
                txtPassword.PasswordChar = new char();
                btnXemMatKhau.Image = Resources.eye_open16x16;
            }
            else
            {
                txtPassword.PasswordChar = passwordChar;
                btnXemMatKhau.Image = Resources.eye_close16x16;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
