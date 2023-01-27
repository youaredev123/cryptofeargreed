using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvatuBinanceBot.FileManager
{
    public class FileManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
