using System.Linq;
using BuyBox.Data.Impl;
using NUnit.Framework;

namespace BuyBox.Data.Tests
{
    [TestFixture]
    public class SellableItemTests
    {
        private BuyBoxDbContext _dbContext;
        
        [SetUp]
        public void Setup()
        {
            _dbContext = new BuyBoxDbContext(ConfigurationLoader.ConnectionString);
        }

        [Test]
        public void SellableItemsAreAvailable()
        {
            var list = _dbContext.SellableItems.ToList();
            Assert.IsTrue(list.Count > 0);
        }
    }
}