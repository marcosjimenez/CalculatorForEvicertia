using System;
using NUnit.Framework;
using CalculatorService.Server.Services.Interfaces;
using CalculatorService.Server.Services;

namespace CalculatorService.Tests
{
    public class Tests
    {

        private IPersistenceService _persistenceService;
        private IMathService _mathService;

        [SetUp]
        public void Setup()
        {
            _persistenceService = new PersistenceService();
            _mathService = new MathService(_persistenceService);
        }

        [Test]
        public void AddOperationWithoutTrackingId()
        {
            int[] numbers = { 2, 2 };
            var result = _mathService.Add(numbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, 4);
        }

        [Test]
        public void DivOperationWithoutTrackingId()
        {
            var dividend = 11;
            var divisor = 2;
            var expectedResult = 5;
            var expectedRemainder = 1;

            var result = _mathService.Div(dividend, divisor);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Quotient, expectedResult);
            Assert.AreEqual(result.Remainder, expectedRemainder);
        }

        [Test]
        public void MultOperationWithoutTrackingId()
        {
            int[] numbers = { 2, 2, 3 };
            var result = _mathService.Mult(numbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, 12);
        }

        [Test]
        public void SqrtOperationWithoutTrackingId()
        {
            var number = 16;
            var expectedResult = 4;
            var result = _mathService.Sqrt(number);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, expectedResult);
        }

        [Test]
        public void SubOperationWithoutTrackingId()
        {
            var minuend = 16;
            var sustraend = 4;
            var expectedResult = 12;
            var result = _mathService.Sub(minuend, sustraend);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, expectedResult);
        }

        /// <summary>
        /// TODO: Check every operation persistence
        /// </summary>
        [Test]
        public void PersistenceTest()
        {
            var trackingId = Guid.NewGuid().ToString();

            _mathService.Add(new int[] { 2, 2 }, trackingId);
            _mathService.Div(10, 2, trackingId);
            _mathService.Mult(new int[] { 3, 4 }, trackingId);
            _mathService.Sqrt(16, trackingId);
            _mathService.Sub(10, 2, trackingId);

            var items = _persistenceService.Query(trackingId);

            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count == 5);
        }
    }
}