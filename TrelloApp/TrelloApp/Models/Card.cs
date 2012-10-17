using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloApp.Models
{
    class Card : Element
    {
        public DateTime creationDate { get; set; }
        public DateTime dueDate { get; set; }
        public string listContainer { get; set; }
        public string boardContainer { get; set; }
        public bool archived;

        public Card(string id, string desc)
        {
            this.archived = false;
            this.Id = id;
            this.Description = desc;
        }
    }
}
