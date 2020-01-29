using System.Collections.Generic;
using System;
namespace PierrsTreatFlavor.Models
{
    public class Treat
    {
        public int TreatId {get;set;}
        public string TreatName {get;set;}
        public DateTime TreatBakedDate {get;set;}
        public string TreatType {get;set;}
        public virtual ICollection<TreatFlavor> Flavors {get;set;}

        public Treat()
        {
            this.Flavors = new HashSet<TreatFlavor>();
        } 
    }
}