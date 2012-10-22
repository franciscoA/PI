using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloApp.Models
{
    interface IElementRepository
    {
        ICollection GetAll();
        Board GetBoardById(string id);
        List GetListById(string bid, string lid);
        Card GetCardById(string bid, string cid);
        Card GetCardByList(string bid, string list, string cid);
        ICollection GetArchivedCards();
        bool ArchiveCard(string bid, string cid);
        bool AddBoard(string bid, string desc);
        Card GetArchivedCardById(string id);
        bool ContainsBoard(string bid);
        bool ContainsList(string bid, string lid);
        bool UpdateCard(string bid, string lid, string cid, string desc, string date);
        bool MoveCard(string bid, string lid, string cid, string destList, int position);
    }
}
