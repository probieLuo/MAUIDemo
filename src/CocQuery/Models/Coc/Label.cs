namespace CocQuery.Models.Coc
{
    public class Label
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public UrlContainer IconUrls { get; set; } = default!;
    }
}
