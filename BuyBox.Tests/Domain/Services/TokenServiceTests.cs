using System.Collections.Generic;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Moq;
using NUnit.Framework;

namespace BuyBox.Tests.Domain.Services
{
    [TestFixture]
    public class TokenServiceTests
    {
        readonly Mock<ITokenService> _mock = new Mock<ITokenService>();
        [SetUp]
        public void SetUp()
        {
            _mock.Setup(x => x.GetCollection(It.IsAny<string>()))
                .ReturnsAsync(new TokenModelCollection(new List<TokenModel>()));
            _mock.Setup(x => x.InsertCoin(It.IsAny<TokenModel>(), It.IsAny<string>()))
                .ReturnsAsync(new TokenModel());
        }
    }
}