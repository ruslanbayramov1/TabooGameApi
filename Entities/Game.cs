namespace TabooGameApi.Entities;

public class Game : IBaseEntity
{
    public Guid Id { get; set; }
    public int SkipCount { get; set; }
    public int FailCount { get; set; } 
    public int TimeSecond { get; set; }
    public int Score { get; set; }
    public int SuccessAnswer { get; set; }
    public int WrongAnswer { get; set; }
    public int LevelId { get; set; }
    public Level Level { get; set; }
    public string LanguageCode { get; set; }
    public Language Language { get; set; }
}
