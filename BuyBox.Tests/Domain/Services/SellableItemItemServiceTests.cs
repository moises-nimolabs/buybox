using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Moq;
using NUnit.Framework;

namespace BuyBox.Tests.Domain.Services
{
    [TestFixture]
    public class SellableItemItemServiceTests
    {
        private readonly Mock<ISellableItemService> _service = new Mock<ISellableItemService>();
        [SetUp]
        public void SetUp()
        {
            _service.Setup(x => x.GetCollection())
                .Returns(Task.FromResult(new SellableItemModelCollection(new List<SellableItemModel>())));
            
            _service.Setup(x => x.OrderItem(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new PurchaseModel()));
        }

        [Test]
        public void GetCollection()
        {
            Assert.IsNotNull(_service.Object.GetCollection());
        }
        [Test]
        public void OrderItem()
        {
            Assert.IsNotNull(_service.Object.OrderItem(1, "eacd5069-80fd-4a5a-97df-4a87c171b0ba"));
        }
    }
}