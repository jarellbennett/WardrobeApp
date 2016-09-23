using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Shoe
    {
        [Key]
        public int ShoesID { get; set; }

        public string ShoeName { get; set; }
        public string ShoeColor { get; set; }
        public  string ShoePhoto { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }


    }
}