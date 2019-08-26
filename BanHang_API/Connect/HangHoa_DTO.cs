using BanHang_API.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
