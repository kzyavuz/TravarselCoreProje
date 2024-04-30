using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Feature2
    {
        [Key]
        public int Feature2ID { get; set; }
        public string PostName { get; set; }
        public string PostDescription { get; set; }
        public string PostImage { get; set; }
        public bool PostStatus { get; set; }
    }
}
