using api_counter.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Xml.Linq;

namespace api_counter.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll_ReturnsExpectedData()
        {
            // Arrange
            var expectedData = new List<Counter>
            {
                new Counter { Name = "Item 1", Value = 0 },
                new Counter { Name = "Item 2", Value = 0 },
                new Counter { Name = "Item 3", Value = 0 }
            };
            CounterController _counterController = new CounterController();
            _counterController.counters.AddRange(expectedData);

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will return all the counters
            var result = _counterController.PlaceholderFunction().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as List<Counter>;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            for (int i = 0; i < expectedData.Count; i++)
            {
                Assert.That(actualData[i].Name, Is.EqualTo(expectedData[i].Name));
                Assert.That(actualData[i].Value, Is.EqualTo(expectedData[i].Value));
            }
        }

        [Test]
        public void CreateCounter_ReturnsExpectedData()
        {
            // Arrange
            CounterController _counterController = new CounterController();
            _counterController.counters.AddRange(new Counter { Name = "Counter", Value = 0 });

            var expectedData = new Counter {Name = "Counter 1", Value = 0 };

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will create a new named counter
            var result = _counterController.PlaceholderFunction().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));
        }

        [Test]
        public void IncrementCustomCounter()
        {
            // Arrange
            CounterController _counterController = new CounterController(_repo);
            _counterController.counters.AddRange(new List<Counter>
            {
                new Counter { Name = "Counter", Value = 0 },
                new Counter { Name = "Counter 1", Value = 0 }
            });

            var expectedData = new Counter { Name = "Counter", Value = 1 };

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will increment a counter by name
            var result = _counterController.PlaceholderFunction().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));
        }

        [Test]
        public void DecrementCustomCounter()
        {
            // Arrange
            CounterController _counterController = new CounterController();
            _counterController.counters.AddRange(new List<Counter>
            {
                new Counter { Name = "Counter", Value = 0 },
                new Counter { Name = "Counter 1", Value = 0 }
            });

            var expectedData = new Counter { Name = "Counter", Value = -1 };

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will decrement a counter by name
            var result = _counterController.PlaceholderFunction().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));
        }
    }
}
