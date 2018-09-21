using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lent.Models
{
    public class Item
    {   public int ID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Borrower { get; set; }
        public string Discription { get; set; }
        public bool Status { get; set; } 
        const int MaxLength = 2500;

        public void CheckSetLength() { 
            if (Discription.Length > MaxLength) 
                Discription= Discription.Substring(0, MaxLength);
            }
    }
}
