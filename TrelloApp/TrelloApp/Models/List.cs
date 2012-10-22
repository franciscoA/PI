using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Collections;

namespace TrelloApp.Models
{
    class List : Element
    {
        private readonly IOrderedDictionary cards = new OrderedDictionary();

        public ICollection GetAllCards()
        {
            return cards.Values;
        }

        public bool MoveInternalCard(Card c, int position)
        {
            return RemoveCard(c.Id) && AddCardToPosition(c, position);
        }

        public bool AddCardToPosition(Card c, int position)
        {
            if (cards.Count < position)
                return AddCard(c);
            cards.Insert(position, c.Id, c);
            return true;
        }

        public bool AddCard(Card c)
        {
            if (cards.Contains(c.Id))
                return false;
            else
                cards.Add(c.Id, c);
            return true;
        }

        public Card GetCardById(string cid)
        {
            return cards[cid] as Card;
        }

        public List(string id, string desc)
        {
            this.Id = id;
            this.Description = desc;
        }

        public bool RemoveCard(string cid)
        {
            if (cid == null)
                return false;
            cards.Remove(cid);
            return true;
        }
    }
}
