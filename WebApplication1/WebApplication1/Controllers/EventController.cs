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
        
        //[HttpPost]
        //public ActionResult Participate(EventCreateViewModel model)
        //{

        //    Event ev = db.Event.Find(model.EventID);
        //    ev.EventParticipants += 1;
        //    db.Event.Add(ev);
        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Event");
        //}

        [HttpPost]
        public ActionResult FileUpload(EventCreateViewModel model)
        {
            Event ev = new Event();
            model.EventBeginDate = model.EventBeginDate.Add(model.EventBeginTime.Value.TimeOfDay);
            model.EventEndDate = model.EventEndDate.Add(model.EventEndTime.Value.TimeOfDay);
            ev.EventName = model.EventName;
            ev.EventParticipants = 1;
            ev.EventDescription = model.EventDescription;
            ev.EventBeginDate = model.EventBeginDate;
            ev.EventEndDate = model.EventEndDate;
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
                EventID = db.Event.Where(e => e.EventName == ev.EventName && e.EventDescription == ev.EventDescription && e.EventPicture == ev.EventPicture).Select(t => t.EventId).First(),
                Organize = true,
                Interested=false,
                Going=true
            };
            //split input tags
            string[] tags = model.TagName.Split(new string[] { ", " }, StringSplitOptions.None);
            for (int i = 0; i < tags.Length; i++)
            {
                //make all tags
                Tag tag = new Tag();
                tag.TagName = tags[i];
                tag.EventId = lb.EventID;
                //add binding EventId - tagName to database
                db.Tag.Add(tag);
            }

            db.logboek.Add(lb);
            try {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                //Dit is gewoon test code indien het niet werkte
                return RedirectToAction("Index", "Home");
            }          
            return RedirectToAction("EventDetails", "Event", new { id = ev.EventId });
            // after successfully uploading redirect the user
        }

        [HttpGet]
        public ActionResult FileUpload()
        {
            return View("no model found");
        }
        // GET: /Event/CreateEvent
        [Authorize]
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
            string userid = User.Identity.GetUserId();
            model.log = new logboek();
            var log = db.logboek.Where(l => l.EventID == id && l.UserID == userid).ToList();
            if (log.Any())
            {
                model.log = log.First();
            }
            model.tags = db.Tag.Where(e => e.EventId == id).ToList();
            return PartialView("~/Views/Home/_Event.cshtml", model);
        }


        public ActionResult EventDetails(int id)
        {
            EventViewModel model = new EventViewModel();
            model.ev = db.Event.Find(id);
            string userid = User.Identity.GetUserId();
            model.log = new logboek();
            
            ViewBag.isowner = db.logboek.Where(l => l.UserID == userid && l.EventID == id && l.Organize).Select(l => l.UserID == userid).ToList().Count > 0;
            ViewBag.interestedCount = db.logboek.Where(l => l.EventID == id && l.Interested == true).Count();
            var log = db.logboek.Where(l => l.EventID == id && l.UserID == userid).ToList();
            if (log.Any())
            {
                model.log = log.First();
            }
            var host = db.logboek.Where(l => l.EventID == id && l.Organize == true).ToList().First();
            ViewBag.userName = User.Identity.Name;
            ViewBag.userId = host.UserID;
            ViewBag.owner = model.log.Organize;
            model.tags = db.Tag.Where(e => e.EventId == id).ToList();
            return View(model);
        }

        public ActionResult EditEvent(int? id)
        {
            var userID = User.Identity.GetUserId();
            var res = db.logboek.Where(l => l.EventID == id && l.UserID == userID && l.Organize == true);
            if (res.Any())
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
            }else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            
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