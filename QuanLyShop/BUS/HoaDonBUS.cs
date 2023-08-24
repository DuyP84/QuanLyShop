using QuanLyShop.DAO;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.BUS
{
    internal class HoaDonBUS
    {
        public List<HoaDon> GetAll()
        {
            List<HoaDon> hds = new HoaDonDAO().SellectAll();
            return hds;
        }
        public HoaDon GetDetails(int MaHD)
        {
            HoaDon hd = new HoaDonDAO().SelectByCode(MaHD);
            return hd;
        }
        public bool AddNew(HoaDon newHoaDon)
        {
            bool result = new HoaDonDAO().Insert(newHoaDon);
            return result;
        }
        public bool Update(HoaDon newHoaDon)
        {
            bool result = new HoaDonDAO().Update(newHoaDon);
            return result;
        }

        public bool Delete(int MaHD)
        {
            bool result = new HoaDonDAO().Delete(MaHD);
            return result;
        }

        public List<HoaDon> Search(String keyword)
        {
            List<HoaDon> HoaDons = new HoaDonDAO().SelectByKeyword(keyword);
            return HoaDons;
        }
    }
}
