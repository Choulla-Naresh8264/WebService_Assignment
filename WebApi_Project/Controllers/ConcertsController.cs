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
using CA2.Models;

namespace CA2.Controllers
{
    public class ConcertsController : ApiController
    {
        // instantiate the DbContext class for EF to 'talk' with the database
        private CA2Context db = new CA2Context();

        // GET: api/Concerts
        public IQueryable<Concert> GetConcerts()
        {
            // eager loading => EF loads entities (rows from 'Bands' table) as part of initial SQL request.
            return db.Concerts.Include(b => b.band);
        }

        // GET: api/Concerts/5
        [ResponseType(typeof(Concert))]
        public IHttpActionResult GetConcert(int id)
        {
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return NotFound();
            }

            return Ok(concert);
        }


 /*       // PUT: api/Concerts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConcert(int id, Concert concert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != concert.Id)
            {
                return BadRequest();
            }

            db.Entry(concert).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcertExists(id))
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
*/
        // POST: api/Concerts
        [ResponseType(typeof(Concert))]
        public IHttpActionResult PostConcert(Concert concert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Concerts.Add(concert);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = concert.Id }, concert);
        }

        // DELETE: api/Concerts/5
        [ResponseType(typeof(Concert))]
        public IHttpActionResult DeleteConcert(int id)
        {
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return NotFound();
            }

            db.Concerts.Remove(concert);
            db.SaveChanges();

            return Ok(concert);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConcertExists(int id)
        {
            return db.Concerts.Count(e => e.Id == id) > 0;
        }
    }
}