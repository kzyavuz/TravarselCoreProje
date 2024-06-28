using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Models
{
    public class UserRegisterViewModel
    {
        [MinLength(3, ErrorMessage = "Adınız en az 3 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Adınız en fazla 30 karakter olmalıdır.")]
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Soyadınız en fazla 30 karakter olmalıdır.")]
        [MinLength(3, ErrorMessage = "Soyadınız en az 3 karakter olmalıdır.")]
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string Surname { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9ğĞüÜşŞİıIöÖçÇ_]*$", ErrorMessage = "Kullanıcı adınızda yalnızca harfler, rakamlar, alt çizgi (_) kullanılabilir.")]
        [MaxLength(30, ErrorMessage = "Kullanıcı adınız en fazla 30 karakter olmalıdır.")]
        [MinLength(4, ErrorMessage = "Kullanıcı adınız en az 4 karakter olmalıdır.")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresini giriniz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen sifrenizi giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen tekrar sifrenizi giriniz.")]
        [Compare("Password", ErrorMessage ="Girilen sifreler aynı değil!")]
        public string ConfirmPassword { get; set; }
    }
}
