using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.DAO
{
    internal class HoaDonDAO
    {
        QLBHDataContext db = new QLBHDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<HoaDon> SellectAll()
        {

            List<HoaDon> HoaDons = db.HoaDons.ToList();
            return HoaDons;
        }
        public HoaDon SelectByCode(int MaHD)
        {

            HoaDon hd = db.HoaDons.SingleOrDefault(x => x.MaHD == MaHD);
            return hd;
        }

        public bool Insert(HoaDon newHoaDon)
        {
            try
            {
                db.HoaDons.InsertOnSubmit(newHoaDon);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(HoaDon newHoaDon)
        {


            HoaDon dgvHoaDon = db.HoaDons.SingleOrDefault(b => b.MaHD == newHoaDon.MaHD);
            if (dgvHoaDon != null)
            {
                try
                {
                    dgvHoaDon.MaHD = newHoaDon.MaHD;
                    dgvHoaDon.MaNV = newHoaDon.MaNV;
                    dgvHoaDon.MaKH = newHoaDon.MaKH;
                    dgvHoaDon.NgayBan = newHoaDon.NgayBan;
                    dgvHoaDon.TongTien = newHoaDon.TongTien;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }

        public bool Delete(int MaHD)
        {

            HoaDon dgvHoaDon = db.HoaDons.SingleOrDefault(b => b.MaHD == MaHD);
            if (dgvHoaDon != null)
            {
                try
                {
                    db.HoaDons.DeleteOnSubmit(dgvHoaDon);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;

        }
        public List<HoaDon> SelectByKeyword(string keyword)
        {
            List<HoaDon> hds = db.HoaDons.Where(b => b.NgayBan.Contains(keyword)).ToList();
            return hds;
        }
    }
}
