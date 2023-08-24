using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.DAO
{
    internal class NhanVienDAO
    {
        QLBHDataContext db = new QLBHDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<NhanVien> SellectAll()
        {

            List<NhanVien> NhanViens = db.NhanViens.ToList();
            return NhanViens;
        }
        public NhanVien SelectByCode(int MaNV)
        {

            NhanVien nv = db.NhanViens.SingleOrDefault(x => x.MaNV == MaNV);
            return nv;
        }

        public bool Insert(NhanVien newNhanVien)
        {
            try
            {
                db.NhanViens.InsertOnSubmit(newNhanVien);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(NhanVien newNhanVien)
        {


            NhanVien lstNhanVien = db.NhanViens.SingleOrDefault(b => b.MaNV == newNhanVien.MaNV);
            if (lstNhanVien != null)
            {
                try
                {
                    lstNhanVien.MaNV = newNhanVien.MaNV;
                    lstNhanVien.HoTen = newNhanVien.HoTen;
                    lstNhanVien.GioiTinh = newNhanVien.GioiTinh;
                    lstNhanVien.DiaChi = newNhanVien.DiaChi;
                    lstNhanVien.SoDienThoai = newNhanVien.SoDienThoai;
                    lstNhanVien.NgaySinh = newNhanVien.NgaySinh;            
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }

        public bool Delete(int MaNV)
        {

            NhanVien lstNhanVien = db.NhanViens.SingleOrDefault(b => b.MaNV == MaNV);
            if (lstNhanVien != null)
            {
                try
                {
                    db.NhanViens.DeleteOnSubmit(lstNhanVien);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;

        }
        public List<NhanVien> SelectByKeyword(string keyword)
        {
            List<NhanVien> nvs = db.NhanViens.Where(b => b.HoTen.Contains(keyword)).ToList();
            return nvs;
        }
    }
}
