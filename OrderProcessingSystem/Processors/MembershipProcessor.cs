using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Processors
{
    public class MembershipProcessor : IOrderProcessor
    {
        public void Process(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.Type == ProductType.Membership)
                {
                    if (order.IsMembershipUpgrade)
                    {
                        ApplyMembershipUpgrade(product);
                    }
                    else
                    {
                        ActivateMembership(product);
                    }
                    SendEmailNotification(order.CustomerEmail, product, order.IsMembershipUpgrade);
                }
            }
        }

        private void ActivateMembership(Product product)
        {
            Console.WriteLine($"Activating membership: {product.Name}");
        }

        private void ApplyMembershipUpgrade(Product product)
        {
            Console.WriteLine($"Applying membership upgrade: {product.Name}");
        }

        private void SendEmailNotification(string email, Product product, bool isUpgrade)
        {
            string action = isUpgrade ? "upgraded" : "activated";
            Console.WriteLine($"Sending email to {email} about membership {action}: {product.Name}");
        }
    }
} 