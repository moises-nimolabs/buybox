using System.Linq;
using NUnit.Framework;

namespace BuyBox.Data.Tests
{
    public class Tests
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
            var catalogEntries = _dbContext.SellableItems.ToList();
            Assert.IsTrue(catalogEntries.Count > 0);
        }
    }
}