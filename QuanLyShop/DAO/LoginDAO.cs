using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyShop.DTO;
namespace QuanLyShop.DAO
{
    internal class LoginDAO
    {
        public DataTable login(DangNhap user)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=quanly;Persist Security Info=True;User ID=sa;Password=1");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From DangNhap where ID='" + user.ID + "'and Password = '" + user.Password + "'", con);

            sda.Fill(dt);
            return dt;
        }
    }
}
