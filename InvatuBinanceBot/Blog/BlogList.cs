using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvatuBinanceBot.Blog
{
    public class BlogList : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
