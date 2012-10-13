using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloApp.Models
{
    class Board : Element
    {
        private readonly IDictionary<string, List> lists = new Dictionary<string, List>();
        private readonly IDictionary<string, Card> cards = new Dictionary<string, Card>();

        public IEnumerable<List> GetAllLists()
        {
            return lists.Values;
        }

        public List GetListById(string lid)
        {
            List l = null;
            lists.TryGetValue(lid, out l);
            return l;
        }

        public IEnumerable<Card> GetAllCards()
        {
            return cards.Values;
        }

        public Board(string id)
        {
            this.Id = id;
        }
    }
}
