using System.Collections.Specialized;
using System.Collections;
using System.Linq;
using System.Text;
using System;

namespace TrelloApp.Models
{
    class Board : Element
    {
        private readonly IOrderedDictionary lists = new OrderedDictionary();
        private readonly IOrderedDictionary cards = new OrderedDictionary();

        public ICollection GetAllLists()
        {
            return lists.Values;
        }

        public bool RemoveCard(string cid, string lid)
        {
           if(cid == null || lid == null)
               return false;
           cards.Remove(cid);
           return GetListById(lid).RemoveCard(cid);
        }

        public void RemoveList(string lid)
        {

            lists.Remove(lid);
        }

        public bool AddList(string lid, string desc)
        {
            if (lists.Contains(lid))
                return false;
            else
                lists.Add(lid,new List(lid, desc));
            return true;
        }

        public bool AddCard(string cid, string desc, string date, string lid, string bid)
        {
            if (cards.Contains(cid))
                return false;
            Card c = new Card(cid, desc);
            c.creationDate = DateTime.Today;
            c.dueDate = DateTime.Parse(date + " 00:00:00");
            c.boardContainer = bid;
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
            return lists[lid] as List;
        }

        public Card GetCardById(string cid)
        {
            return cards[cid] as Card;
        }

        public ICollection GetAllCards()
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
