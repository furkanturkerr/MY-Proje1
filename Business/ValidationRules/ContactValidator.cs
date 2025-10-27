using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini boş geçemezsiniz.");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını boş geçemezsiniz.");
        RuleFor(x => x.Message).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");
        RuleFor(x => x.Subjeck).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
    }
}