using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Interfaces
{
    public interface IOrderProcessor
    {
        void Process(Order order);
    }
} 