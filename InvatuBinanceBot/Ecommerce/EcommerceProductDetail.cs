﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Ecommerce
{
    public class EcommerceProductDetail : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("ecommerce-productdetail")]
        public ActionResult ecommerceproductdetail()
        {
            return View();
        }
    }
}
