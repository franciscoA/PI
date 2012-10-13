using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloApp.Models
{
    class List : Element
    {
        private readonly IDictionary<string, Card> cards = new Dictionary<string, Card>();

        public IEnumerable<Card> GetAllCards()
        {
            return cards.Values;
        }

        public Card GetListById(string cid)
        {
            Card c = null;
            cards.TryGetValue(cid, out c);
            return c;
        }

        public List(string id)
        {
            this.Id = id;
        }
    }
}
