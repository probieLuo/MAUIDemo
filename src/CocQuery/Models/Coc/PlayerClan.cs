namespace CocQuery.Models.Coc
{
    public class PlayerClan : Identity
    {
        public int ClanLevel { get; set; }

        public UrlContainer BadgeUrls { get; set; } = default!;
    }
}
