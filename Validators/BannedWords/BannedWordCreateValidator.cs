using FluentValidation;
using TabooGameApi.DTOs.BannedWords;

namespace TabooGameApi.Validators.BannedWords;

public class BannedWordCreateValidator : AbstractValidator<BannedWordCreateDto>
{
    public BannedWordCreateValidator()
    {
        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Text must be more than 2 characters")
            .MaximumLength(32)
            .WithMessage("Text must be less than 32 characters");
    }
}
