using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CA2.Models
{
    public class Concert
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Date { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        // Foreign Key from Band table (one concert has one band max.)
        public int BandId { get; set; }
        // Navigation property ( i found info here: https://msdn.microsoft.com/en-us/library/vstudio/bb738520(v=vs.100).aspx)
        public Band band { get; set; }
    }
}