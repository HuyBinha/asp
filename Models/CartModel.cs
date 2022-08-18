using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tran_Huy_Binh.Context;

namespace Tran_Huy_Binh.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}