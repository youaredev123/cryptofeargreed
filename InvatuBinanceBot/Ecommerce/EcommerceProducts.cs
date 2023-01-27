using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Ecommerce
{
    public class EcommerceProducts : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("ecommerce-products")]
        public ActionResult ecommerceproducts()
        {
            return View();
        }

    }
}
