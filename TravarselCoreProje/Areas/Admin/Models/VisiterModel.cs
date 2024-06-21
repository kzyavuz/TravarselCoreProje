using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class VisiterModel
    {
        public int VisiterID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Counter { get; set; }
        public string Mail { get; set; }
    }
}
