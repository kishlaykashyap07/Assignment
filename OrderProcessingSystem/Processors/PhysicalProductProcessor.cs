using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Processors
{
    public class PhysicalProductProcessor : IOrderProcessor
    {
        public void Process(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.Type == ProductType.Physical)
                {
                    // Generate packing slip for shipping
                    GeneratePackingSlip(product);
                    // Generate commission payment
                    GenerateCommissionPayment(product);
                }
            }
        }

        private void GeneratePackingSlip(Product product)
        {
            // Implementation for generating packing slip
            Console.WriteLine($"Generating packing slip for physical product: {product.Name}");
        }

        private void GenerateCommissionPayment(Product product)
        {
            // Implementation for generating commission payment
            Console.WriteLine($"Generating commission payment for physical product: {product.Name}");
        }
    }
} 