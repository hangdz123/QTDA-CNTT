using QLQP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLQP.Controllers
{
    public class HomezController : Controller
    {
        // GET: Homez
        public ActionResult TrangChu()
        {
            return View();
        }

        public ActionResult HuongDan()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapKH dt)
        {
            WebNCEntities1 db = new WebNCEntities1();
            if (ModelState.IsValid)
            {
                int dem = db.DangNhapKHs.Count(x => x.TenDangNhap == dt.TenDangNhap && x.MatKhau == dt.MatKhau);
                if (dem == 1)
                {
                    //Đăng Nhập thành công
                    FormsAuthentication.SetAuthCookie(dt.TenDangNhap, false);
                    return RedirectToAction("TrangChu", "Homez");
                }
                else
                {
                    //đăng nhập thất bại
                    ModelState.AddModelError("", "Tài Khoản hoặc mật khẩu không chính xác!!");
                }
            }
            return View(dt);
        }
        public ActionResult DangKi()
        {
            return View(new DangNhapKH());
        }

        [HttpPost]
        public ActionResult DangKi(DangNhapKH khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.TenDangNhap)==true)
            {
                ModelState.AddModelError("", "Tên Đăng Nhập Không Được Để Trống!");
                return View(khachHang);
            }
            if (string.IsNullOrEmpty(khachHang.MatKhau) == true)
            {
                ModelState.AddModelError("", "Mật Khẩu Không Được Để Trống!");
                return View(khachHang);
            }
            WebNCEntities1 db = new WebNCEntities1();
            db.DangNhapKHs.Add(khachHang);
            db.SaveChanges();
            return RedirectToAction("DangNhap");
        }


    }
}