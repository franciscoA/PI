using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TrelloAppMVC.Models
{
    public class User
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Key]
        [Required]
        [StringLength(50)]
        //      [Remote("UniqueUser", "Users", ErrorMessage = "Username Already Exists")][Display(Name = "Identification")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [StringLength(10)]
        [Display(Name = "Role")]
        public string role { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }

        [Display(Name = "Foto")]
        public string foto { get; set; } 

    }


    public class UserContext : DbContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<UserContext>(null);
        }
        public DbSet<User> Users { get; set; }
    }
}