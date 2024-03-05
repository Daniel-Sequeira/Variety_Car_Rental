using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VarietyCarRental.Models;

namespace VarietyCarRental.Controllers
{
    public class HomeController : Controller
    {
      public IActionResult Index() { return View(); }

      public IActionResult AcercaDe() { return View(); }

      public IActionResult Login () { return View(); }

      public IActionResult Vehiculos () { return View(); }

      public IActionResult Reservas() { return View(); }
      public IActionResult RegistrarUsuarios() { return View(); }
    }

    
}
