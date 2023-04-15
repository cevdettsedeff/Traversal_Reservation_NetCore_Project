using DTOLayer.DTOs.ContactUsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidation
{
    public class ContacUsValidator:AbstractValidator<ContactUsDTO>
    {
        public ContacUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");

            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen konu alanına en az 5 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen konu alanına en fazla 100 karakter girişi yapınız");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Lütfen mail alanına en az 5karakter girişi yapınız");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Lütfen mail alanına en fazla 100 karakter girişi yapınız");
        } 
    }
}
