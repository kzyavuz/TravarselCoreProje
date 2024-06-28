using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Rezarvation
    {
        [Key]
        public int RezervasyonID { get; set; }

        [Required(ErrorMessage = "Kişi sayısı zorunludur.")]
        public int MemontCount { get; set; }

        public DateTime RezarvationDate { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Açıklama 5 ile 50 karakter arasında olmalıdır.")]
        public string Sescription { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "Etkinlik seçimi zorunludur.")]
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUSer { get; set; }
    }
}
