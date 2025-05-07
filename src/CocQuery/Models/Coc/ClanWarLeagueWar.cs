namespace CocQuery.Models.Coc
{
    public class ClanWarLeagueWar
    {
        public string tag { get; set; }
        public string state { get; set; }
        public string season { get; set; }
        public List<Clans> clans { get; set; }
        public List<Rounds> rounds { get; set; }
    }
}
