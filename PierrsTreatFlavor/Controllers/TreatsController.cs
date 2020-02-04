using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierrsTreatFlavor.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PierrsTreatFlavor.Controllers
{
    public class TreatsController:Controller
    {

        private readonly TreatFlavorContextDB _dataBase;
        public TreatsController(TreatFlavorContextDB db)
        {
            _dataBase=db;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Treat> treats = _dataBase.Treats.ToList();
            return View(treats);
        }
        [HttpGet]
        public ActionResult Read(int readID)
        {
            var treatList = _dataBase.Treats
                               .Include(rowTreats => rowTreats.Flavors)
                               .ThenInclude(join => join.Flavor)
                               .FirstOrDefault(rowTreats => rowTreats.TreatId==readID);
                               return View(treatList); 
        }
     
        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.FlavorId = new SelectList(_dataBase.Flavors,"FlavorId","FlavorName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Treat new_treat)
        {
            _dataBase.Treats.Add(new_treat);
            _dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int updateID)
        {
            Treat updatingTreat = _dataBase.Treats.FirstOrDefault(treats => treats.TreatId==updateID);
            //ViewBag.FlavorId = new SelectList(_dataBase.Flavors,"FlavorId","FlavorName");
            return View(updatingTreat);
        }
        [HttpPost]
        public ActionResult Update(Treat new_treat)
        {
            _dataBase.Entry(new_treat).State=EntityState.Modified;
            _dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int deleteID)
        {
            Treat deletingTreat = _dataBase.Treats.FirstOrDefault(treats =>treats.TreatId==deleteID);
            return View(deletingTreat);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int deleteID)
        {
            Treat deletingTreat = _dataBase.Treats.FirstOrDefault(treats =>treats.TreatId==deleteID);
            _dataBase.Remove(deletingTreat);
            _dataBase.SaveChanges();
            return View("Index");
        }

    }
}