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
        public ActionResult FileUpload(EventCreateViewModel model)
        {
            Event ev = new Event
            {
                EventName = model.EventName,
                EventDescription = model.EventDiscription,
                EventDate = model.EventDate,
                EventLocation = model.EventLocation,
                EventPrice = model.EventPrice

            };
            if (model.ImageUpload != null)
            {
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.Actions.FileDescription(model.ImageUpload.FileName,
                        model.ImageUpload.InputStream)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                ev.EventPicture = uploadResult.PublicId;

            }
            else
            {
                ev.EventPicture = "sample";
            }

            db.Event.Add(ev);
            db.SaveChanges();
            return RedirectToAction("CreateEvent", "Event");
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
            return View(new EventCreateViewModel());
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