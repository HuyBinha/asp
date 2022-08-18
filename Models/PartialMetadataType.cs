using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Tran_Huy_Binh.Context;
using Tran_Huy_Binh.Models;


namespace Tran_Huy_Binh.Context
{
    [MetadataType(typeof(UserMasterData))]
    public  partial class User
    {
       
    }

    public partial class ProductMasterData
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}