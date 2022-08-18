using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tran_Huy_Binh.Context;

namespace Tran_Huy_Binh.Models
{
    public class HomeModel
    {
        public List<Product> ListProducts { get; set; }
        public List<Category> ListCategory { get; set; }

    }
}