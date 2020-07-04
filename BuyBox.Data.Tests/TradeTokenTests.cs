using System.Linq;
using NUnit.Framework;

namespace BuyBox.Data.Tests
{
    [TestFixture]
    public class TradeTokenTests
    {
        private BuyBoxDbContext _dbContext;
        
        [SetUp]
        public void Setup()
        {
            _dbContext = new BuyBoxDbContext(ConfigurationLoader.ConnectionString);
        }

        [Test]
        public void TradeTokensAvailable()
        {
            var list = _dbContext.TradeTokens.ToList();
            Assert.IsTrue(list.Count > 0);
        }
    }
}