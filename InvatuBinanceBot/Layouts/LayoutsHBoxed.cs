﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Layouts
{
    public class LayoutsHBoxed : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("layout-boxed")]
        public ActionResult layoutboxed()
        {
            TempData["ModeName"] = Contants.LAYOUT_BOXED;
            TempData["WelcomeText"] = "LAYOUTS_BOXED";
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
