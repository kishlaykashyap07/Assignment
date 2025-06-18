using System.Collections.Generic;
using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Services
{
    public class OrderProcessingService
    {
        private readonly List<IOrderProcessor> _processors;

        public OrderProcessingService()
        {
            _processors = new List<IOrderProcessor>
            {
                new PhysicalProductProcessor(),
                new BookProcessor(),
                new MembershipProcessor(),
                new VideoProcessor()
            };
        }

        public void ProcessOrder(Order order)
        {
            foreach (var processor in _processors)
            {
                processor.Process(order);
            }
        }
    }
} 