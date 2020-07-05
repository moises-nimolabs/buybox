using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BuyBox.Domain.Models
{
    public class SellableItemModelCollection : Collection<SellableItemModel>
    {
        public SellableItemModelCollection(IEnumerable<SellableItemModel> items)
        {
            items.ToList().ForEach(Items.Add);
        }
    }
}