﻿using CocQuery.Models.Coc;
using QueryStringGenerator;
using System.Text;

namespace CocQuery.Services.Coc
{
    [QueryString]
    public class QueryClans : Query
    {
        /// <summary>
        /// Search clans by name. If name is used as part of search query, it
        /// needs to be at least three characters long. Name search parameter
        /// is interpreted as wild card search, so it may appear anywhere in
        /// the clan name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Filter by clan war frequency.
        /// </summary>
        public WarFrequency? WarFrequency { get; set; }

        /// <summary>
        /// Filter by clan location identifier. For list of available locations,
        /// refer to <see cref="ILocations.GetLocationsAsync(Query)" /> operation.
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// Filter by minimum number of clan members.
        /// </summary>
        public int? MinMembers { get; set; }

        /// <summary>
        /// Filter by maximum number of clan members.
        /// </summary>
        public int? MaxMembers { get; set; }

        /// <summary>
        /// Filter by minimum amount of clan points.
        /// </summary>
        public int? MinClanPoints { get; set; }

        /// <summary>
        /// Filter by minimum clan level.
        /// </summary>
        public int? MinClanLevel { get; set; }

        /// <summary>
        /// Comma separated list of label IDs to use for filtering results.
        /// </summary>
        public string? LabelIds { get; set; }

        public int? Limit { get; set; }

        public string? After { get; set; }

        public string? Before { get; set; }

        public bool MoveToNextItems() => SetMarkers(after: _cursors?.After);

        public bool MoveToPreviousItems() => SetMarkers(before: _cursors?.Before);

        private Cursors? _cursors;

        internal void SetCursors(Cursors cursors) => _cursors = cursors;

        private bool SetMarkers(string? before = default, string? after = default)
        {
            Before = before;
            After = after;

            if (Before != null || After != null)
                return true;

            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            // Always an instance of Query that should be appended
            sb.Append(this.ToQueryString());

            if (sb.Length != 0)
                return $"?{sb.ToString(1, sb.Length - 1)}";

            return string.Empty;
        }
    }
}
