﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Catagory
    {
        [Key]
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }
        public string CatagoryImage { get; set; }
        public bool Status { get; set; }

        public List<Destination> Destinations { get; set; }
    }
}
