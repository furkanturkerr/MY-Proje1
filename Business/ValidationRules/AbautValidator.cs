using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class AbautValidator : AbstractValidator<Abaut>
{
    public AbautValidator()
    {
        RuleFor(x => x.AbautDetails1).NotEmpty().WithMessage("Zorunlu alan");
        RuleFor(x => x.AbautDetails2).NotEmpty().WithMessage("Zorunlu alan");
        RuleFor(x => x.AbautImage).NotEmpty().WithMessage("Zorunlu alan");
        RuleFor(x => x.AbautImage2).NotEmpty().WithMessage("Zorunlu alan");
    }
}