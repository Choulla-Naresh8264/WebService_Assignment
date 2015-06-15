using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA2.Models;
using System.Data;


namespace SOAPwebservice
{
    public class NextConcertDateWebservice : INextConcertDate
    {
        // instantiate the DbContext class for EF to 'talk' with the database
        private CA2Context db = new CA2Context();

        // implementing the 'findDate' method defined in the INextConcertDate interface
        public int findDate(int bandId)
        {
            //find the concert that has bandID as its FK
            Concert concert = db.Concerts.SingleOrDefault(x => x.BandId == bandId);

            // return the date that the band are playing their next concert
            return concert.Date;
        }
    }
}
