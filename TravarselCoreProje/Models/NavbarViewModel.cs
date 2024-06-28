using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Models
{
    public class NavbarViewModel
    {
        public IEnumerable<Catagory> Catagories { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}
