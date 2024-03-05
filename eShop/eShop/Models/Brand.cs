﻿namespace eShop.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string AvatarUrl { get; set; }
    }
}
