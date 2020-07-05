using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Moq;
using NUnit.Framework;

namespace BuyBox.Tests.Domain.Services
{
    [TestFixture]
    public class SessionServiceTests
    {
        private readonly Mock<ISessionService> _service = new Mock<ISessionService>();
        [SetUp]
        public void SetUp()
        {
            _service.Setup(x => x.New())
                .Returns(Task.FromResult(new SessionModel()));
            _service.Setup(x => x.Finish(It.IsAny<string>()))
                .Returns(Task.FromResult(new SessionModel()));
        }

        [Test]
        public void New()
        {
            Assert.IsNotNull(_service.Object.New());
        }
        [Test]
        public void Finish()
        {
            Assert.IsNotNull(_service.Object.Finish("eacd5069-80fd-4a5a-97df-4a87c171b0ba"));
        }
    }
}