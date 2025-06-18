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
    public class VideoProcessorTests
    {
        private VideoProcessor _processor;
        private StringBuilder _stringBuilder;
        private StringWriter _stringWriter;

        [SetUp]
        public void SetUp()
        {
            _processor = new VideoProcessor();
            _stringBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_stringBuilder);
            Console.SetOut(_stringWriter);
        }

        [Test]
        public void It_should_generate_packing_slip_with_first_aid_for_learning_to_ski_video()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Learning to Ski", Type = ProductType.Video, Price = 19.99m }
                }
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("Generating packing slip for video: Learning to Ski"));
                Assert.That(output, Does.Contain("Adding free 'First Aid' video to the packing slip"));
            });
        }

        [Test]
        public void It_should_generate_normal_packing_slip_for_other_videos()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Other Video", Type = ProductType.Video, Price = 19.99m }
                }
            };

            // Act
            _processor.Process(order);

            // Assert
            var output = _stringBuilder.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("Generating packing slip for video: Other Video"));
                Assert.That(output, Does.Not.Contain("Adding free 'First Aid' video"));
            });
        }

        [Test]
        public void It_should_not_generate_packing_slip_for_non_video_products()
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
            Assert.That(output, Does.Not.Contain("Generating packing slip for video"));
        }
    }
} 