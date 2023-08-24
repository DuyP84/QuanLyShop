using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.DAO
{
    internal class KhachHangDAO
    {
        QLBHDataContext db = new QLBHDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<KhachHang> SellectAll()
        {

            List<KhachHang> KhachHangs = db.KhachHangs.ToList();
            return KhachHangs;
        }
        public KhachHang SelectByCode(int MaKH)
        {

            KhachHang kh = db.KhachHangs.SingleOrDefault(x => x.MaKH == MaKH);
            return kh;
        }

        public bool Insert(KhachHang newKhachHang)
        {
            try
            {
                db.KhachHangs.InsertOnSubmit(newKhachHang);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(KhachHang newKhachHang)
        {


            KhachHang dgvKhachHang = db.KhachHangs.SingleOrDefault(b => b.MaKH == newKhachHang.MaKH);
            if (dgvKhachHang != null)
            {
                try
                {
                    dgvKhachHang.MaKH = newKhachHang.MaKH;
                    dgvKhachHang.HoTen = newKhachHang.HoTen;
                    dgvKhachHang.DiaChi = newKhachHang.DiaChi;
                    dgvKhachHang.GioiTinh = newKhachHang.GioiTinh;
                    dgvKhachHang.SoDienThoai = newKhachHang.SoDienThoai;
                    dgvKhachHang.NgaySinh = newKhachHang.NgaySinh;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }

        public bool Delete(int MaKH)
        {

            KhachHang dgvKhachHang = db.KhachHangs.SingleOrDefault(b => b.MaKH == MaKH);
            if (dgvKhachHang != null)
            {
                try
                {
                    db.KhachHangs.DeleteOnSubmit(dgvKhachHang);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;

        }
        public List<KhachHang> SelectByKeyword(string keyword)
        {
            List<KhachHang> khs = db.KhachHangs.Where(b => b.HoTen.Contains(keyword)).ToList();
            return khs;
        }
    }
}
