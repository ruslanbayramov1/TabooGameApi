using FluentValidation;
using TabooGameApi.DTOs.Languages;

namespace TabooGameApi.Validators.Languages;

public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
{
    public LanguageCreateDtoValidator()
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
                .WithMessage("Code must have a character")
            .MaximumLength(2)
                .WithMessage("Code must be less than 2 characters");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
                .WithMessage("Name must have a character")
            .MaximumLength(64)
                .WithMessage("Name must be less than 64 characters");

        RuleFor(x => x.IconUrl)
            .NotNull()
            .NotEmpty()
                .WithMessage("Icon url must have a character")
            .MaximumLength(128)
                .WithMessage("Icon url must be less than 128 characters")
            .Matches("^https?:\\/\\/[a-zA-Z0-9-\\.]+\\.[a-zA-Z]{2,6}([\\/\\w \\.-]*)*\\/?$")
                .WithMessage("Not a valid url");
    }
}
