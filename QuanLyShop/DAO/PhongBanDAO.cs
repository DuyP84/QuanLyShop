using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.DAO
{
    internal class PhongBanDAO
    {
        QLBHDataContext db = new QLBHDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<PhongBan> SellectAll()
        {

            List<PhongBan> phongBans = db.PhongBans.ToList();
            return phongBans;
        }
    }
}
