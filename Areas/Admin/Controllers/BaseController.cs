using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tran_Huy_Binh.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public ActionResult Index()
        {
            return View();
        }
    }
}