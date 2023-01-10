using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            string todayDate = DateTime.Now.ToShortDateString();
            ViewBag.date = todayDate;
            return View();
        }
    }
}
