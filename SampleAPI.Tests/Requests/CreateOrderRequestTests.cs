using Moq;
using NUnit.Framework;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Tests.Requests
{
    [TestFixture]
    public class CreateOrderRequestTests
    {
        Mock<IOrderRepository> _orderRepositoryMock;
        CreateOrderRequest _request;

        [SetUp]
        public void Setup()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _request = new CreateOrderRequest(_orderRepositoryMock.Object);
        }

        [Test]
        public async Task Create_Orders_Test()
        {
            _orderRepositoryMock.Setup(x => x.AddNewOrderAsync(It.IsAny<Order>())).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)));
            await _request.CreateOrderAsync(new Order() {  Id = Guid.NewGuid(), EntryDate = DateTime.UtcNow});
            _orderRepositoryMock.Verify(x => x.AddNewOrderAsync(It.IsAny<Order>()), Times.Once());
        }

        [Test]
        public async Task Get_Recent_Orders_Test()
        {
            ICollection<Order> orders = new List<Order>() { new Order() { Id = Guid.NewGuid(), Name = "Order1" } };
            _orderRepositoryMock.Setup(x => x.GetRecentOrdersAsync()).Returns(Task.FromResult(orders));
            var result = await _request.GetRecentOrdersAsync();
            Assert.IsNotNull(result);
        }
    }
}

