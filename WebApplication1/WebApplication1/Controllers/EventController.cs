using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Data.Entity.Validation;
using System.Net;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class EventController : Controller
    {
<<<<<<< HEAD
        Account account = new Account(
            "zomomo",
            "161964652558563",
            "nCU9Op7zsyop4KYoZ44hSMaBM08");
=======


>>>>>>> 42828337cb5005f640b48387d34ad3f53039a4e3

        private webtechEntities db = new webtechEntities();

        [HttpPost]
        public ActionResult FileUpload(EventCreateViewModel model)
        {
            Event ev = new Event();
            //System.Diagnostics.Debug.WriteLine("reached here 1---------------------------------------------");
            ev.EventName = model.EventName;
            ev.EventDescription = model.EventDescription;
            ev.EventBeginDate = model.EventBeginDate;
            ev.EventBeginTime = model.EventBeginTime;
            ev.EventEndDate = model.EventEndDate;
            ev.EventEndTime = model.EventEndTime;
            ev.EventLocation = model.EventLocation;
            ev.EventPrice = model.EventPrice;
            //System.Diagnostics.Debug.WriteLine("reached here 2---------------------------------------------");

            if (model.ImageUpload != null)
            {
                Cloudinary cloudinary = new CloudinaryAccount().Cloud;
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

            System.Diagnostics.Debug.WriteLine("name:  \"{0}\" description   \"{1}\" ", ev.EventName, ev.EventDescription);

            db.Event.Add(ev);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return RedirectToAction("CreateEvent", "Event");
            // after successfully uploading redirect the user
        }
        [HttpGet]
        public ActionResult FileUpload()
        {
            return View("no model found");
        }
        // GET: /Event/CreateEvent
        public ActionResult CreateEvent()
        {
            return View(new EventCreateViewModel());
        }

        // GET: /Event/id

        [AllowAnonymous]
        public ActionResult ViewEvent(int id)
        {
            return View(db.Event.Find(id));
        }
        public ActionResult SearchEvent()
        {
            return View();
        }

        public ActionResult EditEvent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event ev = db.Event.Find(id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(Event ev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ev);
        }
    }
}