using TabooGameApi.DTOs.BannedWords;
using TabooGameApi.DTOs.BannedWordsForWords;

namespace TabooGameApi.DTOs.Words;

public class WordCreateDto
{
    public string Text { get; set; }
    public string Language { get; set; }
    public IEnumerable<BannedWordForWordCreateDto> BannedWords { get; set; }
}
