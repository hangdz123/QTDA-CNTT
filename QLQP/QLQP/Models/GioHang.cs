using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLQP.Models
{
    public class GioHang
    {
        public long SanPham_ID { get; set; }
        public int SoLuong { get; set; }
        public SanPham CTSanPham { get; set; }
    }
}