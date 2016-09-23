using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Accessory
    {
        [Key]
        public int AccessoryID { get; set; }

        public string AccessoryName { get; set; }
        public string AccessoryColor { get; set; }
        public string AccessoryPhoto { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }
    }
}