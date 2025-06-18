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
    public class PhysicalProductProcessorTests
    {
        private PhysicalProductProcessor _processor;
        private StringBuilder _stringBuilder;
        private StringWriter _stringWriter;

        [SetUp]
        public void SetUp()
        {
            _processor = new PhysicalProductProcessor();
            _stringBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_stringBuilder);
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void It_should_generate_packing_slip_and_commission_for_physical_product()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Type = ProductType.Physical, Price = 999.99m }
                }
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("Generating packing slip for physical product: Laptop"));
                Assert.That(output, Does.Contain("Generating commission payment for physical product: Laptop"));
            });
        }

        [Test]
        public void It_should_not_generate_packing_slip_or_commission_for_non_physical_product()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Premium Membership", Type = ProductType.Membership, Price = 99.99m }
                }
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Not.Contain("Generating packing slip for physical product"));
                Assert.That(output, Does.Not.Contain("Generating commission payment for physical product"));
            });
        }
    }
} 