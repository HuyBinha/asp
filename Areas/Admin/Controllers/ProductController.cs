using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tran_Huy_Binh.Context;
using static Tran_Huy_Binh.Common;

namespace Tran_Huy_Binh.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        WebsiteBanHangEntities2 objWebsiteBanHangEntities2 = new WebsiteBanHangEntities2();


        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = objWebsiteBanHangEntities2.Products.ToList();


            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpLoad != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                        fileName = fileName + extension + "" + long.Parse(DateTime.Now.ToString("yyyMMddhhmmss"));
                        objProduct.Avartar = fileName;
                        objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    objWebsiteBanHangEntities2.Products.Add(objProduct);
                    objWebsiteBanHangEntities2.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }

            }

            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpLoad != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                        fileName = fileName + extension;
                        objProduct.Avartar = fileName;
                        objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    objWebsiteBanHangEntities2.Products.Add(objProduct);
                    objWebsiteBanHangEntities2.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objProduct);
        }

        void LoadData()
        {
            Common objCommon = new Common();
            var lstCat = objWebsiteBanHangEntities2.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            var lstBrand = objWebsiteBanHangEntities2.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = objWebsiteBanHangEntities2.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objWebsiteBanHangEntities2.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objWebsiteBanHangEntities2.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebsiteBanHangEntities2.Products.Remove(objProduct);
            objWebsiteBanHangEntities2.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objWebsiteBanHangEntities2.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Edit(int id, Product objProduct)
        {
            if (objProduct.ImageUpLoad != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoad.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpLoad.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objProduct.Avartar = fileName;
                objProduct.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebsiteBanHangEntities2.Entry(objProduct).State = EntityState.Modified;
            objWebsiteBanHangEntities2.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
