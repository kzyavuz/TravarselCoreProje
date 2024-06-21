using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class ApiMovieModel
    {
        public int rank { get; set; }
        public string title{ get; set; }
        public string rating{ get; set; }
        public int year{ get; set; }
        public string trailer{ get; set; }
    }
}
