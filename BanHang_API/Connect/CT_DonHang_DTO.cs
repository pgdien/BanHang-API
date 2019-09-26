using BanHang_API.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BanHang_API.Connect
{
    public class CT_DonHang_DTO
    {
        public List<CT_DonHang> getCT_DonHang()
        {
            List<CT_DonHang> lCT_DonHang = new List<CT_DonHang>();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT CTDH_ID, CTDH_CHA_ID, DONHANG_ID, HANGHOA_ID, DONGIA, SOLUONG, TONGTIEN, THUCTHU, TIEN_CONGTHEM, GHICHU FROM CHITIET_DH";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lCT_DonHang.Add(new CT_DonHang
                            {
                                CTDH_ID = reader.GetInt32(reader.GetOrdinal("CTDH_ID")),
                                CTDH_CHA_ID = reader.IsDBNull(reader.GetOrdinal("CTDH_CHA_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CTDH_CHA_ID")),
                                DONHANG_ID = reader.GetInt32(reader.GetOrdinal("DONHANG_ID")),
                                HANGHOA_ID = reader.GetInt32(reader.GetOrdinal("HANGHOA_ID")),
                                DONGIA = reader.GetFloat(reader.GetOrdinal("DONGIA")),
                                SOLUONG = reader.GetFloat(reader.GetOrdinal("SOLUONG")),
                                TONGTIEN = reader.GetFloat(reader.GetOrdinal("TONGTIEN")),
                                THUCTHU = reader.GetFloat(reader.GetOrdinal("THUCTHU")),
                                TIEN_CONGTHEM = reader.GetFloat(reader.GetOrdinal("TIEN_CONGTHEM")),
                                GHICHU = reader.GetString(reader.GetOrdinal("GHICHU"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lCT_DonHang;
        }
        public CT_DonHang getCT_DonHang(int id)
        {
            CT_DonHang lCT_DonHang = new CT_DonHang();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT CTDH_ID, CTDH_CHA_ID, DONHANG_ID, HANGHOA_ID, DONGIA, SOLUONG, TONGTIEN, THUCTHU, TIEN_CONGTHEM, GHICHU FROM CHITIET_DH where CTDH_ID=@CTDH_ID";
                    cmd.Parameters.Add(new MySqlParameter("CTDH_ID", id));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lCT_DonHang = (new CT_DonHang
                            {
                                CTDH_ID = reader.GetInt32(reader.GetOrdinal("CTDH_ID")),
                                CTDH_CHA_ID = reader.IsDBNull(reader.GetOrdinal("CTDH_CHA_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CTDH_CHA_ID")),
                                DONHANG_ID = reader.GetInt32(reader.GetOrdinal("DONHANG_ID")),
                                HANGHOA_ID = reader.GetInt32(reader.GetOrdinal("HANGHOA_ID")),
                                DONGIA = reader.GetFloat(reader.GetOrdinal("DONGIA")),
                                SOLUONG = reader.GetFloat(reader.GetOrdinal("SOLUONG")),
                                TONGTIEN = reader.GetFloat(reader.GetOrdinal("TONGTIEN")),
                                THUCTHU = reader.GetFloat(reader.GetOrdinal("THUCTHU")),
                                TIEN_CONGTHEM = reader.GetFloat(reader.GetOrdinal("TIEN_CONGTHEM")),
                                GHICHU = reader.GetString(reader.GetOrdinal("GHICHU"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lCT_DonHang;
        }
        public List<CT_DonHang> getCT_DonHang(string donHang_id)
        {
            List<CT_DonHang> lCT_DonHang = new List<CT_DonHang>();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT CTDH_ID, CTDH_CHA_ID, DONHANG_ID, HANGHOA_ID, DONGIA, SOLUONG, TONGTIEN, THUCTHU, TIEN_CONGTHEM, GHICHU, (SELECT hh.TEN_HH FROM HANGHOA hh WHERE hh.HANGHOA_ID=ct.DONHANG_ID) TEN_HH FROM CHITIET_DH ct where DONHANG_ID=@DONHANG_ID";
                    cmd.Parameters.Add(new MySqlParameter("DONHANG_ID", donHang_id));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lCT_DonHang.Add(new CT_DonHang
                            {
                                CTDH_ID = reader.GetInt32(reader.GetOrdinal("CTDH_ID")),
                                CTDH_CHA_ID = reader.IsDBNull(reader.GetOrdinal("CTDH_CHA_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CTDH_CHA_ID")),
                                DONHANG_ID = reader.GetInt32(reader.GetOrdinal("DONHANG_ID")),
                                HANGHOA_ID = reader.GetInt32(reader.GetOrdinal("HANGHOA_ID")),
                                DONGIA = reader.GetFloat(reader.GetOrdinal("DONGIA")),
                                SOLUONG = reader.GetFloat(reader.GetOrdinal("SOLUONG")),
                                TONGTIEN = reader.GetFloat(reader.GetOrdinal("TONGTIEN")),
                                THUCTHU = reader.GetFloat(reader.GetOrdinal("THUCTHU")),
                                TIEN_CONGTHEM = reader.GetFloat(reader.GetOrdinal("TIEN_CONGTHEM")),
                                GHICHU = reader.GetString(reader.GetOrdinal("GHICHU")),
                                TEN_HH = reader.GetString(reader.GetOrdinal("TEN_HH"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lCT_DonHang;
        }
        public int addCT_DonHang(CT_DonHang ct_DH)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CHITIET_DH(CTDH_CHA_ID, DONHANG_ID, HANGHOA_ID, DONGIA, SOLUONG, TONGTIEN, THUCTHU, TIEN_CONGTHEM, GHICHU) V" +
                                                    "ALUES (@CTDH_CHA_ID, @DONHANG_ID, @HANGHOA_ID, @DONGIA, @SOLUONG, @TONGTIEN, @THUCTHU, @TIEN_CONGTHEM, @GHICHU)";
                    cmd.Parameters.Add(new MySqlParameter("CTDH_CHA_ID", ct_DH.CTDH_CHA_ID));
                    cmd.Parameters.Add(new MySqlParameter("DONHANG_ID", ct_DH.DONHANG_ID));
                    cmd.Parameters.Add(new MySqlParameter("HANGHOA_ID", ct_DH.HANGHOA_ID));
                    cmd.Parameters.Add(new MySqlParameter("DONGIA", ct_DH.DONGIA));
                    cmd.Parameters.Add(new MySqlParameter("SOLUONG", ct_DH.SOLUONG));
                    cmd.Parameters.Add(new MySqlParameter("TONGTIEN", ct_DH.TONGTIEN));
                    cmd.Parameters.Add(new MySqlParameter("THUCTHU", ct_DH.THUCTHU));
                    cmd.Parameters.Add(new MySqlParameter("TIEN_CONGTHEM", ct_DH.TIEN_CONGTHEM));
                    cmd.Parameters.Add(new MySqlParameter("GHICHU", ct_DH.GHICHU));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    kq = cmd.ExecuteNonQuery();
                }
                connMySQL.Close();
            }
            return kq;
        }
        public int editCT_DonHang(CT_DonHang ct_DH)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CHITIET_DH SET CTDH_CHA_ID=@CTDH_CHA_ID,DONHANG_ID=@DONHANG_ID,HANGHOA_ID=@HANGHOA_ID,DONGIA=@DONGIA,SOLUONG=@SOLUONG," +
                        "TONGTIEN=@TONGTIEN,THUCTHU=@THUCTHU,TIEN_CONGTHEM=@TIEN_CONGTHEM,GHICHU=@GHICHU WHERE CTDH_ID=@CTDH_ID";
                    cmd.Parameters.Add(new MySqlParameter("CTDH_CHA_ID", ct_DH.CTDH_CHA_ID));
                    cmd.Parameters.Add(new MySqlParameter("DONHANG_ID", ct_DH.DONHANG_ID));
                    cmd.Parameters.Add(new MySqlParameter("HANGHOA_ID", ct_DH.HANGHOA_ID));
                    cmd.Parameters.Add(new MySqlParameter("DONGIA", ct_DH.DONGIA));
                    cmd.Parameters.Add(new MySqlParameter("SOLUONG", ct_DH.SOLUONG));
                    cmd.Parameters.Add(new MySqlParameter("TONGTIEN", ct_DH.TONGTIEN));
                    cmd.Parameters.Add(new MySqlParameter("THUCTHU", ct_DH.THUCTHU));
                    cmd.Parameters.Add(new MySqlParameter("TIEN_CONGTHEM", ct_DH.TIEN_CONGTHEM));
                    cmd.Parameters.Add(new MySqlParameter("GHICHU", ct_DH.GHICHU));
                    cmd.Parameters.Add(new MySqlParameter("CTDH_ID", ct_DH.CTDH_ID));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    kq = cmd.ExecuteNonQuery();
                }
                connMySQL.Close();
            }
            return kq;
        }
        public int delCT_DonHang(int id)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM CHITIET_DH WHERE CTDH_ID=@CTDH_ID";
                    cmd.Parameters.Add(new MySqlParameter("CTDH_ID", id));
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
