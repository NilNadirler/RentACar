using Entities.Concentre;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TransactionValidator : AbstractValidator<TransactionDto>
    {
        public TransactionValidator()
        {
            RuleFor(t => t.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş olamaz");
            RuleFor(t => t.CarId).NotEmpty().WithMessage("Araç bilgisi bulunamadı");
            RuleFor(t => t.EndDate).GreaterThan(t=>t.StartDate).WithMessage("Bitiş tarihi başlangıç tarihinden önce olamaz");
        }
    }
}
