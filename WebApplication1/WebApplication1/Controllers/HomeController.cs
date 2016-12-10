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
        public ActionResult Index() {

            EventViewModel model = new EventViewModel();
            model.events = db.Event.ToList();
            
            return View(model);
        }



    }
}
