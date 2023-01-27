using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Icon
{
    public class IconsBoxicons : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("icons-boxicons")]
        public ActionResult iconsboxicons()
        {
            return View();
        }
    }
}
