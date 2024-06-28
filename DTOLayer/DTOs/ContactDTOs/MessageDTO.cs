using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactDTOs
{
    public class MessageDTO
    {
        public string ContactInfoName { get; set; }
        public string ContactInfoMail { get; set; }
        [MaxLength(50, ErrorMessage = "Mesaj başlığı en fazla 50 karakter olmalıdır.")]
        [MinLength(10, ErrorMessage = "Mesaj başlığı en az 10 karakter olmalıdır.")]
        [Required(ErrorMessage = "Mesaj başlığı zorunludur.")]
        public string ContactInfoSubject { get; set; }


        [MaxLength(200, ErrorMessage = "Mesaj en fazla 200 karakter olmalıdır.")]
        [MinLength(20, ErrorMessage = "Mesaj en az 20 karakter olmalıdır.")]
        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
