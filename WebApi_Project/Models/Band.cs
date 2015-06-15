using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA2.Models
{
    public class Band
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}