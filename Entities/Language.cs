namespace TabooGameApi.Entities;

public class Language : IBaseEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public ICollection<Word> Words { get; set; }
    public ICollection<Game> Games { get; set; }
}
