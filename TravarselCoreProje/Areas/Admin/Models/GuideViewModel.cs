using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class GuideViewModel
    {
        public int GuideID { get; set; }
        public string name { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string Description { get; set; }
        public string ExistingImagePath { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile newImage { get; set; }
        public bool Status { get; set; }
    }
}
