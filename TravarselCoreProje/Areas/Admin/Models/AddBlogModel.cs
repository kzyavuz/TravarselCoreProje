using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class AddBlogModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string DetailDescription { get; set; }

        public IFormFile Image { get; set; }
    }
}
