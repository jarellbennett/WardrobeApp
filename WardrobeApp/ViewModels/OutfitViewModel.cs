using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WardrobeApp.Models;

namespace WardrobeApp.ViewModels
{
    public class OutfitViewModel
    {
        public Outfit Outfit { get; set; }
        public IEnumerable<SelectListItem> AllAccessories { get; set; }

        private List<int> _selectedAccessories;
        public List<int> SelectedAccessories
        {
            get
            {
                if(_selectedAccessories == null)
                {
                    //uses sql statement to grab all accesories ids, converts to integer ids
                    _selectedAccessories = (from a in Outfit.Accessories select a.AccessoryID).ToList();
                }
                return _selectedAccessories;
            }
            set { _selectedAccessories = value; }
        }
    }
}