using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BuyBox.Domain.Models
{
    public class TokenModelCollection
    {
        public TokenModelCollection(IEnumerable<TokenModel> items)
        {
            Items = new List<TokenModel>();
            items.ToList().ForEach(Items.Add);
        }

        [JsonProperty] public IList<TokenModel> Items { get; set; }

        [JsonProperty] public int Total => Items.Sum(p => p.Value);
    }
}