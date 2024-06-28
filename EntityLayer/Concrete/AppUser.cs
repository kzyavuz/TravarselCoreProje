﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string NamSurname { get; set; }
        public string Gender { get; set; }

        public List<Rezarvation> Rezarvations { get; set; }

        public List<Comment> Comments { get; set; }

        public List<ContactInfo> ContactInfos { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}
