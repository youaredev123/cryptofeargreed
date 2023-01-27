using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Invoices
{
    public class InvoicesDetail : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("invoices-detail")]
        public ActionResult invoicesdetail()
        {
            return View();
        }
    }
}
