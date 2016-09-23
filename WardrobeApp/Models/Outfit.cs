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

        public int TopID;
        public int BotID;
        public int ShoeID;
        public int AccessoryID;
        public int SeasonID;
        public int OccasionID;


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