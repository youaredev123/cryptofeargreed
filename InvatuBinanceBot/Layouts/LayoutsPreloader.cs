using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Layouts
{
    public class LayoutsPreloader : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("layout-preloader")]
        public ActionResult layoutpreloader()
        {
            TempData["ModeName"] = Contants.LAYOUT_PRELOADER;
            TempData["WelcomeText"] = "LAYOUTS_PRELOADER";
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
