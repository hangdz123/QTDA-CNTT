using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QLQP.Models;
namespace QLQP.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Admin/DangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DangNhap data)
        {
            WebNCEntities1 db = new WebNCEntities1();
            if(ModelState.IsValid)
            {
                int dem = db.DangNhaps.Count(x => x.TaiKhoan == data.TaiKhoan && x.MatKhau == data.MatKhau);
                if(dem == 1)
                {
                    //Đăng Nhập thành công
                    FormsAuthentication.SetAuthCookie(data.TaiKhoan, false);
                    return RedirectToAction("TrangChu", "Home");
                }
                else
                {
                    //đăng nhập thất bại
                    ModelState.AddModelError("", "Tài Khoản hoặc mật khẩu không chính xác!!");
                }
            }
            return View(data);
        }
    }
}