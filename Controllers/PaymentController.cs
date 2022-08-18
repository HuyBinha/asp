using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tran_Huy_Binh.Context;
using Tran_Huy_Binh.Models;

namespace Tran_Huy_Binh.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanHangEntities2 objWebsiteBanHangEntities2 = new WebsiteBanHangEntities2();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                Order objOrder = new Order();
                objOrder.Name = "Đơn Hàng-" + DateTime.Now.ToString("yyyyMMddHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objWebsiteBanHangEntities2.Orders.Add(objOrder);
                objWebsiteBanHangEntities2.SaveChanges();

                int intOrderId = objOrder.Id;
                List<OrderDetail> LstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.Orderld = intOrderId;
                    obj.ProductId = item.Product.Id;
                    LstOrderDetail.Add(obj);

                }
                objWebsiteBanHangEntities2.OrderDetails.AddRange(LstOrderDetail);
                objWebsiteBanHangEntities2.SaveChanges();
            }

            return View();
        }
    }
}