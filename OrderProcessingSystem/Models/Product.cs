using System;

namespace OrderProcessingSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
    }

    public enum ProductType
    {
        Physical,
        Book,
        Membership,
        Video
    }
} 