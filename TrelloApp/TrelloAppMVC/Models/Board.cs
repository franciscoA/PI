using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{


    public class Board
    {
        [Key]
        [Required]
        [StringLength(200)]
        [Display(Name = "Identification")]
        [Remote("UniqueBoard","Boards",ErrorMessage="Board Identifier Already Exists")]
        public string bid { get; set; }

        [Display(Name = "Description")]
        [StringLength(200)]
        public string board_description { get; set; }

    }
    public class BoardContext : DbContext
    {
        public BoardContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<BoardContext>(null);
        }
        public DbSet<Board> Boards { get; set; }
    }
}