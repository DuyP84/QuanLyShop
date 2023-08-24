using QuanLyShop.DAO;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.BUS
{
    internal class PhongBanBUS
    {
        public List<PhongBan> GetAll()
        {
            List<PhongBan> pbs = new PhongBanDAO().SellectAll();
            return pbs;
        }
    }
}
