using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class CategoryValidatior : AbstractValidator<Category>
{
    public CategoryValidatior()
    {
        RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama zorunludur.");
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi zorunludur.");
        RuleFor(x => x.CategoryStatus).NotEmpty().WithMessage("Durum zorunludur.");
        RuleFor(x => x.CategoryDescription).MaximumLength(150).WithMessage("Max 150 karakter olabilir.");
    }
}