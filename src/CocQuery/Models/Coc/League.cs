﻿namespace CocQuery.Models.Coc
{
    public class League
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public UrlContainer IconUrls { get; set; } = default!;
    }
}
