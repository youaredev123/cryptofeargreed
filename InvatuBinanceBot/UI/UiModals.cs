﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.UI
{
    public class UiModals : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("ui-modals")]
        public ActionResult uimodals()
        {
            return View();
        }
    }
}
