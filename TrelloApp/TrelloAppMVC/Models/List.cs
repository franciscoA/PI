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
    public class List
    {
        [Key]
        [Required]
        [StringLength(200)]
        [Column("lid",Order=0)]
        [Display(Name = "Identification")]
    //    [Remote("UniqueList", "Lists", ErrorMessage = "List Identifier Already Exists in Board")]
        public string lid { get; set; }

        [Key]
        [StringLength(200)]
        [Column("bid",Order=1)]
        [Display(Name = "Board Identification")]
        public string bid { get; set; }

        [Association("Board","bid","bid")]
        public Board foreignbid { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string list_description { get; set; }

        [Display(Name = "Position")]
        [Remote("CheckPos", "Lists", ErrorMessage = "Position doesnt exist. Must swap with a valid list position.")]
        public int listPos { get; set; }

    }
    public class ListContext : DbContext
    {
        public ListContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ListContext>(null);
        }
        public DbSet<List> Lists { get; set; }

        public DbSet<Board> Boards { get; set; }
    }
}