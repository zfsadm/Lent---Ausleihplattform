using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace lent.Models
{
    public class Item
    {   public int ID { get; set; }
        public int CategoryForeignkey { get; set; }
        [ForeignKey("CategoryForeignkey")]
        public Category Kategorie { get; set; }
        public string Name { get; set; }
        public int OwnerForeignkey { get; set; }
        [ForeignKey("OwnerForeignkey")]
        public User Owner { get; set; }

        public int? BorrowerForeignkey { get; set; }
        [ForeignKey("BorrowerForeignkey")]
        public User Borrower { get; set; }
        public string Discription { get; set; }
        
        /// <summary>
        /// Status == true meint, dass der Gegenstand verliehen ist
        /// </summary>
        public bool Status { get; set; }

        const int MaxLength = 2500;
        

        public void CheckSetLength() { 
            if (Discription.Length > MaxLength) 
                Discription= Discription.Substring(0, MaxLength);
            }
    }
}
