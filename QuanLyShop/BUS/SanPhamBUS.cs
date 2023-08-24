using QuanLyShop.DAO;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.BUS
{
    internal class SanPhamBUS
    {
        public List<SanPham> GetAll()
        {
            List<SanPham> sps = new SanPhamDAO().SellectAll();
            return sps;
        }
        public SanPham GetDetails(int MaSP)
        {
            SanPham sp = new SanPhamDAO().SelectByCode(MaSP);
            return sp;
        }
        public bool AddNew(SanPham newSanPham)
        {
            bool result = new SanPhamDAO().Insert(newSanPham);
            return result;
        }
        public bool Update(SanPham newSanPham)
        {
            bool result = new SanPhamDAO().Update(newSanPham);
            return result;
        }

        public bool Delete(int MaSP)
        {
            bool result = new SanPhamDAO().Delete(MaSP);
            return result;
        }

        public List<SanPham> Search(String keyword)
        {
            List<SanPham> SanPhams = new SanPhamDAO().SelectByKeyword(keyword);
            return SanPhams;
        }
    }
}
