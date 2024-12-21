namespace TabooGameApi.DTOs.Levels;

public class LevelGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BannedWordCount { get; set; }
}
