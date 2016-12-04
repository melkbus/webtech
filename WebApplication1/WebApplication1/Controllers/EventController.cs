using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult CreateEvent()
        {
            return View();
        }

        public ActionResult ViewEvent()
        {
            return View();
        }
        public ActionResult SearchEvent()
        {
            return View();
        }
        public ActionResult EditEvent()
        {
            return View();
        }
    }
}