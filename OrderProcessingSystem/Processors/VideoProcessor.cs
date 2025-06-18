using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Processors
{
    public class VideoProcessor : IOrderProcessor
    {
        public void Process(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.Type == ProductType.Video)
                {
                    if (product.Name == "Learning to Ski")
                    {
                        GeneratePackingSlipWithFirstAid(product);
                    }
                    else
                    {
                        GeneratePackingSlip(product);
                    }
                }
            }
        }

        private void GeneratePackingSlip(Product product)
        {
            Console.WriteLine($"Generating packing slip for video: {product.Name}");
        }

        private void GeneratePackingSlipWithFirstAid(Product product)
        {
            Console.WriteLine($"Generating packing slip for video: {product.Name}");
            Console.WriteLine("Adding free 'First Aid' video to the packing slip");
        }
    }
} 