using BanHang_API.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang_API.Connect
{
    public class Loai_DonHang_DTO
    {
        public List<Loai_DonHang> getLoai_DonHang()
        {
            List<Loai_DonHang> lLoai_DonHang = new List<Loai_DonHang>();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT LOAIDH_ID, TEN_LDH FROM LOAI_DH";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lLoai_DonHang.Add(new Loai_DonHang
                            {
                                LOAIDH_ID = reader.GetInt32(reader.GetOrdinal("LOAIDH_ID")),
                                TEN_LDH = reader.GetString(reader.GetOrdinal("TEN_LDH"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lLoai_DonHang;
        }
    }
}
