using System;
using System.Collections.Generic;

namespace OrderProcessingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerEmail { get; set; }
        public bool IsMembershipUpgrade { get; set; }
    }
} 