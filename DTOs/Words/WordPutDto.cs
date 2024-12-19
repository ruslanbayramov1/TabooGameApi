using TabooGameApi.DTOs.BannedWords;

namespace TabooGameApi.DTOs.Words;

public class WordPutDto
{
    public string Text { get; set; }
    public string Language { get; set; }
    public List<BannedWordPutDto> BannedWords { get; set; }
}
