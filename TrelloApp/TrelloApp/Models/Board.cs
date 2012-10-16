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

        public void AddList(string lid, string desc)
        {
            lists.Add(lid,new List(lid, desc));
        }

        public void AddCard(Card c)
        {
            cards.Add(c.Id,c);
        }

        public void AddCardToList(Card c, string lid)
        {
            GetListById(lid).AddCard(c);
        }

        public List GetListById(string lid)
        {
            List l = null;
            lists.TryGetValue(lid, out l);
            return l;
        }

        public Card GetCardById(string cid)
        {
            Card c = null;
            cards.TryGetValue(cid, out c);
            return c;
        }

        public IEnumerable<Card> GetAllCards()
        {
            return cards.Values;
        }

        public Board(string id, string desc)
        {
            this.Id = id;
            this.Description = desc;
        }
    }
}
