using FluentValidation;
using TabooGameApi.DTOs.Levels;
using TabooGameApi.Enums;

namespace TabooGameApi.Validators.Levels;

public class LevelCreateDtoValidator : AbstractValidator<LevelCreateDto>
{
    private int min => (int)GameLevels.Easy;
    private int mid => (int)GameLevels.Medium;
    private int max => (int)GameLevels.Hard;

    public LevelCreateDtoValidator()
    {
        RuleFor(x => x.BannedWordCount)
            .Must(x => x == min || x == mid || x == max)
            .WithMessage($"BannedWordCount must be either {min}, {mid}, or {max}.");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Level name must have at least 2 characters")
            .MaximumLength(16)
            .WithMessage("Level name must be less than 16 characters");
    }
}
