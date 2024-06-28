using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Member.Models
{
    public class UserEditModel
    {
        [MinLength(3, ErrorMessage = "Adınız en az 3 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Adınız en fazla 30 karakter olmalıdır.")]
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string name { get; set; }

        public string id { get; set; }


        [MaxLength(30, ErrorMessage = "Soyadınız en fazla 30 karakter olmalıdır.")]
        [MinLength(3, ErrorMessage = "Soyadınız en az 3 karakter olmalıdır.")]
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string surname { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
        ErrorMessage = "Şifre en az bir küçük harf, bir büyük harf, bir rakam, bir özel karakter içermeli ve sifre uzunluğu en az 6 karekter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Sifreniz en fazla 30 karakter olmalıdır.")]
        public string password { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9ğĞüÜşŞİıIöÖçÇ_]*$", ErrorMessage = "Kullanıcı adınızda yalnızca harfler, rakamlar, alt çizgi (_) kullanılabilir.")]
        [MaxLength(30, ErrorMessage = "Kullanıcı adınız en fazla 30 karakter olmalıdır.")]
        [MinLength(4, ErrorMessage = "Kullanıcı adınız en az 4 karakter olmalıdır.")]
        public string userName { get; set; }



        [Compare("password", ErrorMessage = "Girilen şifreler uyuşmuyor.")]
        public string confirmpassword { get; set; }


        [MaxLength(11, ErrorMessage = "Telefon numaranız en fazla 11 karakter olmalıdır.")]
        [MinLength(11, ErrorMessage = "Telefon numaranız en az 11 karakter olmalıdır.")]
        public string phonenumber { get; set; }



        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        public string mail { get; set; }


        [MaxLength(200, ErrorMessage = "Telefon numaranız en fazla 200 karakter olmalıdır.")]
        [MinLength(10, ErrorMessage = "Hakkımda alanı en az 10 karakter olmalıdır.")]
        public string gender { get; set; }

        public IFormFile imageurl { get; set; }
    }

}
