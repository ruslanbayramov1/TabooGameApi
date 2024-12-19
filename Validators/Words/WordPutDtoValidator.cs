using FluentValidation;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Enums;
using TabooGameApi.Validators.BannedWords;

namespace TabooGameApi.Validators.Words;

public class WordPutDtoValidator : AbstractValidator<WordPutDto>
{
    private int min => (int)GameLevels.Easy;
    private int mid => (int)GameLevels.Medium;
    private int max => (int)GameLevels.Hard;

    public WordPutDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Text must be more than 2 characters")
            .MaximumLength(32)
            .WithMessage("Text must be less than 32 characters");

        RuleFor(x => x.Language)
            .NotNull()
            .NotEmpty()
            .WithMessage("Language must have a character")
            .MaximumLength(2)
            .WithMessage("Language must be less than 2 characters");

        RuleFor(x => x.BannedWords)
            .NotNull()
            .WithMessage("Banned words list cannot be null.")
            .Must(bannedWords => bannedWords.Any())
            .Must(bannedWords => bannedWords.Count() >= min && bannedWords.Count() <= max)
            .WithMessage($"Banned words count can be {min}, {mid} or {max} word.")
            .ForEach(bannedWord =>
                bannedWord.SetValidator(new BannedWordPutValidator())
            );
    }
}
