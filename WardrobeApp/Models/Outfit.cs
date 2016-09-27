using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Outfit
    {
        [Key]
        public int OutfitID { get; set; }
        public string OutfitName { get; set; }

        public int TopID { get; set; }
        public int BottomID { get; set; }
        public int AccessoryID { get; set; }
        public int SeasonID { get; set; }
        public int OccasionID { get; set; }


        //Foreign Keys
        public virtual Top Top { get; set; }
        
        public virtual Bottom Bottom { get; set; }
        
        public virtual Shoe Shoe { get; set; }

        public virtual Season Season { get; set; }

        public virtual Occasion Occasion { get; set; }

        //Many to Many Relationship 
        public virtual ICollection<Accessory> Accessories { get; set; }
        
    }
}