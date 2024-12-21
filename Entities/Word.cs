namespace TabooGameApi.Entities;

public class Word : IBaseEntity
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public string LanguageCode { get; set; } = null!;
    public Language Language { get; set; }
    public ICollection<BannedWord> BannedWords { get; set; }
}
