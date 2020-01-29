using System;
namespace PierrsTreatFlavor.Models
{
    public class TeatFlavor
    {
        public int TraetFlavor {get;set;}
        public int TreatId {get;set;}
        public int FlavorId {get;set;}
        public Treat Treat {get;set;}
        public Flavor Flavor {get;set;}
    }
}