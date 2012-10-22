using System.Collections.Specialized;
using System.Collections;
using System;

namespace TrelloApp.Models
{
    class ElementMemoryRepository : IElementRepository
    {
        private readonly IOrderedDictionary _repo = new OrderedDictionary();
        private readonly IOrderedDictionary _archive = new OrderedDictionary();

        public ICollection GetAll()
        {
            return _repo.Values;
        }

        public ICollection GetArchivedCards()
        {
            return _archive.Values;
        }

        public Board GetBoardById(string id)
        {
            return _repo[id] as Board;
        }

        public List GetListById(string bid, string lid)
        {
            Board board = _repo[bid] as Board;
            return board == null ? null : board.GetListById(lid);
        }

        public Card GetCardById(string bid, string cid)
        {
            Card c = _archive[bid + "_" + cid] as Card;
            if(c != null)
                return c;
            Board board = _repo[bid] as Board;
            return board == null ? null : board.GetCardById(cid);
        }

        public bool UpdateCard(string bid, string lid, string cid, string desc, string date)
        {
            Card c=null;
            if ((c = GetCardById(bid, cid)) != null)
            {
                UpdateCard(desc, DateTime.Parse(date + " 00:00:00"), c);
                if ((c = GetCardByList(bid, lid, cid)) != null)
                {
                    UpdateCard(desc, DateTime.Parse(date + " 00:00:00"), c);
                    return true;
                }
            }
            return false;
        }

        private void UpdateCard(string desc, DateTime date, Card c)
        {
            c.Description = desc;
            c.dueDate = date;
        }

        public Card GetCardByList(string bid, string lid, string cid)
        {
            Board b = GetBoardById(bid);
            List l = null;
            return b == null ? null : ((l = b.GetListById(lid)) == null ? null : l.GetCardById(cid));
        }

        public bool ContainsBoard(string bid)
        {
            return _repo.Contains(bid);
        }

        public bool ContainsList(string bid, string lid)
        {
            List l = GetListById(bid, lid);
            return l == null ? false : true;
        }

        public bool AddBoard(string id, string desc)
        {
            Board td = new Board(id, desc);
            if (ContainsBoard(id))
                return false;
            else
                _repo.Add(td.Id, td);
            return true;
        }

        public bool ArchiveCard(string bid, string cid)
        {
            Board board = _repo[bid] as Board;
            if (board != null)
            {
                Card c = board.GetCardById(cid);
                if (c != null)
                {
                    _archive.Add(bid + "_" + c.Id, c);
                    c.archived = true;
                    return board.RemoveCard(cid,c.listContainer);
                }
            }
            return false;
        }

        public Card GetArchivedCardById(string id)
        {
            return _archive[id] as Card;
        }

        public bool MoveCard(string bid, string lid, string cid, string destLid, int position)
        {
            List l = (_repo[bid] as Board).GetListById(lid);
            List dl = (_repo[bid] as Board).GetListById(destLid);
            if (l == null || dl == null)
                return false;
            Card c = (_repo[bid] as Board).GetCardById(cid);
            return lid == destLid ? l.MoveInternalCard(c, position) : (l.RemoveCard(cid) && dl.AddCardToPosition(c, position));
        }
            
    }
}
