using QuanLyShop.DAO;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.BUS
{
    internal class BaoCaoBUS
    {
        public List<KhachHang> GetAll()
        {
            List<KhachHang> khs = new BaoCaoDAO().SellectAll();
            return khs;
        }
    }
}
