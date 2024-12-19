namespace TabooGameApi.Entities;

public class BannedWord
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int WordId { get; set; }
    public Word Word { get; set; }
}
