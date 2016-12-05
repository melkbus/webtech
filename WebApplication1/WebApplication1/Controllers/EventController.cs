using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class EventController : Controller
    {
        private webtechEntities db = new webtechEntities();

        // GET: Event
        public ActionResult CreateEvent()
        {
            return View();
        }

        // GET: /Account/Register
         
        [AllowAnonymous]
        public ActionResult ViewEvent(int id)
        {
            return View(db.Event.Find(id));
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