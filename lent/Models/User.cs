using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lent.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Anmeldename")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Vorname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Nachname")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "EMail Adresse")]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Item> borrowedItems { get; set; }
        public List<Item> ownedItems { get; set; }
    }
}
