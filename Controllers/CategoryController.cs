using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tran_Huy_Binh.Context;

namespace Tran_Huy_Binh.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities2 objWebsiteBanHangEntities2 = new WebsiteBanHangEntities2();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objWebsiteBanHangEntities2.Categories.ToList();
            
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objWebsiteBanHangEntities2.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
    }
}