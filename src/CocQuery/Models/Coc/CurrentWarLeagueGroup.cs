namespace CocQuery.Models.Coc;

public class CurrentWarLeagueGroup
{
    public string state { get; set; }
    public string season { get; set; }
    public List<Clans> clans { get; set; }
    public List<Rounds> rounds { get; set; }
}