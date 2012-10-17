using System.Collections.Generic;
using System;

namespace TrelloApp.Models
{
    class ElementMemoryRepository : IElementRepository
    {
        private readonly IDictionary<string, Board> _repo = new Dictionary<string, Board>();
        private readonly IDictionary<string, Card> _archive = new Dictionary<string, Card>();

        public IEnumerable<Board> GetAll()
        {
            return _repo.Values;
        }

        public IEnumerable<Card> GetArchivedCards()
        {
            return _archive.Values;
        }

        public Board GetBoardById(string id)
        {
            Board td = null;
            _repo.TryGetValue(id, out td);
            return td;
        }

        public List GetListById(string bid, string lid)
        {
            Board board = null;
            _repo.TryGetValue(bid, out board);
            return board.GetListById(lid);
        }

        public Card GetCardById(string bid, string cid)
        {
            Board board = null;
            _repo.TryGetValue(bid, out board);
            return board.GetCardById(cid);
        }

        public void UpdateCard(string bid, string lid, string cid, string desc, string date)
        {
            Card c = GetCardById(bid, cid);
            c.Description = desc;
            c.dueDate = DateTime.Parse(date + " 00:00:00");
            c = GetCardByList(bid, lid, cid);
            c.Description = desc;
            c.dueDate = DateTime.Parse(date + " 00:00:00");
        }

        public Card GetCardByList(string bid, string lid, string cid)
        {
            return GetBoardById(bid).GetListById(lid).GetCardById(cid);
        }

        public bool ContainsBoard(string bid)
        {
            return _repo.ContainsKey(bid);
        }

        public bool ContainsList(string bid, string lid)
        {
            List l = GetListById(bid, lid);
            if (l == null)
                return false;
            return true;
        }

        public bool AddBoard(string id, string desc)
        {
            var td = new Board(id, desc);
            if (ContainsBoard(id))
                return false;
            else
                _repo.Add(td.Id, td);
            return true;
        }

        public bool ArchiveCard(string bid, string cid)
        {
            Board board = null;
            _repo.TryGetValue(bid, out board);
            if (board != null)
            {
                Card c = board.GetCardById(cid);
                if (c != null)
                {
                    _archive.Add(bid + "_" + c.Id, c);
                    c.listContainer = null;
                    c.boardContainer = null;
                    return board.RemoveCard(cid);
                }
            }
            return false;
        }

        public Card GetArchivedCardById(string id)
        {
            Card c = null;
            _archive.TryGetValue(id, out c);
            return c;
        }

    }
}
