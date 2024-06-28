using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Feature
    {
        [Key]
        public int FeatureID { get; set; }

        [MinLength(3, ErrorMessage = "Başlık en az 3 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Başlık en fazla 30 karakter olmalıdır.")]
        [Required(ErrorMessage = "Lütfen başlığı giriniz.")]
        public string Post1Name { get; set; }

        [MinLength(10, ErrorMessage = "İçerik en az 10 karakter olmalıdır.")]
        [MaxLength(400, ErrorMessage = "İçerik en fazla 400 karakter olmalıdır.")]
        [Required(ErrorMessage = "Lütfen İçeriği giriniz.")]
        public string Post1Description { get; set; }
    }
}
