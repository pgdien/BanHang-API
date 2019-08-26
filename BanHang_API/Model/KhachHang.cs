using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang_API.Model
{
    public class KhachHang
    {
        public KhachHang()
        { }
        public int KHACHHANG_ID
        { get; set; }
        public string MA_KH
        { get; set; }
        public string TEN_KH
        { get; set; }
        public string SDT
        { get; set; }
        public string GHICHU
        { get; set; }
    }
}
