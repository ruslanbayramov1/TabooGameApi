using FluentValidation;
using TabooGameApi.DTOs.BannedWords;

namespace TabooGameApi.Validators.BannedWords;

public class BannedWordCreateDtoValidator : AbstractValidator<BannedWordCreateDto>
{
    public BannedWordCreateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Text must be more than 2 characters")
            .MaximumLength(32)
            .WithMessage("Text must be less than 32 characters");

        RuleFor(x => x.WordId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id must contain a character");
    }
}
