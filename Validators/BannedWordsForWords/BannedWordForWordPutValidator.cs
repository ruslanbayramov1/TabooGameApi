using FluentValidation;
using TabooGameApi.DTOs.BannedWordsForWords;

namespace TabooGameApi.Validators.BannedWordsForWords;

public class BannedWordForWordPutValidator : AbstractValidator<BannedWordForWordPutDto>
{
    public BannedWordForWordPutValidator()
    {
        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Banned word must be more than 2 characters")
            .MaximumLength(32)
            .WithMessage("Banned word be less than 32 characters");
    }
}
