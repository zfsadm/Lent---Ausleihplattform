using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lent.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Kategorie")]
        public string Name { get; set; }
        public string Info { get; set; }
        public List <Item> CategoriestItems { get; set; }
    }
}
