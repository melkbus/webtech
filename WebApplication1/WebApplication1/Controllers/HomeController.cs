using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
namespace WebApplication1.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        static Cloudinary m_cloudinary;

        private webtechEntities db = new webtechEntities();
        public ActionResult Index() {

            LoginViewModel model = new LoginViewModel();
            try { model.events = db.Event.ToList(); }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return View(model);
        }



    }
}
