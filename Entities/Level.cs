namespace TabooGameApi.Entities;

public class Level : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BannedWordCount { get; set; }
    public ICollection<Word> Words { get; set; }
    public ICollection<Game> Games { get; set; }
}
