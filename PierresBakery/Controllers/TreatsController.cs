using Microsoft.AspNetCore.Mvc;
using PierresBakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresBakery.Controllers
{
  // [Authorize]
  public class ChildsController : Controller
  {
    private readonly PierresBakeryContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;

    public ChildsController(PierresBakeryContext db)
    {
      // _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Childs.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Child child, int FlavorId)
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // item.User = currentUser;
      _db.Childs.Add(child);
      if (FlavorId != 0)
      {
        _db.FlavorChild.Add(new FlavorChild() { FlavorId = FlavorId, ChildId = child.ChildId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisChild = _db.Childs
          .Include(child => child.JoinEntries)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(child => child.ChildId == id);
      return View(thisChild);
    }

    public ActionResult Edit(int id)
    {
      var thisChild = _db.Childs.FirstOrDefault(child => child.ChildId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisChild);
    }
    
    [HttpPost]
    public ActionResult Edit(Child child, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.FlavorChild.Add(new FlavorChild() { FlavorId = FlavorId, ChildId = child.ChildId });
      }
      _db.Entry(child).State=EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var thisChild = _db.Childs.FirstOrDefault(childs => childs.ChildId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisChild);
    }
    
    [HttpPost]
    public ActionResult AddFlavor(Child child, int FlavorId)
    {
      if(FlavorId != 0)
      {
        _db.FlavorChild.Add(new FlavorChild() { FlavorId = FlavorId, ChildId = child.ChildId});
      }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisChild = _db.Childs.FirstOrDefault(childs => childs.ChildId == id);
      return View(thisChild);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisChild = _db.Childs.FirstOrDefault(childs => childs.ChildId == id);
      _db.Childs.Remove(thisChild);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  
    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.FlavorChild.FirstOrDefault(entry => entry.FlavorChildId == joinId);
      _db.FlavorChild.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
