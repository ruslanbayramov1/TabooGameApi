using FluentValidation;
using TabooGameApi.DTOs.BannedWordsForWords;

namespace TabooGameApi.Validators.BannedWordsForWords;

public class BannedWordForWordCreateValidator : AbstractValidator<BannedWordForWordCreateDto>
{
    public BannedWordForWordCreateValidator()
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
