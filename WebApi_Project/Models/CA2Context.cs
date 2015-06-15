using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2.Models
{

    // create a class derived from DbContext that will communicate with the database
    public class CA2Context : DbContext
    {
        // default constructor
        public CA2Context() : base("name=CA2Context"){}

        //first table in database 
        public DbSet<CA2.Models.Band> Bands { get; set; }
        public DbSet<CA2.Models.Concert> Concerts { get; set; }
    }
}
