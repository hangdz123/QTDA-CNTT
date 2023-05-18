using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLQP.Models;
namespace QLQP.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult CuaHang(int? page)
        {
            ViewBag.page = page??1;
            WebNCEntities1 db = new WebNCEntities1();
            //lấy ra ds các sp
            List<SanPham> KetQua = db.SanPhams.ToList();
            return View(KetQua);
        }

        public ActionResult SanPham(int id)
        {
            WebNCEntities1 db = new WebNCEntities1();
            SanPham KetQua = db.SanPhams.Find(id);
            return View(KetQua);
        }


    }
}