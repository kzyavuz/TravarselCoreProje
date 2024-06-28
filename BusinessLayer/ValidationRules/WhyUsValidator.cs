using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WhyUsValidator : AbstractValidator<About2>
    {
        public WhyUsValidator()
        {
            RuleFor(x => x.Title1).NotEmpty().WithMessage("Başlık adını ve soy adını giriniz");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Alt Başlık açıklamasını giriniz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Rehber açıklamasını giriniz!");

            RuleFor(x => x.Title1).MaximumLength(40).WithMessage("Başlık en fazla 40 karekter olabilir.");
            RuleFor(x => x.Title1).MinimumLength(10).WithMessage("Başlık en az 10 karekter olmalıdır");

            RuleFor(x => x.Title2).MaximumLength(40).WithMessage("Alt başlık en fazla 40 karekter olabilir.");
            RuleFor(x => x.Title2).MinimumLength(10).WithMessage("Alt başlık en az 10 karekter olmalıdır");

            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Rehber açıklaması en fazla 100 karekter olabilir.");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Rehberin açıklaması en az 10 karekter olmalıdır");
        }
    }
}
