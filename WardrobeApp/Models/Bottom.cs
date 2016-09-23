using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Bottom
    {
        [Key]
        public int BottomID { get; set; }

        public string BotName { get; set; }
        public string BotColor { get; set; }
        public string BotPhoto { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }

    }
}