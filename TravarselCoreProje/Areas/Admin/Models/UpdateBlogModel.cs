using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class UpdateBlogModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DetailDescription { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile NewImageFile { get; set; }
    }
}
