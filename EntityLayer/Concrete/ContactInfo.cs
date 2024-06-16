using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactInfo
    {
        [Key]
        public int ContactInfoID { get; set; }
        public string ContactInfoName { get; set; }
        public string ContactInfoMail { get; set; }
        public string ContactInfoSubject { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
