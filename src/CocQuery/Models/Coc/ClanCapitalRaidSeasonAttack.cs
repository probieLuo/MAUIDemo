namespace CocQuery.Models.Coc
{
    public class ClanCapitalRaidSeasonAttack
    {
        public ClanCapitalRaidSeasonAttacker Attacker { get; set; } = default!;

        public int DestructionPercent { get; set; }

        public int Stars { get; set; }
    }
}
