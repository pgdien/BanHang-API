using BanHang_API.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BanHang_API.Connect
{
    public class HangHoa_DTO
    {
        public List<HangHoa> getHangHoa()
        {
            List<HangHoa> lHangHoa = new List<HangHoa>();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT HANGHOA_ID, MA_HH, TEN_HH FROM HANGHOA";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lHangHoa.Add(new HangHoa
                            {
                                HANGHOA_ID = reader.GetInt32(reader.GetOrdinal("HANGHOA_ID")),
                                MA_HH = reader.GetString(reader.GetOrdinal("MA_HH")),
                                TEN_HH = reader.GetString(reader.GetOrdinal("TEN_HH"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lHangHoa;
        }
        public HangHoa getHangHoa(int id)
        {
            HangHoa lHangHoa = new HangHoa();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT HANGHOA_ID, MA_HH, TEN_HH FROM HANGHOA where HANGHOA_ID=@HANGHOA_ID";
                    cmd.Parameters.Add(new MySqlParameter("HANGHOA_ID", id));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lHangHoa = (new HangHoa
                            {
                                HANGHOA_ID = reader.GetInt32(reader.GetOrdinal("HANGHOA_ID")),
                                MA_HH = reader.GetString(reader.GetOrdinal("MA_HH")),
                                TEN_HH = reader.GetString(reader.GetOrdinal("TEN_HH"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lHangHoa;
        }
        public int addHangHoa(HangHoa hh)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO HANGHOA(MA_HH, TEN_HH) VALUES (@MA_HH, @TEN_HH)";
                    cmd.Parameters.Add(new MySqlParameter("MA_HH", hh.MA_HH));
                    cmd.Parameters.Add(new MySqlParameter("TEN_HH", hh.TEN_HH));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    kq = cmd.ExecuteNonQuery();
                }
                connMySQL.Close();
            }
            return kq;
        }
        public int editHangHoa(HangHoa hh)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "UPDATE HANGHOA SET TEN_HH=@TEN_HH WHERE HANGHOA_ID=@HANGHOA_ID";
                    cmd.Parameters.Add(new MySqlParameter("TEN_HH", hh.TEN_HH));
                    cmd.Parameters.Add(new MySqlParameter("HANGHOA_ID", hh.HANGHOA_ID));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    kq = cmd.ExecuteNonQuery();
                }
                connMySQL.Close();
            }
            return kq;
        }
        public int delHangHoa(int id)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM HANGHOA WHERE HANGHOA_ID=@HANGHOA_ID";
                    cmd.Parameters.Add(new MySqlParameter("HANGHOA_ID", id));
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
