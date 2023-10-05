using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    public ActionResult Create()
    {
        SelectList selectList = new SelectList(_db.Stylists, "StylistId", "Name");
        ViewBag.StylistId = selectList;
        return View();
    }
  }
}