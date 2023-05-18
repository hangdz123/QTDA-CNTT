using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLQP.Models;
namespace QLQP.Controllers
{
    public class LayoutsController : Controller
    {
        // GET: Layouts
        public ActionResult ListProduct(string Type)
        {
            WebNCEntities1 db = new WebNCEntities1();
            List<SanPham> lst = new List<SanPham>();
            if(Type == "Featured") 
            {
                lst = db.SanPhams.OrderBy(x => x.ID).Take(3).ToList();
            }

            ViewBag.Type = Type;
            return PartialView(lst);
        }

    }
}