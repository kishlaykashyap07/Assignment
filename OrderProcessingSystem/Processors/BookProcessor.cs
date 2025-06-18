using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Processors
{
    public class BookProcessor : IOrderProcessor
    {
        public void Process(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.Type == ProductType.Book)
                {
                    // Generate packing slip for shipping
                    GeneratePackingSlip(product);
                    // Generate duplicate packing slip for royalty department
                    GenerateRoyaltyPackingSlip(product);
                    // Generate commission payment
                    GenerateCommissionPayment(product);
                }
            }
        }

        private void GeneratePackingSlip(Product product)
        {
            Console.WriteLine($"Generating packing slip for book: {product.Name}");
        }

        private void GenerateRoyaltyPackingSlip(Product product)
        {
            Console.WriteLine($"Generating duplicate packing slip for royalty department: {product.Name}");
        }

        private void GenerateCommissionPayment(Product product)
        {
            Console.WriteLine($"Generating commission payment for book: {product.Name}");
        }
    }
} 