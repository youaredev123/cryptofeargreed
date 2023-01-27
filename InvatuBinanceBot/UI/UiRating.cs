using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.UI
{
    public class UiRating : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("ui-rating")]
        public ActionResult uirating()
        {
            return View();
        }
    }
}
