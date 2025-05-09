using CocQuery.Models.Coc;
using QueryStringGenerator;
using System.Text;

namespace CocQuery.Services.Coc
{
    [QueryString]
    public class Query
    {
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
