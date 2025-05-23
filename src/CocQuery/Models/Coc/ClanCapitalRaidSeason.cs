﻿using System;

namespace CocQuery.Models.Coc
{
    public class ClanCapitalRaidSeason
    {
        public ClanCapitalRaidSeasonState State { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int CapitalTotalLoot { get; set; }

        public int RaidsCompleted { get; set; }

        public int TotalAttacks { get; set; }

        public int EnemyDistrictsDestroyed { get; set; }

        public int OffensiveReward { get; set; }

        public int DefensiveReward { get; set; }

        public ClanCapitalRaidSeasonMemberList? Members { get; set; }

        public ClanCapitalRaidSeasonAttackLogList AttackLog { get; set; } = default!;

        public ClanCapitalRaidSeasonDefenseLogList DefenseLog { get; set; } = default!;
    }
}
