using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloApp.Models
{
    interface IElementRepository
    {
        IEnumerable<Board> GetAll();
        Board GetBoardById(string id);
        List GetListById(string bid, string lid);
        void AddBoard(Board td);
    }
}
