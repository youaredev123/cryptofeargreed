using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Chat
{
    public class Chat : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
