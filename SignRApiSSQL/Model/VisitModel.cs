using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignRApiSSQL.Model
{
    public class VisitModel
    {
        public VisitModel()
        {
            Counts = new List<int>();
        }

        public string VisitDate { get; set; }
        public List<int> Counts { get; set; }
    }
}
