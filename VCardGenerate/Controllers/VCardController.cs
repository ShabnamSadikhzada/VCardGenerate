using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using VCardGenerate.Models;

namespace VCardGenerate.Controllers;

public class VCardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public ActionResult Create() => View();
    
    
    [HttpPost]
    public ActionResult Create(VCard model)
    {
        if (ModelState.IsValid)
        {
            var vCard = new VCard
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PhoneType = model.PhoneType,
                City = model.City,
                Country = model.Country
            };

            return RedirectToAction("Index");
        }


        return View(model);
    }
}
