namespace TabooGameApi.Entities;

public class Language
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public ICollection<Word> Words { get; set; }
}
