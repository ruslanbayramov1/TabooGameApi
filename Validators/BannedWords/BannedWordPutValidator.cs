using FluentValidation;
using TabooGameApi.DTOs.BannedWords;

namespace TabooGameApi.Validators.BannedWords;

public class BannedWordPutValidator : AbstractValidator<BannedWordPutDto>
{
    public BannedWordPutValidator()
    {
        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Banned word must be more than 2 characters")
            .MaximumLength(32)
            .WithMessage("Banned word be less than 32 characters");

        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id must contain a character");
    }
}
