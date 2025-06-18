using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Processors;

namespace OrderProcessingSystem.Tests
{
    [TestFixture]
    public class MembershipProcessorTests
    {
        private MembershipProcessor _processor;
        private StringBuilder _stringBuilder;
        private StringWriter _stringWriter;

        [SetUp]
        public void SetUp()
        {
            _processor = new MembershipProcessor();
            _stringBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_stringBuilder);
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void It_should_activate_membership_and_send_email_for_new_membership()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Premium Membership", Type = ProductType.Membership, Price = 99.99m }
                },
                CustomerEmail = "customer@example.com",
                IsMembershipUpgrade = false
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("Activating membership: Premium Membership"));
                Assert.That(output, Does.Contain("Sending email to customer@example.com about membership activated: Premium Membership"));
            });
        }

        [Test]
        public void It_should_apply_upgrade_and_send_email_for_membership_upgrade()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Premium Membership", Type = ProductType.Membership, Price = 99.99m }
                },
                CustomerEmail = "customer@example.com",
                IsMembershipUpgrade = true
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("Applying membership upgrade: Premium Membership"));
                Assert.That(output, Does.Contain("Sending email to customer@example.com about membership upgraded: Premium Membership"));
            });
        }

        [Test]
        public void It_should_not_process_non_membership_products()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Type = ProductType.Physical, Price = 999.99m }
                },
                CustomerEmail = "customer@example.com"
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Not.Contain("Activating membership"));
                Assert.That(output, Does.Not.Contain("Applying membership upgrade"));
                Assert.That(output, Does.Not.Contain("Sending email"));
            });
        }
    }
} 