using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeApp.Models;
using WardrobeApp.ViewModels;

namespace WardrobeApp.Controllers
{
    public class OutfitsController : Controller
    {
        private WardrobeAppContext db = new WardrobeAppContext();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Bottom).Include(o => o.Occasion).Include(o => o.Season).Include(o => o.Shoe).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            Outfit outfit = new Outfit();

            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BotName");
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "OccasionName");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName");
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoeName");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName");

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                AllAccessories = (from a in db.Accessories
                                  select new SelectListItem
                                  {
                                      Value = a.AccessoryID.ToString(),
                                      Text = a.AccessoryName
                                  })
            };
            return View(outfitViewModel);
            
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,OutfitName,TopID,BottomID,ShoesID,SeasonID,OccasionID")] Outfit outfit, List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {

                //create a variable to access the data in the database
                var newOutfit = outfit;

                newOutfit.TopID = outfit.TopID;
                newOutfit.BottomID = outfit.BottomID;
                newOutfit.ShoesID = outfit.ShoesID;
                newOutfit.OccasionID = outfit.OccasionID;
                newOutfit.SeasonID = outfit.SeasonID;


                foreach (int accessoryID in SelectedAccessories)
                {
                    //find the accessory by its id and add it to the existing outfit
                    newOutfit.Accessories.Add(db.Accessories.Find(accessoryID));

                }

                db.Outfits.Add(newOutfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BotName", outfit.BottomID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "OccasionName", outfit.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", outfit.SeasonID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoeName", outfit.ShoesID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);
            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BotName", outfit.BottomID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "OccasionName", outfit.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", outfit.SeasonID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoeName", outfit.ShoesID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);


            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                AllAccessories = (from a in db.Accessories
                                  select new SelectListItem
                                  {
                                      Value = a.AccessoryID.ToString(),
                                      Text = a.AccessoryName
                                  })
            };
                    return View(outfitViewModel);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,OutfitName,TopID,BottomID,ShoesID,SeasonID,OccasionID")] Outfit outfit,List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {
                //create a variable to access the data in the database
                var existiingOutfit = db.Outfits.Find(outfit.OutfitID);

                existiingOutfit.TopID = outfit.TopID;
                existiingOutfit.BottomID = outfit.BottomID;
                existiingOutfit.ShoesID = outfit.ShoesID;

                existiingOutfit.Accessories.Clear();

                foreach(int accessoryID in SelectedAccessories)
                {
                    //find the accessory by its id and add it to the existing outfit
                    existiingOutfit.Accessories.Add(db.Accessories.Find(accessoryID));

                }

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BotName", outfit.BottomID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "OccasionName", outfit.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", outfit.SeasonID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoeName", outfit.ShoesID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
