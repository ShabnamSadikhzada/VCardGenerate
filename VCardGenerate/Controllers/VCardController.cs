using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using VCardGenerate.Data;
using VCardGenerate.Models;

namespace VCardGenerate.Controllers;

public class VCardController : Controller
{
    private readonly VCardDbContext _context;

    public VCardController(VCardDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create() => View();
    
    [HttpPost]
    public IActionResult Create(VCard model)
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

            return RedirectToAction("DisplayQr", vCard);
        }

        return View(model);
    }

    public IActionResult DisplayQr(VCard model)
    { 
        QRCodeLogo qrCodeLogo = new QRCodeLogo();
        GeneratedBarcode myQRCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo(model.VCardToText(), qrCodeLogo);

        string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string imagesPath = Path.Combine(wwwRootPath, "assets", "images");

        if (!Directory.Exists(imagesPath))
        {
            Directory.CreateDirectory(imagesPath);
        }

        string fileName = $"{model.PhoneNumber}.jpg"; //nomreler unique oldugu ucun adlandirmani boyle yapdim
        string filePath = Path.Combine(imagesPath, fileName);

        // Save the image
        myQRCodeWithLogo.SaveAsImage(filePath);

        model.QrUrl = $"/assets/images/{fileName}";

        _context.VCards.Add(model);
        _context.SaveChanges();
        return View(model);
    }

}
