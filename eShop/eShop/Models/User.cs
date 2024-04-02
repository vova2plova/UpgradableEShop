﻿namespace eShop.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string Email { get; set; }
        public List<Order>? Orders { get; set; }
        public Cart? Cart { get; set; }
    }
}
