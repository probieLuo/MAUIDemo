﻿namespace CocQuery.Models.Coc;

public class ClanWarAttack
{
    public string AttackerTag { get; set; } = default!;

    public string DefenderTag { get; set; } = default!;

    public int Stars { get; set; }

    public int DestructionPercentage { get; set; }

    public int Order { get; set; }

    public int Duration { get; set; }
}