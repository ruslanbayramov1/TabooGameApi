using TabooGameApi.DTOs.BannedWordsForWords;

namespace TabooGameApi.DTOs.Words;

public class WordPutDto
{
    public string Text { get; set; }
    public string Language { get; set; }
    public List<BannedWordForWordPutDto> BannedWords { get; set; }
}
