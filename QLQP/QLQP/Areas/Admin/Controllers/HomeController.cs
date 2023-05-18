using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLQP.Areas.Admin.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult TongQuan()
        {
            return View();
        }
    }
}