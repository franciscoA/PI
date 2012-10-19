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

        public bool RemoveCard(string cid)
        {
            return cards.Remove(cid);
        }

        public bool AddList(string lid, string desc)
        {
            if (lists.ContainsKey(lid))
                return false;
            else
                lists.Add(lid,new List(lid, desc));
            return true;
        }

        public bool AddCard(string cid, string desc, string date, string lid)
        {
            if (cards.ContainsKey(cid))
                return false;
            Card c = new Card(cid, desc);
            c.creationDate = DateTime.Today;
            c.dueDate = DateTime.Parse(date + " 00:00:00");
            c.listContainer = lid;
            cards.Add(c.Id, c);
            return AddCardToList(c, lid);
        }

        private bool AddCardToList(Card c, string lid)
        {
            List temp;
            return ((temp = GetListById(lid)) != null) ? temp.AddCard(c) : false;
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
