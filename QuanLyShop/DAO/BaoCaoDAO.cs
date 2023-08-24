using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.DAO
{
    internal class BaoCaoDAO
    {
        QLBHDataContext db = new QLBHDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<KhachHang> SellectAll()
        {
            List<KhachHang> KhachHangs = db.KhachHangs.ToList();
            return KhachHangs;
        }
    }
}
