using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Rezarvation
    {
        [Key]
        public int RezervasyonID { get; set; }
        public int AppUSerID { get; set; }
        public AppUser AppUSer { get; set; }
        public string MemontCount { get; set; }
        public DateTime RezarvationDate { get; set; }
        public string Sescription { get; set; }
        public string Status { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }


    }
}
