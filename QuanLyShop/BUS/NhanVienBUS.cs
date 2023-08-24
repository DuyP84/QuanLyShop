using QuanLyShop.DAO;
using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.BUS
{
    internal class NhanVienBUS
    {
        public List<NhanVien> GetAll()
        {
            List<NhanVien> nvs = new NhanVienDAO().SellectAll();
            return nvs;
        }
        public NhanVien GetDetails(int MaNV)
        {
            NhanVien nv = new NhanVienDAO().SelectByCode(MaNV);
            return nv;
        }
        public bool AddNew(NhanVien newNhanVien)
        {
            bool result = new NhanVienDAO().Insert(newNhanVien);
            return result;
        }
        public bool Update(NhanVien newNhanVien)
        {
            bool result = new NhanVienDAO().Update(newNhanVien);
            return result;
        }

        public bool Delete(int MaNV)
        {
            bool result = new NhanVienDAO().Delete(MaNV);
            return result;
        }

        public List<NhanVien> Search(String keyword)
        {
            List<NhanVien> NhanViens = new NhanVienDAO().SelectByKeyword(keyword);
            return NhanViens;
        }
    }
}
