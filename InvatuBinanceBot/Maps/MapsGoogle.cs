using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Maps
{
    public class MapsGoogle : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("maps-google")]
        public ActionResult mapsgoogle()
        {
            return View();
        }
    }
}
