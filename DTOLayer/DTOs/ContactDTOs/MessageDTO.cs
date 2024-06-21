using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactDTOs
{
    public class MessageDTO
    {
        public string ContactInfoName { get; set; }
        public string ContactInfoMail { get; set; }
        public string ContactInfoSubject { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
