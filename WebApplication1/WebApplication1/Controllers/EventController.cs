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
using Microsoft.AspNet.Identity;

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
            Event ev = new Event();
            ev.EventName = model.EventName;
            ev.EventDescription = model.EventDescription;
            ev.EventBeginDate = model.EventBeginDate;
            ev.EventBeginTime = model.EventBeginTime;
            ev.EventEndDate = model.EventEndDate;
            ev.EventEndTime = model.EventEndTime;
            ev.EventLocation = model.EventLocation;
            ev.EventPrice = model.EventPrice;

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

            logboek lb = new logboek
            {
                UserID = User.Identity.GetUserId(),
                EventID = ev.EventId,
                Organize = true,
                Interested=false,
                Going=true
            };

            db.logboek.Add(lb);
            try {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                //Dit is gewoon test code indien het niet werkte
                return RedirectToAction("Index", "Home");
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
            EventViewModel model = new EventViewModel();
            model.ev = db.Event.Find(id);
            return View(model);
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