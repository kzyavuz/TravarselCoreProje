using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.DAL
{
    public enum ECity
    {
        a = 1,
        b = 2,
        c = 3,
        d = 4
    }
    public class Visit
    {
        public int VisitID { get; set; }
        public ECity City { get; set; }
        public int VisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
