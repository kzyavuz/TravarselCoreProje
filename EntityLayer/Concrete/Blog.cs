using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string isPublish { get; set; }
        public DateTime Created { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
