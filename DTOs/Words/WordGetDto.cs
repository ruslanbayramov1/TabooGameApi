using TabooGameApi.DTOs.BannedWords;

namespace TabooGameApi.DTOs.Words;

public class WordGetDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }
    public ICollection<BannedWordGetDto> BannedWords { get; set;}
}
