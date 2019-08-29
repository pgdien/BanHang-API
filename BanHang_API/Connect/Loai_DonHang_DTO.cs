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
        public Loai_DonHang getLoai_DonHang(int id)
        {
            Loai_DonHang lLoai_DonHang = new Loai_DonHang();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT LOAIDH_ID, TEN_LDH FROM LOAI_DH where LOAIDH_ID=@LOAIDH_ID";
                    cmd.Parameters.Add(new MySqlParameter("LOAIDH_ID", id));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lLoai_DonHang=(new Loai_DonHang
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
        public int addLoaiDonHang(Loai_DonHang loai_DH)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO LOAI_DH(LOAIDH_ID, TEN_LDH) VALUES (@TEN_LDH)";
                    cmd.Parameters.Add(new MySqlParameter("TEN_LDH", loai_DH.TEN_LDH));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    kq = cmd.ExecuteNonQuery();
                }
                connMySQL.Close();
            }
            return kq;
        }
    }
}
