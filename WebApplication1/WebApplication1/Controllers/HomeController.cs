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
            logboek newlb = new logboek();
            newlb.EventID = 1;
            newlb.UserID = "jasper";
            newlb.Organize = 1;
            db.logboek.Add(newlb);
            db.SaveChanges();
            EventViewModel model = new EventViewModel();
            model.events = db.Event.ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult GetView(string id, string name ,string start, string end)
        {
            DateTime beginDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            System.Diagnostics.Debug.WriteLine("getview!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            System.Diagnostics.Debug.WriteLine(start);
            System.Diagnostics.Debug.WriteLine(beginDate);
            System.Diagnostics.Debug.WriteLine(end);
            System.Diagnostics.Debug.WriteLine(endDate);
            EventViewModel model = new EventViewModel();
            if (String.IsNullOrEmpty(id))
            {
                if (String.IsNullOrEmpty(name))
                {
                    model.events = db.Event.Where(e => e.EventBeginDate >= beginDate && e.EventBeginDate <= endDate).ToList();
                }
                else
                {
                    model.events = db.Event.Where(e => e.EventName.Contains(name)&& e.EventBeginDate >= beginDate && e.EventBeginDate <= endDate).ToList();
                }
            }
            else
            {
                if (String.IsNullOrEmpty(name))
                {
                    model.events = db.Event.Where(e => e.EventLocation.Contains(id) && e.EventBeginDate >= beginDate && e.EventBeginDate <= endDate).ToList();
                }
                else
                {
                    model.events = db.Event.Where(e => e.EventLocation.Contains(id) && e.EventBeginDate >= beginDate && e.EventBeginDate <= endDate  && e.EventName.Contains(name)).ToList();
                }
                }
                
           
            return PartialView("~/Views/Home/_Events.cshtml", model);
        }

    }
}
