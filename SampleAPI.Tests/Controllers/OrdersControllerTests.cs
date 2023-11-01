using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SampleAPI.Controllers;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Tests.Controllers
{
    [TestFixture]
    public class OrdersControllerTests
    {
        Mock<ICreateOrderRequest> _createOrderRequestMock;
        OrdersController _controller;

        [SetUp]
        public void Setup()
        {
            _createOrderRequestMock = new Mock<ICreateOrderRequest>();
            _controller = new OrdersController(_createOrderRequestMock.Object);
        }

        [Test]
        public async Task Create_Orders_Test()
        {
            _createOrderRequestMock.Setup(x => x.CreateOrderAsync(It.IsAny<Order>())).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)));
            var result = await _controller.CreateOrder(It.IsAny<Order>());
            var okResult = result as OkResult;
            Assert.AreEqual(okResult?.StatusCode, 200);
        }

        [Test]
        public async Task Get_Recent_Orders_Test()
        {
            ICollection<Order> orders = new List<Order>() { new Order() { Id = Guid.NewGuid(), Name = "Order1" } };
            _createOrderRequestMock.Setup(x => x.GetRecentOrdersAsync()).Returns(Task.FromResult(orders));
            var result = await _controller.GetOrders();
            var value = result.Result as OkObjectResult;
            Assert.IsNotNull(value.Value);
        }
    }
}
