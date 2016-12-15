using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {

        private webtechEntities db = new webtechEntities();
        public ActionResult Index()
        {

            EventViewModel model = new EventViewModel();
            model.events = db.Event.ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult GetView(string id, string name)
        {

            System.Diagnostics.Debug.WriteLine("getview!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            System.Diagnostics.Debug.WriteLine(id);
            EventViewModel model = new EventViewModel();
            if (String.IsNullOrEmpty(id))
            {
                if (String.IsNullOrEmpty(name))
                {
                    model.events = db.Event.ToList();
                }
                else
                {
                    model.events = db.Event.Where(e => e.EventName.Contains(name)).ToList();
                }
            }
            else
            {
                if (String.IsNullOrEmpty(name))
                {
                    model.events = db.Event.Where(e => e.EventLocation.Contains(id)).ToList();
                }
                else
                {
                    model.events = db.Event.Where(e => e.EventLocation.Contains(id) && e.EventName.Contains(name)).ToList();
                }
                }
                
           
            return PartialView("~/Views/Home/_Events.cshtml", model);
        }

    }
}
