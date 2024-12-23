namespace TabooGameApi.Helpers;

public class GameOptions
{
    public int SkipCount { get; set; }
    public int FailCount { get; set; }
    public int SuccessAnswer { get; set; }
    public int MaxSkipCount { get; set; } = 3;
}
