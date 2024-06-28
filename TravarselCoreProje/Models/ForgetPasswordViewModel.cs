using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Lütfen mail adresini giriniz.")]
        public string mail { get; set; }
    }
}
