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
using HotelDbWebService;

namespace HotelDbWebService.Controllers
{
    public class GuestListsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/GuestLists
        public IQueryable<GuestList> GetGuestList()
        {
            return db.GuestList;
        }

        // GET: api/GuestLists/5
        [ResponseType(typeof(GuestList))]
        public IHttpActionResult GetGuestList(string id)
        {
            GuestList guestList = db.GuestList.Find(id);
            if (guestList == null)
            {
                return NotFound();
            }

            return Ok(guestList);
        }

        // PUT: api/GuestLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuestList(string id, GuestList guestList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guestList.HotelName)
            {
                return BadRequest();
            }

            db.Entry(guestList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestListExists(id))
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

        // POST: api/GuestLists
        [ResponseType(typeof(GuestList))]
        public IHttpActionResult PostGuestList(GuestList guestList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GuestList.Add(guestList);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GuestListExists(guestList.HotelName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guestList.HotelName }, guestList);
        }

        // DELETE: api/GuestLists/5
        [ResponseType(typeof(GuestList))]
        public IHttpActionResult DeleteGuestList(string id)
        {
            GuestList guestList = db.GuestList.Find(id);
            if (guestList == null)
            {
                return NotFound();
            }

            db.GuestList.Remove(guestList);
            db.SaveChanges();

            return Ok(guestList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestListExists(string id)
        {
            return db.GuestList.Count(e => e.HotelName == id) > 0;
        }
    }
}