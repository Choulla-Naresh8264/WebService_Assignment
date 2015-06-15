using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CA2.Models;

namespace CA2.Controllers
{
    public class BandsController : ApiController
    {
        // instntiate a DbContext object => for Entity Framework to commuicate with the database.
        private CA2Context db = new CA2Context();

        // GET: api/Bands
        public IEnumerable<Band> Get()
        {
            // create variable (array) ==> where each index corresponds to a tuple from the 'Bands' table (in the database).
            var bands = db.Bands;
            return bands;
        }

        // GET: api/Bands/5 ==> will return the band object that corresponds to inputted id value
        public Band GetBand(int id)
        {
            // using LINQ query (generates SQL!) to search to for 'band' tuple in database that matches 'id' int value
            Band band = db.Bands.Find(id);
           
            if (band == null)
            { 
                // to return a response 404 if the id does not match a band in the database
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            // send band object back to client once found in database
            return band;
        }

        // POST: api/Bands
        public HttpResponseMessage Post(Band band)
        {
            // using validation 
            if(ModelState.IsValid)
            {
                // add the band object to database
                db.Bands.Add(band);
                db.SaveChanges();

                // send back a 201 Created response message to client
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, band);
                // within response message => indicate where created resource is located 
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { Id = band.Id }));
                return response;
            }

            // if Model validation fails => return 404 response 
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /*
        // PUT: api/Bands/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bands/5
        public void Delete(int id)
        {
        }
        */
    }
}
