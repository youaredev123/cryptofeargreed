using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvatuBinanceBot.Tasks
{
    public class TasksList : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("tasks-list")]
        public ActionResult taskslist()
        {
            return View();
        }
    }
}
