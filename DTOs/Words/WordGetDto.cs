using TabooGameApi.DTOs.BannedWordsForWords;
using TabooGameApi.DTOs.Levels;

namespace TabooGameApi.DTOs.Words;

public class WordGetDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }
    public LevelGetDto Level { get; set; }
    public ICollection<BannedWordForWordGetDto> BannedWords { get; set;}
}
