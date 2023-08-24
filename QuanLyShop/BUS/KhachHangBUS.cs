using QuanLyShop.DAO;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.BUS
{
    internal class KhachHangBUS
    {
        public List<KhachHang> GetAll()
        {
            List<KhachHang> khs = new KhachHangDAO().SellectAll();
            return khs;
        }
        public KhachHang GetDetails(int MaKH)
        {
            KhachHang kh = new KhachHangDAO().SelectByCode(MaKH);
            return kh;
        }
        public bool AddNew(KhachHang newKhachHang)
        {
            bool result = new KhachHangDAO().Insert(newKhachHang);
            return result;
        }
        public bool Update(KhachHang newKhachHang)
        {
            bool result = new KhachHangDAO().Update(newKhachHang);
            return result;
        }

        public bool Delete(int MaKH)
        {
            bool result = new KhachHangDAO().Delete(MaKH);
            return result;
        }

        public List<KhachHang> Search(String keyword)
        {
            List<KhachHang> KhachHangs = new KhachHangDAO().SelectByKeyword(keyword);
            return KhachHangs;
        }
    }
}
