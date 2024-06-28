using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class WhyUsViewModel
    {
        public int About2ID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public string ExistingImagePath { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile newImage { get; set; }
    }
}
