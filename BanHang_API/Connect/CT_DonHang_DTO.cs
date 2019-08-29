using System;
using System.Collections.Generic;
using BanHang_API.Model;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
                            lCT_DonHang.Add(new CT_DonHang { CTDH_ID = reader.GetInt32(reader.GetOrdinal("CTDH_ID")), 
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
                            lCT_DonHang=(new CT_DonHang
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
        public int addCT_DonHang(CT_DonHang ct_DH)
        {
            int kq;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CHITIET_DH(CTDH_ID, CTDH_CHA_ID, DONHANG_ID, HANGHOA_ID, DONGIA, SOLUONG, TONGTIEN, THUCTHU, TIEN_CONGTHEM, GHICHU) V" +
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
    }
}
