using BanHang_API.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BanHang_API.Connect
{
    public class DonHang_DTO
    {
        public List<DonHang> getDonHang(string value)
        {
            List<DonHang> lDonHang = new List<DonHang>();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    switch (value)
                    {
                        case "All":
                            cmd.CommandText = "SELECT DONHANG_ID, KHACHHANG_ID, NGAY_LAP, LOAIDH_ID, TTDH_ID, MA_DH, STT FROM DONHANG";
                            break;
                        case "Nhập":
                            cmd.CommandText = "SELECT DONHANG_ID, KHACHHANG_ID, NGAY_LAP, LOAIDH_ID, TTDH_ID, MA_DH, STT, GHICHU, (select sum(ct.TONGTIEN) from CHITIET_DH ct where dh.DONHANG_ID=ct.DONHANG_ID) TIEN FROM DONHANG dh WHERE dh.LOAIDH_ID=1";
                            break;
                        case "Xuất":
                            cmd.CommandText = "SELECT DONHANG_ID, KHACHHANG_ID, NGAY_LAP, LOAIDH_ID, TTDH_ID, MA_DH, STT, GHICHU, (select sum(ct.TONGTIEN) from CHITIET_DH ct where dh.DONHANG_ID=ct.DONHANG_ID) TIEN FROM DONHANG dh WHERE dh.LOAIDH_ID=2";
                            break;
                    }
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
                                STT = reader.GetInt32(reader.GetOrdinal("STT")),
                                GHICHU = reader.GetString(reader.GetOrdinal("GHICHU")),
                                TIEN = reader.IsDBNull(reader.GetOrdinal("TIEN")) ? 0 : reader.GetDouble(reader.GetOrdinal("TIEN"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lDonHang;
        }

        public DonHang getDonHang(int id)
        {
            DonHang lDonHang = new DonHang();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT DONHANG_ID, KHACHHANG_ID, NGAY_LAP, LOAIDH_ID, TTDH_ID, MA_DH, STT, GHICHU, (select sum(ct.TONGTIEN) from CHITIET_DH ct where dh.DONHANG_ID=@DONHANG_ID";
                    cmd.Parameters.Add(new MySqlParameter("DONHANG_ID", id));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lDonHang = (new DonHang
                            {
                                DONHANG_ID = reader.GetInt32(reader.GetOrdinal("DONHANG_ID")),
                                KHACHHANG_ID = reader.IsDBNull(reader.GetOrdinal("KHACHHANG_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("KHACHHANG_ID")),
                                NGAY_LAP = reader.GetDateTime(reader.GetOrdinal("NGAY_LAP")),
                                LOAIDH_ID = reader.GetInt32(reader.GetOrdinal("LOAIDH_ID")),
                                TTDH_ID = reader.GetInt32(reader.GetOrdinal("TTDH_ID")),
                                MA_DH = reader.GetString(reader.GetOrdinal("MA_DH")),
                                STT = reader.GetInt32(reader.GetOrdinal("STT")),
                                GHICHU = reader.GetString(reader.GetOrdinal("GHICHU")),
                                TIEN = reader.IsDBNull(reader.GetOrdinal("TIEN")) ? 0 : reader.GetDouble(reader.GetOrdinal("TIEN"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lDonHang;
        }
        public int addDonHang(DonHang DH)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO DONHANG(KHACHHANG_ID, NGAY_LAP, LOAIDH_ID, TTDH_ID, MA_DH, STT, GHICHU) " +
                                                    "VALUES (@KHACHHANG_ID, @NGAY_LAP, @LOAIDH_ID, @TTDH_ID, @MA_DH, @STT, @GHICHU)";
                    cmd.Parameters.Add(new MySqlParameter("KHACHHANG_ID", DH.KHACHHANG_ID));
                    cmd.Parameters.Add(new MySqlParameter("NGAY_LAP", DH.NGAY_LAP));
                    cmd.Parameters.Add(new MySqlParameter("LOAIDH_ID", DH.LOAIDH_ID));
                    cmd.Parameters.Add(new MySqlParameter("TTDH_ID", DH.TTDH_ID));
                    cmd.Parameters.Add(new MySqlParameter("MA_DH", DH.MA_DH));
                    cmd.Parameters.Add(new MySqlParameter("STT", DH.STT));
                    cmd.Parameters.Add(new MySqlParameter("GHICHU", DH.GHICHU));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    kq = cmd.ExecuteNonQuery();
                }
                connMySQL.Close();
            }
            return kq;
        }
        public int editDonHang(DonHang DH)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "UPDATE DONHANG SET KHACHHANG_ID=@KHACHHANG_ID,NGAY_LAP=@NGAY_LAP,LOAIDH_ID=@LOAIDH_ID,TTDH_ID=@TTDH_ID,MA_DH=@MA_DH,STT=@STT,GHICHU=@GHICHU WHERE DONHANG_ID=@DONHANG_ID";
                    cmd.Parameters.Add(new MySqlParameter("KHACHHANG_ID", DH.KHACHHANG_ID));
                    cmd.Parameters.Add(new MySqlParameter("NGAY_LAP", DH.NGAY_LAP));
                    cmd.Parameters.Add(new MySqlParameter("LOAIDH_ID", DH.LOAIDH_ID));
                    cmd.Parameters.Add(new MySqlParameter("TTDH_ID", DH.TTDH_ID));
                    cmd.Parameters.Add(new MySqlParameter("MA_DH", DH.MA_DH));
                    cmd.Parameters.Add(new MySqlParameter("STT", DH.STT));
                    cmd.Parameters.Add(new MySqlParameter("GHICHU", DH.GHICHU));
                    cmd.Parameters.Add(new MySqlParameter("DONHANG_ID", DH.DONHANG_ID));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    kq = cmd.ExecuteNonQuery();
                }
                connMySQL.Close();
            }
            return kq;
        }
        public int delDonHang(int id)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM DONHANG WHERE DONHANG_ID=@DONHANG_ID";
                    cmd.Parameters.Add(new MySqlParameter("DONHANG_ID", id));
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
