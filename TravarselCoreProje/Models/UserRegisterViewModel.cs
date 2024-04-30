using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soy adınızı giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınzız giriniz.")]
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
