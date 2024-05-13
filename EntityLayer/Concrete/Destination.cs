using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }
        public string DestinationName { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public string BackGroundImage { get; set; }
        public string DetailsTitle1 { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Details3 { get; set; }
        public string Details4 { get; set; }
        public DateTime Date { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public bool Status { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rezarvation> Rezarvations { get; set; }
        public Catagory Catagory { get; set; }
    }
}
