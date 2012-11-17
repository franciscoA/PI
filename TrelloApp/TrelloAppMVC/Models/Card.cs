using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDemo.Models
{
    public class Card
    {
        [Key]
        [Required]
        [StringLength(200)]
        [Display(Name = "Identification")]
    //    [Remote("UniqueCard", "Cards", ErrorMessage = "Card Identifier Already Exists in Board")]
        [Column("cid", Order = 0)]
        public string cid { get; set; }

        [Key]
        [StringLength(200)]
        [Display(Name = "Board Identification")]
        [Column("bid", Order = 2)]
        public string bid { get; set; }

        [Association("Board", "bid", "bid")]
        public Board foreignbid { get; set; }

        [StringLength(200)]
        [Display(Name = "List Identification")]
        [Column("lid", Order = 1)]
        [Remote("CheckLists", "Cards", ErrorMessage = "List doesnt exist in board context.")]
        public string lid { get; set; }

        [Association("List", "lid", "lid")]
        public List foreignlid { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string card_description { get; set; }

        [Display(Name = "Position")]
        [Remote("CheckPos", "Cards", ErrorMessage = "Position doesnt exist. Must swap with a valid card position.")]
        public int cardPos { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime cdate { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime ddate { get; set; }

        [Display(Name = "Archived")]
        public bool archived { get; set; }

    }
    public class CardContext : DbContext
    {
        public CardContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<CardContext>(null);
        }
        public DbSet<Card> Cards { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<List> Lists { get; set; }
    }
}