using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloApp.Models
{
    class Card : Element
    {
        public Card(string id)
        {
            this.Id = id;
        }
    }
}
