using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
namespace WebApplication1.Controllers
{
    public class EventController : Controller
    {
        Account account = new Account(
            "zomomo",
            "161964652558563",
            "nCU9Op7zsyop4KYoZ44hSMaBM08");

        
        private webtechEntities db = new webtechEntities();


        [HttpPost]
        public ActionResult FileUpload(EventViewModel model)
        {
            if (model.ImageUpload != null)
            {
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.Actions.FileDescription(model.ImageUpload.FileName,
                        model.ImageUpload.InputStream)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
               model.ev.EventPicture = uploadResult.PublicId;
               db.Event.Add(model.ev);
                db.SaveChanges();
                return RedirectToAction("CreateEvent", "Event");
            }
            else {
               return  RedirectToAction("Index", "Home");
            }
            // after successfully uploading redirect the user
        }
        [HttpGet]
        public ActionResult FileUpload()
        {
            return View("no model found");
        }
        // GET: Event
        public ActionResult CreateEvent()
        {
            return View(new EventViewModel());
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