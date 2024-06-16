using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Annonuncement
    {
        public int AnnonuncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ContentDate { get; set; }
    }
}
