using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class logboeksController : ApiController
    {
        private webtechEntities db = new webtechEntities();

        // GET: api/logboeks
        public IQueryable<logboek> Getlogboek()
        {
            return db.logboek;
        }

        // GET: api/logboeks/5
        [ResponseType(typeof(logboek))]
        public IHttpActionResult Getlogboek(int id)
        {
            logboek logboek = db.logboek.Find(id);
            if (logboek == null)
            {
                return NotFound();
            }

            return Ok(logboek);
        }

        // PUT: api/logboeks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlogboek(int id, logboek logboek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logboek.EventID)
            {
                return BadRequest();
            }

            db.Entry(logboek).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!logboekExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/logboeks
        [ResponseType(typeof(logboek))]
        public IHttpActionResult Postlogboek(logboek logboek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.logboek.Add(logboek);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (logboekExists(logboek.EventID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = logboek.EventID }, logboek);
        }

        // DELETE: api/logboeks/5
        [ResponseType(typeof(logboek))]
        public IHttpActionResult Deletelogboek(int id)
        {
            logboek logboek = db.logboek.Find(id);
            if (logboek == null)
            {
                return NotFound();
            }

            db.logboek.Remove(logboek);
            db.SaveChanges();

            return Ok(logboek);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool logboekExists(int id)
        {
            return db.logboek.Count(e => e.EventID == id) > 0;
        }
    }
}