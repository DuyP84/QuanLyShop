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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyShop
{
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            tvPhongBan.CheckBoxes = true;

            PhongBanBUS pvBUS = new PhongBanBUS();
            List<PhongBan> pbList = pvBUS.GetAll();
            foreach (var pb in pbList)
            {
                TreeNode node = new TreeNode();

                node.Text = pb.TenPhong;
                node.Tag = pb.MaPhong;

                TreeNode childNode = new TreeNode();
                //viet cau query lay danh sach cate con cap 2 cau3 cate.CategoryID
                //childNode.Text = pb.TenPhong + "";
                //childNode.Tag = pb.MaPhong;
                node.Nodes.Add(childNode);
                tvPhongBan.Nodes.Add(node);

            }
            //tvPhongBan.SelectedNode = tvPhongBan.Nodes[1];
            //tvPhongBan.SelectedNode.Expand();
        }

        
    }
}
