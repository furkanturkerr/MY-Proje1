using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class WriterValidator : AbstractValidator<Writer>
{
    public WriterValidator()
    {
        RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
        RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez.");
        RuleFor(x => x.WriterAbaut).NotEmpty().WithMessage("Hakkımda kısmı boş geçilemez.");
        RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Boş geçilemez.");
        RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Boş geçilemez.");
        RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Boş geçilemez.");
        RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Boş geçilemez.");
    }
}