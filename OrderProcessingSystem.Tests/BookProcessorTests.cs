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
    public class BookProcessorTests
    {
        private BookProcessor _processor;
        private StringBuilder _stringBuilder;
        private StringWriter _stringWriter;

        [SetUp]
        public void SetUp()
        {
            _processor = new BookProcessor();
            _stringBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_stringBuilder);
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void It_should_generate_packing_slip_royalty_slip_and_commission_for_book()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Clean Code", Type = ProductType.Book, Price = 29.99m }
                }
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("Generating packing slip for book: Clean Code"));
                Assert.That(output, Does.Contain("Generating duplicate packing slip for royalty department: Clean Code"));
                Assert.That(output, Does.Contain("Generating commission payment for book: Clean Code"));
            });
        }

        [Test]
        public void It_should_not_generate_any_slips_or_commission_for_non_book()
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
                Assert.That(output, Does.Not.Contain("Generating packing slip for book"));
                Assert.That(output, Does.Not.Contain("Generating duplicate packing slip for royalty department"));
                Assert.That(output, Does.Not.Contain("Generating commission payment for book"));
            });
        }
    }
} 