namespace CocQuery.Models.Coc;

public class Clans
{
    public string tag { get; set; }
    public string name { get; set; }
    public int clanLevel { get; set; }
    public BadgeUrls badgeUrls { get; set; }
    public List<Members> members { get; set; }
}