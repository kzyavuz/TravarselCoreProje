using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber adını ve soy adını giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Rehber açıklamasını giriniz!");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Rehber instagram kullanıcı adını giriniz");
            RuleFor(x => x.TwitterUrl).NotEmpty().WithMessage("Rehber twitter kullanıcı adını giriniz");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Rehber ad soy adı en fazla 40 karekter olabilir.");
            RuleFor(x => x.Name).MinimumLength(7).WithMessage("Rehberin ad soyad alanı en az 7 karekter olmalıdır");
        }
    }
}
