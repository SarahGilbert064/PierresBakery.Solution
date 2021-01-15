using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PierresBakery.Models;

namespace PierresBakery.Controllers
{
  public class HomeController : Controller
  {
    private readonly PierresBakeryContext _db;

    public HomeController(PierresBakeryContext db)
    {
      _db = db;
    }
    
    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Flavors = _db.Flavors.ToList();
      ViewBag.Treats = _db.Treats.ToList();
      return View();
    }

  }
}