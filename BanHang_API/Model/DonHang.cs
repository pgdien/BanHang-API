using System;
using System.Collections.Generic;

namespace BanHang_API.Model
{
    public class DonHang
    {
        public DonHang()
        { }
        public int DONHANG_ID
        { get; set; }
        public int KHACHHANG_ID
        { get; set; }
        public DateTime NGAY_LAP
        { get; set; }
        public int LOAIDH_ID
        { get; set; }
        public int TTDH_ID
        { get; set; }
        public string MA_DH
        { get; set; }
        public int STT
        { get; set; }
        public string GHICHU
        { get; set; }
        public Double TIEN
        { get; set; }
        public List<CT_DonHang> LIST_CT_HD
        { get; set; }
    }
}
