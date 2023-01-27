using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvatuBinanceBot.Email
{
    public class EmailTemplateBasic : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
