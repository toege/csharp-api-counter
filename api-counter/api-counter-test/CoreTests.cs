using api_counter.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using api_counter.Repositories;
using Microsoft.Extensions.Options;
using api_counter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Xml.Linq;

namespace api_counter.Test
{
    [NonParallelizable]
    [TestFixture]
    public class CoreTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Order(1)]
        [NonParallelizable]
        [Test]
        public void GetCounter()
        {
            // Setup
            ICounterRepository _repo = new CounterRepository(new Counter { Name = "Counter", Value = 0 });
            CounterController _counterController = new CounterController();

            // Arrange
            var expectedData = new Counter { Name = "Counter", Value = 0 };

            // Act
            var result = _counterController.GetCounter().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);

            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));
            
        }

        [Order(2)]
        [NonParallelizable]
        [Test]
        public void IncrementCounter()
        {
            // Setup
            ICounterRepository _repo = new CounterRepository(new Counter{ Name = "Counter", Value = 0 });
            CounterController _counterController = new CounterController(_repo);

            // Arrange
            var expectedData = new Counter { Name = "Counter", Value = 1 };
            var expectedData1 = new Counter { Name = "Counter", Value = 2 };

            // Act
            var result = _counterController.IncrementCounter().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));

            // Assert
            result = _counterController.IncrementCounter().Result as OkObjectResult;
            Assert.IsNotNull(result);
            actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData1.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData1.Value));
        }

        [Order(4)]
        [NonParallelizable]
        [Test]
        public void DecrementCounter()
        {
            // Setup
            ICounterRepository _repo = new CounterRepository(new Counter { Name = "Counter", Value = 2 });
            CounterController _counterController = new CounterController(_repo);

            // Arrange
            var expectedData = new Counter { Name = "Counter", Value = 1 };
            var expectedData1 = new Counter { Name = "Counter", Value = 0 };

            // Act
            var result = _counterController.DecrementCounter().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));

            // Assert
            result = _counterController.DecrementCounter().Result as OkObjectResult;
            Assert.IsNotNull(result);
            actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData1.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData1.Value));
        }

        [Order(3)]
        [NonParallelizable]
        [Test]
        public void DoubleCounter()
        {
            // Setup
            ICounterRepository _repo = new CounterRepository(new Counter { Name = "Counter", Value = 1 });
            CounterController _counterController = new CounterController(_repo);

            // Arrange
            var expectedData = new Counter { Name = "Counter", Value = 2 };
            var expectedData1 = new Counter { Name = "Counter", Value = 4 };

            // Act
            var result = _counterController.DoubleCounter().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));

            // Assert
            result = _counterController.DoubleCounter().Result as OkObjectResult;
            Assert.IsNotNull(result);
            actualData = result.Value as Counter;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData1.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData1.Value));
        }
    }
}