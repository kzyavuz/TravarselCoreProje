using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen görsel seçniz!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Açıklama en az 50 karekter içermeli!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama en fazla 500 karekter içerir!");
        }
    }
}
