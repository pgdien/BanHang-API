using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
