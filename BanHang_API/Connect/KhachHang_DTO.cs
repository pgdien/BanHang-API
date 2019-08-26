﻿using BanHang_API.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang_API.Connect
{
    public class KhachHang_DTO
    {
        public List<KhachHang> getKhachHang()
        {
            List<KhachHang> lKhachhang = new List<KhachHang>();
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT KHACHHANG_ID, MA_KH, TEN_KH, SDT, GHICHU FROM KHACHHANG";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lKhachhang.Add(new KhachHang
                            {
                                KHACHHANG_ID = reader.GetInt32(reader.GetOrdinal("KHACHHANG_ID")),
                                MA_KH = reader.GetString(reader.GetOrdinal("MA_KH")),
                                TEN_KH = reader.GetString(reader.GetOrdinal("TEN_KH")),
                                SDT = reader.GetString(reader.GetOrdinal("SDT")),
                                GHICHU = reader.GetString(reader.GetOrdinal("GHICHU"))
                            });
                        }
                    }
                }
                connMySQL.Close();
            }
            return lKhachhang;
        }
    }
}
