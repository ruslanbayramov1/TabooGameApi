namespace TabooGameApi.DTOs.Games;

public class GameGetDto
{
    public string Id { get; set; }
    public int SkipCount { get; set; }
    public int FailCount { get; set; }
    public int TimeSecond { get; set; }
    public int Score { get; set; }
    public int SuccessAnswer { get; set; }
    public int WrongAnswer { get; set; }
    public string Status { get; set; }
    public int LevelId { get; set; }
    public string LanguageCode { get; set; }
}
