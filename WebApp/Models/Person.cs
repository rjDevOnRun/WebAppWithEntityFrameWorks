using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    // https://github.com/DotNetMastery/Rocky

    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DataOfBirth { get; set; }

        [Display(Name = "Email Id")]
        public string Email { get; set; }

        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

    }
}
