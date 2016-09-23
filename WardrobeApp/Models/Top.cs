using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Top
    {
        [Key]
        public int TopID { get; set; }

        public string TopName { get; set; }
        public string TopColor { get; set; }
        public string TopPhoto { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }
    }
}