using QuanLyShop.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShop.DAO
{
    internal class SanPhamDAO
    {
        QLBHDataContext db = new QLBHDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<SanPham> SellectAll()
        {

            List<SanPham> SanPhams = db.SanPhams.ToList();
            return SanPhams;
        }
        public SanPham SelectByCode(int MaSP)
        {

            SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSP == MaSP);
            return sp;
        }

        public bool Insert(SanPham newSanPham)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(newSanPham);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(SanPham newSanPham)
        {


            SanPham dgvSanPham = db.SanPhams.SingleOrDefault(b => b.MaSP == newSanPham.MaSP);
            if (dgvSanPham != null)
            {
                try
                {
                    dgvSanPham.MaSP = newSanPham.MaSP;
                    dgvSanPham.TenSP = newSanPham.TenSP;
                    dgvSanPham.Gia = newSanPham.Gia;
                    dgvSanPham.TinhTrang = newSanPham.TinhTrang;
                    dgvSanPham.NgayNhap = newSanPham.NgayNhap;
                    dgvSanPham.SoLuongNhap = newSanPham.SoLuongNhap;
                    dgvSanPham.DaBan = newSanPham.DaBan;
                    dgvSanPham.AnhSanPham = newSanPham.AnhSanPham;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }

        public bool Delete(int MaSP)
        {

            SanPham dgvSanPham = db.SanPhams.SingleOrDefault(b => b.MaSP == MaSP);
            if (dgvSanPham != null)
            {
                try
                {
                    db.SanPhams.DeleteOnSubmit(dgvSanPham);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;

        }
        public List<SanPham> SelectByKeyword(string keyword)
        {
            List<SanPham> sps = db.SanPhams.Where(b => b.TenSP.Contains(keyword)).ToList();
            return sps;
        }
    }
}
