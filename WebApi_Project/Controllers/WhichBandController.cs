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
    // The GET method in this controller will return the specific band playing at a given concert. 
    public class WhichBandController : ApiController
    {
        // instantiate the DbContext class for EF to 'talk' with the database
        private CA2Context db = new CA2Context();

        // GET: api/WhichConcert/2
        [ResponseType(typeof(Band))]
        // the client passes a parameter (concert id) to the api
        public IHttpActionResult GetConcertAndFindBand(int id)
        {
            // Use the Find() method on DbSet to find by primary key
            // more info here: https://msdn.microsoft.com/en-us/data/jj573936.aspx
            Concert concert = db.Concerts.Find(id);

            // handle notfound cases
            if (concert == null)
            {
                // send a HttpWebResponse back to client 
                return NotFound();
            }

            // Again: use the Find() method on DbSet to find the band whos PK matches the BandID FK in from concert table
            Band band = db.Bands.Find(concert.BandId);
            
            // return the found band back to the client 
            return Ok(band);
        }
    }
}
