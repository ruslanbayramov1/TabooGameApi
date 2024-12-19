using TabooGameApi.DTOs.BannedWords;
using TabooGameApi.DTOs.BannedWordsForWords;

namespace TabooGameApi.DTOs.Words;

public class WordGetDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }
    public ICollection<BannedWordForWordGetDto> BannedWords { get; set;}
}
