using System.Data;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class HeadingValidator : AbstractValidator<Heading>
{
    public HeadingValidator()
    {
        RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Zorunlu alan");
        RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Zorunlu alan");
        RuleFor(x => x.HeadingStatus).NotEmpty().WithMessage("Zorunlu alan");
        RuleFor(x => x.WriterId).NotEmpty().WithMessage("Zorunlu alan");
    }
}