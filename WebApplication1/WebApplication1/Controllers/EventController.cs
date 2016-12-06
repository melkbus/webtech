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
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
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