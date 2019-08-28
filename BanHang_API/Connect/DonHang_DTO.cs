using BanHang_API.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang_API.Connect
{
    public class DonHang_DTO
    {
        public List<DonHang> getDonHang()
        {
            List<DonHang> lDonHang = new List<DonHang>();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT DONHANG_ID, KHACHHANG_ID, NGAY_LAP, LOAIDH_ID, TTDH_ID, MA_DH, STT FROM DONHANG";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lDonHang.Add(new DonHang
                            {
                                DONHANG_ID = reader.GetInt32(reader.GetOrdinal("DONHANG_ID")),
                                KHACHHANG_ID = reader.IsDBNull(reader.GetOrdinal("KHACHHANG_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("KHACHHANG_ID")),
                                NGAY_LAP = reader.GetDateTime(reader.GetOrdinal("NGAY_LAP")),
                                LOAIDH_ID = reader.GetInt32(reader.GetOrdinal("LOAIDH_ID")),
                                TTDH_ID = reader.GetInt32(reader.GetOrdinal("TTDH_ID")),
                                MA_DH = reader.GetString(reader.GetOrdinal("MA_DH")),
                                STT = reader.GetInt32(reader.GetOrdinal("STT"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lDonHang;
        }
    }
}
