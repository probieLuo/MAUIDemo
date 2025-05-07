using System;

namespace CocQuery.Models.Coc
{
    public abstract class WarBase
    {
        public State State { get; set; }

        public int? TeamSize { get; set; }

        public string? PreparationStartTime { get; set; }

        public string? StartTime { get; set; }

        public string? EndTime { get; set; }
    }
}
