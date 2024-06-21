using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<MessageDTO>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ContactInfoMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.ContactInfoSubject).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(x => x.MessageBody).MinimumLength(5).WithMessage("Mesaj alanına en az 5 karekter olmalı");
            RuleFor(x => x.ContactInfoMail).MinimumLength(5).WithMessage("Mail başlığı en az 5 karekter olmalı");
            RuleFor(x => x.ContactInfoSubject).MinimumLength(5).WithMessage("Mesaj alanına en az 5 karekter olmalı");
            RuleFor(x => x.ContactInfoMail).MaximumLength(40).WithMessage("Mail alanına en fazla 40 karekter olmalı");
            RuleFor(x => x.MessageBody).MaximumLength(200).WithMessage("Mesaj alanına en fazla 500 karekter olmalı");
            RuleFor(x => x.ContactInfoSubject).MaximumLength(80).WithMessage("Mesaj başlığı en fazla 80 karekter olmalı");
        }
    }
}
