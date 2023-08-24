using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyShop.DAO;
using QuanLyShop.DTO;

namespace QuanLyShop.BUS
{
    internal class LoginBUS
    {
        public DataTable Login(DangNhap user)
        {
            DataTable dt = new LoginDAO().login(user);
            return dt;
        }
    }
}
