﻿namespace CocQuery.Models.Coc
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public bool IsCountry { get; set; }

        public string? CountryCode { get; set; }
    }
}
