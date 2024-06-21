using DTOLayer.DTOs.AnnonuncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnonuncementUpdateValidator : AbstractValidator<AnnonuncementUpdateDTO>
    {
        public AnnonuncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karekter olmalı");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("İçerik en az 5 karekter olmalı");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Başlık en fazla 50 karekter olmalı");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("İçerik en fazla 500 karekter olmalı");
        }
    }
}
