using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Create(int stylistId)
    {
        var client = new Client
        {
            StylistId = stylistId
        };
        SelectList selectList = new SelectList(_db.Stylists, "StylistId", "Name");
        ViewBag.StylistId = selectList;
        return View(client);
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      if (client.StylistId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Clients.Add(client);
      _db.SaveChanges();
     return RedirectToAction("Details", "Stylists", new { id = client.StylistId });    
     }
  }
}