using System.Collections.Generic;

namespace TrelloApp.Models
{
    class ElementMemoryRepository : IElementRepository
    {
        private readonly IDictionary<string, Board> _repo = new Dictionary<string, Board>();

        public IEnumerable<Board> GetAll()
        {
            return _repo.Values;
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

        public void AddBoard(Board td)
        {
            _repo.Add(td.Id, td);
        }
    }
}
