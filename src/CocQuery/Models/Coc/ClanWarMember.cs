﻿namespace CocQuery.Models.Coc;

public class ClanWarMember : Identity
{
    public int TownhallLevel { get; set; }

    public int MapPosition { get; set; }

    public ClanWarAttackList? Attacks { get; set; }

    public int OpponentAttacks { get; set; }

    public ClanWarAttack? BestOpponentAttack { get; set; }
}
