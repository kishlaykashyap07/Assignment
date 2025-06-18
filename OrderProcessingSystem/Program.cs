using System;
using System.Collections.Generic;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessingService = new OrderProcessingService();

            // Example 1: Physical Product Order
            var physicalProductOrder = new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Type = ProductType.Physical, Price = 999.99m }
                },
                CustomerEmail = "customer@example.com"
            };

            Console.WriteLine("Processing Physical Product Order:");
            orderProcessingService.ProcessOrder(physicalProductOrder);
            Console.WriteLine();

            // Example 2: Book Order
            var bookOrder = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                Products = new List<Product>
                {
                    new Product { Id = 2, Name = "Clean Code", Type = ProductType.Book, Price = 29.99m }
                },
                CustomerEmail = "customer@example.com"
            };

            Console.WriteLine("Processing Book Order:");
            orderProcessingService.ProcessOrder(bookOrder);
            Console.WriteLine();

            // Example 3: Membership Order
            var membershipOrder = new Order
            {
                Id = 3,
                OrderDate = DateTime.Now,
                Products = new List<Product>
                {
                    new Product { Id = 3, Name = "Premium Membership", Type = ProductType.Membership, Price = 99.99m }
                },
                CustomerEmail = "customer@example.com",
                IsMembershipUpgrade = false
            };

            Console.WriteLine("Processing Membership Order:");
            orderProcessingService.ProcessOrder(membershipOrder);
            Console.WriteLine();

            // Example 4: Video Order
            var videoOrder = new Order
            {
                Id = 4,
                OrderDate = DateTime.Now,
                Products = new List<Product>
                {
                    new Product { Id = 4, Name = "Learning to Ski", Type = ProductType.Video, Price = 19.99m }
                },
                CustomerEmail = "customer@example.com"
            };

            Console.WriteLine("Processing Video Order:");
            orderProcessingService.ProcessOrder(videoOrder);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
} 