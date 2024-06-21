using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class DestinationViewModel
    {
        public int DestinationID { get; set; }
        public string DestinationName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }

        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile NewImageFile { get; set; }

        public string Description { get; set; }
        public int Capacity { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public IFormFile Image1 { get; set; }
        public string Image1Url { get; set; }
        public IFormFile NewImage1File { get; set; }

        public IFormFile Image2 { get; set; }
        public string Image2Url { get; set; }
        public IFormFile NewImage2File { get; set; }

        public bool Status { get; set; }
    }
}
