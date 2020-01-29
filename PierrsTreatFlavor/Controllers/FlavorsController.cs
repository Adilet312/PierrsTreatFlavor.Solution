using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierrsTreatFlavor.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
namespace PierrsTreatFlavor.Controllers
{
    [Authorize]
    public class FlavorsController:Controller
    {
        private readonly TreatFlavorContextDB _dataBase;
        private readonly UserManager<ApplicationUser> _userManager;
        public PetsController(TreatFlavorContextDB db,UserManager<ApplicationUser> userManager)
        {
            _dataBase = db;
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var userflavors = _dataBase.Flavors.Where(entry => entry.User.Id == currentUser.Id);
            return View(userpets);
        }
        [HttpGet]
        public ActionResult Read(int readID)
        {
            var flavorList = _dataBase.Flavors
                               .Include(flavors => flavors.Treats)
                               .ThenInclude(join => join.Treat)
                               .FirstOrDefault(flavors => flavors.FlavorId==readID);
                               return View(flavorList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TreatId = new SelectList(_dataBase.Treats,"TreatId","TreatName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor, int TreatId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            flavor.User = currentUser;
            _dataBase.Flavors.Add(flavor);
            if (TreatId != 0)
            {
                _dataBase.TreatFlavors.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId });
            }
            _dataBase.SaveChanges();
            return RedirectToAction("Index");
        } 
        [HttpGet]
        public ActionResult Update(int updateID)
        {
            Flavor updateFlavor = _dataBase.Flavors.FirstOrDefault(rows => rows.FlavorId==updateID);
            ViewBag.TreatId = new SelectList(_dataBase.Treats,"TreatId","TreatName");
            return View(updateFlavor);
        }
        [HttpPost]
        public ActionResult Update(Flavor update_Flavor,int TreatId)
        {
            if(TreatId!=0)
            {
                _dataBase.TreatFlavors.Add(new TreatFlavor(){TreatId=TreatId, FlavorId=update_Flavor.FlavorId});
            }
            _dataBase.Entry(update_Flavor).State = EntityState.Modified;
            _dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddCustomer(int id)
        {
            
            var thisFlavor = _dataBase.Flavors.FirstOrDefault(rows => rows.FlavorId==id);
            ViewBag.TreatId = new SelectList(_dataBase.Treats,"TreatId","TreatName");
            return View(thisFlavor);
        }
        
        [HttpPost]
        public ActionResult AddTreat(Flavor flavors, int TreatId)
        {
            if (TreatId != 0)
            {
                _dataBase.TreatFlavors.Add(new TreatFlavor(){TreatId=TreatId,FlavorId=flavors.FlavorId});
            
            }
            _dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int deleteID)
        {
            Flavor deletingFlavor = _dataBase.Flavors.FirstOrDefault(flavors =>flavors.FlavorId==deleteID);
            return View(deletingFlavor);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int deleteID)
        {
            Flavor deletingFlavor = _dataBase.Flavors.FirstOrDefault(flavors =>flavors.FlavorId==deleteID);
            _dataBase.Remove(deletingFlavor);
            _dataBase.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public ActionResult DeleteCustomer(int joinId)
        {
            var joinEntry = _dataBase.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
            _dataBase.TreatFlavors.Remove(joinEntry);
            _dataBase.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}