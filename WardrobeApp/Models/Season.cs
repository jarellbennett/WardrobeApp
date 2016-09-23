using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Season
    {
        [Key]
        public int SeasonID { get; set; }

        public string SeasonName { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }
    }
}