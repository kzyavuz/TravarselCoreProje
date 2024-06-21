using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class CatagoryViewModel
    {
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }
        public string ExistingImagePath { get; set; }
        public IFormFile CatagoryImage { get; set; }
        public IFormFile newCatagoryImage { get; set; }
        public bool Status { get; set; }
    }
}
