using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUSerRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUSerRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı alanı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre alanı boş geçilemez!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Sifre tekrar alanı boş geçilemez!");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullaıcı adı en az 5 karekter içermli!");
            RuleFor(x => x.UserName).MaximumLength(25).WithMessage("Kullaıcı adı en fazla 25 karekter içermli!");
            RuleFor(x => x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Girilen sifreler aynı değil!");
        }
    }
}
