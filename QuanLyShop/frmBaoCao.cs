using Microsoft.Reporting.WinForms;
using QuanLyShop.BUS;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShop
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            
                
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            List<KhachHang> khs = new BaoCaoBUS().GetAll();

            // Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rptKhachHang.ProcessingMode = ProcessingMode.Local;
            //Đường dẫn báo cáo
            rptKhachHang.LocalReport.ReportPath = "rptKhachHang.rdlc";
            //Nếu có dữ liệu

            //Tạo nguồn dữ liệu cho báo cáo
            ReportDataSource rds = new ReportDataSource("tbKhachHang", khs);

            //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
            rptKhachHang.LocalReport.DataSources.Clear();
            //Add dữ liệu vào báo cáo
            rptKhachHang.LocalReport.DataSources.Add(rds);
            //Refresh lại báo cáo
            rptKhachHang.RefreshReport();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Hide();
        }
    }
}
