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
        Card GetCardById(string bid, string cid);
        Card GetCardByList(string bid, string list, string cid);
        IEnumerable<Card> GetArchivedCards();
        bool ArchiveCard(string bid, string cid);
        bool AddBoard(string bid, string desc);
        Card GetArchivedCardById(string id);
        bool ContainsBoard(string bid);
        bool ContainsList(string bid, string lid);
        void UpdateCard(string bid, string lid, string cid, string desc, string date);
    }
}
