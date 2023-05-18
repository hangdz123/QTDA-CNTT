using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLQP.Models;
namespace QLQP.Controllers
{

    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult ThemVaoGio(long SanPham_ID)
        {
            WebNCEntities1 db = new WebNCEntities1();
            List<GioHang> lstGioHang = (List<GioHang>)Session["lstGioHang"];
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
            }
            GioHang obj = lstGioHang.FirstOrDefault(x => x.SanPham_ID == SanPham_ID);
            if (obj != null)
            {
                obj.SoLuong = obj.SoLuong + 1;
            }
            else
            {
                SanPham sp = db.SanPhams.First(x => x.ID == SanPham_ID);
                obj = new GioHang();
                obj.SanPham_ID = SanPham_ID;
                obj.CTSanPham = sp;
                obj.SoLuong = 1;
                lstGioHang.Add(obj);
            }
            Session["lstGioHang"] = lstGioHang;
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = (List<GioHang>)Session["lstGioHang"];
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
            }
            return View(lstGioHang);
        }

        
    }
}