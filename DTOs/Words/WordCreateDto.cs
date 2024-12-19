using TabooGameApi.DTOs.BannedWords;

namespace TabooGameApi.DTOs.Words;

public class WordCreateDto
{
    public string Text { get; set; }
    public string Language { get; set; }
    public IEnumerable<BannedWordCreateDto> BannedWords { get; set; }
}
