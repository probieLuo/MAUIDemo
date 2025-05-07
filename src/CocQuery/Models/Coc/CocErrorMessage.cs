namespace CocQuery.Models.Coc
{
    public class CocErrorMessage
    {
        public string Reason { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public override string ToString() => $"Reason '{Reason}', message '{Message}', type '{Type}'";
    }
}
