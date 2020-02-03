using System.Collections.Generic;
using System;
namespace PierrsTreatFlavor.Models
{
    public class Flavor
    {
        public int FlavorId {get;set;}
        public string FlavorName {get;set;}
        public DateTime FlavorDateExpiration {get; set;}
        public double FlavorPrice {get;set;}
        public ICollection<TreatFlavor> Treats {get;set;}
        
        public Flavor()
        {
            this.Treats = new HashSet<TreatFlavor>();
        }
    }
}